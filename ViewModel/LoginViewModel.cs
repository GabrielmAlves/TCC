using PlayerClassifier.WPF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using PlayerClassifier.WPF.Repositories;
using System.Security.Principal;
using PlayerClassifier.WPF.View;
using System.Windows;
using FontAwesome.Sharp;

namespace PlayerClassifier.WPF.ViewModel
{
    public class LoginViewModel : ViewModelBase
    {
        private string _username;
        private string _userEmail;
        private SecureString _password;
        private string _errorMessage;
        private bool _isViewVisible = true; 
        private IUserRepository userRepository;
        
        public string Username
        {
            get { return _username; }
            set { _username = value; OnPropertyChanged(nameof(Username)); }
        }
        public string UserEmail {
            get { return _userEmail; }
            set { _userEmail = value; OnPropertyChanged(nameof(UserEmail)); } 
        }
        public SecureString Password { 
            get { return _password; } 
            set { _password = value; OnPropertyChanged(nameof(Password)); } 
        }
        public string ErrorMessage {
            get { return _errorMessage; }
            set { _errorMessage = value; OnPropertyChanged(nameof(ErrorMessage)); } 
            }
        public bool IsViewVisible {
            get { return _isViewVisible; }
            set { _isViewVisible = value; OnPropertyChanged(nameof(IsViewVisible)); } 
            }


        public ICommand LoginCommand { get; }
        public ICommand RecoverPasswordCommand { get; }
        public ICommand RememberMeCommand { get; }
        public ICommand DontHaveAccountCommand { get; }
        public LoginViewModel ()
        {
            userRepository = new UserRepository();
            LoginCommand = new ViewModelCommand(ExecuteLoginCommand, CanExecuteLoginCommand);
            DontHaveAccountCommand = new ViewModelCommand(ExecuteDontHaveAccountCommand);
            RecoverPasswordCommand = new ViewModelCommand(ExecuteRecoverPasswordCommand);
        }

        private bool CanExecuteLoginCommand (object obj)
        {
            bool validData;
            
            if (string.IsNullOrEmpty(Username) || Username.Length < 1 || Password == null || Password.Length < 3)
            {
                validData = false;
            }
            else
                validData = true; 
            return validData;
        }

        private void ExecuteLoginCommand (object obj)
        {
            var isValidUser = userRepository.AuthenticateUser(new System.Net.NetworkCredential(Username, Password));
            if (isValidUser)
            {
                Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(Username), null);
                IsViewVisible = false; 
            } else
            {
                ErrorMessage = "Usuário ou senha inválidos.";
            }
        }

        private void ExecuteDontHaveAccountCommand(object obj)
        {
            var signUpView = new SignUpView();
            signUpView.Show();
        }

        private void ExecuteRecoverPasswordCommand (object obj)
        {
            var forgotPasswordView = new ForgotPasswordView();
            forgotPasswordView.Show();
        }
    }
}
