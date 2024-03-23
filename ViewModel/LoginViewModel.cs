using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PlayerClassifier.WPF.ViewModel
{
    public class LoginViewModel : ViewModelBase
    {
        //definindo properties que vão estabelecer o binding entre View e ViewModel

        private string _userEmail;
        private string _password;
        private string _errorMessage;
        private bool _isViewVisible = true; //para ver se a View é visível (se o login der certo, hide the view)

        public string UserEmail {
            get { return _userEmail; }
            set { _userEmail = value; OnPropertyChanged(nameof(UserEmail)); } //OnPropertyChanged chamado para notificar que o valor da property foi alterado
        }
        public string Password { 
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

        //definindo os comandos 

        public ICommand LoginCommand { get; }
        public ICommand ShowPasswordCommand { get; }
        public ICommand RecoverPasswordCommand { get; }
        public ICommand RememberMeCommand { get; }

        public LoginViewModel ()
        {
            LoginCommand = new ViewModelCommand(ExecuteLoginCommand, CanExecuteLoginCommand);
            RecoverPasswordCommand = new ViewModelCommand(ExecuteRecoverPasswordCommand);
        }

        private bool CanExecuteLoginCommand (object obj)
        {
            bool validData;
            
            if (string.IsNullOrEmpty(UserEmail) || UserEmail.Length < 3 || Password == null || Password.Length < 3)
            {
                validData = false;
            }
            else
                validData = true; //se os campos não estiverem vazios, o botão de login fica habilitado e vc pode clicar nele
            return validData;
        }

        private bool ExecuteLoginCommand (object obj)
        {
            return false;
        }

        private bool ExecuteRecoverPasswordCommand (object obj)
        {
            throw new NotImplementedException();
            return true;
        }
    }
}
