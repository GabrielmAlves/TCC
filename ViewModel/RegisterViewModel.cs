using PlayerClassifier.WPF.Model;
using PlayerClassifier.WPF.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PlayerClassifier.WPF.ViewModel
{
    public class RegisterViewModel : ViewModelBase
    {
        private string _nome;
        private string _userName;
        private SecureString _password;
        private string _email;
        private string _cargo;
        private bool _isViewVisible = false;
        private string _errorMessage;
        private IUserRepository _userRepository;


        public string Name
        {
            get { return _nome; }
            set { _nome = value; OnPropertyChanged(nameof(Name)); }
        }
        public string UserName
        {
            get { return _userName; }
            set { _userName = value; OnPropertyChanged(nameof(UserName)); }
        }
        public SecureString Password
        {
            get { return _password; }
            set { _password = value; OnPropertyChanged(nameof(Password)); }
        }

        public string Email
        {
            get { return _email; }
            set { _email = value; OnPropertyChanged(nameof(Email)); }
        }

        public string Cargo
        {
            get { return _cargo; }
            set { _cargo = value; OnPropertyChanged(nameof(Cargo)); }
        }
        public bool IsViewVisible
        {
            get { return _isViewVisible; }
            set { _isViewVisible = value; OnPropertyChanged(nameof(IsViewVisible)); }
        }

        public string ErrorMessage
        {
            get { return _errorMessage; }
            set { _errorMessage = value; OnPropertyChanged(nameof(ErrorMessage)); }
        }


        public ICommand CreateAccountCommand { get; }

        public RegisterViewModel()
        {
            _userRepository = new UserRepository();
            CreateAccountCommand = new ViewModelCommand(ExecuteCreateAccountCommand, CanExecuteAccountCommand);
        }

        private bool CanExecuteAccountCommand(object parameter)
        {
            bool isFieldsOk;
         
            if (string.IsNullOrEmpty(Name) || string.IsNullOrEmpty(UserName))
            {
                isFieldsOk = false;
                return isFieldsOk;
            }
            else
                isFieldsOk = true;
            return isFieldsOk;
        }

        private void ExecuteCreateAccountCommand(object parameter)
        {
            var isValidUser = _userRepository.Add(new System.Net.NetworkCredential(Name, Password), UserName, Email, Cargo);
            if (isValidUser)
            {
                //Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(UserName), null);
                //Application.Current.Shutdown();
                //IsViewVisible = false; //login bem sucedido, esconde a tela 
            }
            else
            {
                ErrorMessage = "Algo de errado ocorreu.";
            }
        }

        private bool isValidEmail(string email)
        {
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            return Regex.IsMatch(email, pattern);
        }
    }
}
