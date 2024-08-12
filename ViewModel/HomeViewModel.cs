using PlayerClassifier.WPF.Model;
using PlayerClassifier.WPF.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PlayerClassifier.WPF.ViewModel
{
    public class HomeViewModel : ViewModelBase
    {
        IUserRepository userRepository;
        private UserAccountModel __currentUserAccount;

        public UserAccountModel CurrentUserAccount { get { return __currentUserAccount; } set { __currentUserAccount = value; OnPropertyChanged(nameof(CurrentUserAccount)); } }

        public HomeViewModel()
        {
            userRepository = new UserRepository();
            CurrentUserAccount = new UserAccountModel();
            LoadCurrentUserData();
        }
        private void LoadCurrentUserData()
        {
            try
            {
                if (Thread.CurrentPrincipal != null && Thread.CurrentPrincipal.Identity != null && Thread.CurrentPrincipal.Identity.IsAuthenticated)
                {
                    var user = userRepository.GetByUserName(Thread.CurrentPrincipal.Identity.Name);
                    if (user != null)
                    {
                        CurrentUserAccount.userName = user.UserName;
                        CurrentUserAccount.displayName = $"Bem-vindo {user.UserName}!";
                        CurrentUserAccount.cargo = user.UserJob;
                    }
                    else
                    {
                        MessageBox.Show("Usuário não encontrado. A aplicação será encerrada.");
                        Application.Current.Shutdown();
                    }
                }
                else
                {
                    MessageBox.Show("Nenhum usuário autenticado. A aplicação será encerrada.");
                    Application.Current.Shutdown();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro: {ex.Message}");
                Application.Current.Shutdown();
            }
        }


    }
}
