using PlayerClassifier.WPF.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PlayerClassifier.WPF.ViewModel
{
    public class ObservationViewModel : ViewModelBase
    {
        private ObservableCollection<OnHoldModel> _playersOnHold;
        public ObservableCollection<OnHoldModel> PlayersOnHold
        {
            get { return _playersOnHold; }
            set
            {
                _playersOnHold = value;
                OnPropertyChanged(nameof(PlayersOnHold));
            }
        }

        private bool _isOnHold;
        public bool IsOnHold
        {
            get { return _isOnHold; }
            set
            {
                _isOnHold = value;
                OnPropertyChanged(nameof(IsOnHold));
            }
        }

        public ObservationViewModel()
        {
            PlayersOnHold = new ObservableCollection<OnHoldModel>();
            LoadClassifications();
        }

        private void LoadClassifications()
        {
            var user = Thread.CurrentPrincipal.Identity.Name;
            var connectionString = "Server=localhost;Database=MVVMPC;Trusted_Connection=True;";

            var playersOnHold = new ObservableCollection<OnHoldModel>();

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var query = "SELECT Name, PlayerId, About, Username FROM PlayersInObservation WHERE Username = @Username";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", user);

                    using (var reader = command.ExecuteReader())
                    {
                        if (!reader.HasRows)
                        {
                            IsOnHold = false;
                            PlayersOnHold = playersOnHold;
                            return;
                        }

                        while (reader.Read())
                        {
                            playersOnHold.Add(new OnHoldModel
                            {
                                Name = reader["Name"].ToString(),
                                PlayerId = (int)reader["PlayerId"],
                                About = reader["About"].ToString()
                            });
                        }
                    }
                }
            }

            IsOnHold = true;

            PlayersOnHold = playersOnHold;
        }


        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
