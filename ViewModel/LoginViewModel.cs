using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
