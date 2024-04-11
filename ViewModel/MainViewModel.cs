using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using PlayerClassifier.WPF.Model;
using PlayerClassifier.WPF.Repositories;

namespace PlayerClassifier.WPF.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private UserAccountModel __currentUserAccount;
        private IUserRepository userRepository;
        
        public UserAccountModel CurrentUserAccount { get { return __currentUserAccount; } set { __currentUserAccount = value; OnPropertyChanged(nameof(CurrentUserAccount)); } }

        public MainViewModel()
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
                    CurrentUserAccount.displayName = $"{user.UserName}";
                    CurrentUserAccount.profilePicture = null;
                };
            } else
            {
                CurrentUserAccount.displayName = "Usuário inválido.";
                Application.Current.Shutdown();
            }
        }
        }
    }
