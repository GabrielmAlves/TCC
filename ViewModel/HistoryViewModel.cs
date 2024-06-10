using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using PlayerClassifier.WPF.Model;

namespace PlayerClassifier.WPF.ViewModel
{
    public class HistoryViewModel : ViewModelBase
    {
        private ObservableCollection<ClassificationModel> _classifications;
        public ObservableCollection<ClassificationModel> Classifications
        {
            get { return _classifications; }
            set
            {
                _classifications = value;
                OnPropertyChanged(nameof(Classifications));
            }
        }

        private bool _hasClassifications;
        public bool HasClassifications
        {
            get { return _hasClassifications; }
            set
            {
                _hasClassifications = value;
                OnPropertyChanged(nameof(HasClassifications));
            }
        }

        public HistoryViewModel()
        {
            Classifications = new ObservableCollection<ClassificationModel>();
            LoadClassifications();
        }

        private void LoadClassifications()
        {
            var user = Thread.CurrentPrincipal.Identity.Name;
            var connectionString = "Server=localhost;Database=MVVMPC;Trusted_Connection=True;"; // Adicione sua string de conexão aqui

            var classifications = new ObservableCollection<ClassificationModel>();

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var query = "SELECT Username, PlayerId, Caracteristicas FROM Classifications WHERE Username = @Username";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", user);

                    using (var reader = command.ExecuteReader())
                    {
                        if (!reader.HasRows)
                        {
                            // Se não houver linhas, define HasClassifications como false e retorna
                            HasClassifications = false;
                            Classifications = classifications; // Certifica-se de definir a coleção vazia
                            return;
                        }

                        while (reader.Read())
                        {
                            classifications.Add(new ClassificationModel
                            {
                                Username = reader["Username"].ToString(),
                                PlayerId = (int)reader["PlayerId"],
                                Caracteristicas = reader["Caracteristicas"].ToString()
                            });
                        }
                    }
                }
            }

            // Define HasClassifications como true pois a coleção contém classificações
            HasClassifications = true;

            // Define a coleção de classificações na propriedade Classifications
            Classifications = classifications;
        }





        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
