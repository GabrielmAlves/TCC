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
            loadCurrentUserData();
        }
        private void loadCurrentUserData()
        {
            var user = userRepository.GetByUserName(Thread.CurrentPrincipal.Identity.Name);
            if (user != null)
            {
                {
                    CurrentUserAccount.userName = user.UserName;
                    CurrentUserAccount.displayName = $"Bem-vindo {user.UserName}!";
                    CurrentUserAccount.cargo = user.UserJob;

                };
            }
            else
            {
                CurrentUserAccount.displayName = "Usuário inválido.";
                Application.Current.Shutdown();
            }
        }
    }
}
