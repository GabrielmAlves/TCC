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

        private string _username;
        private string _password;
        private string _errorMessage;
        private bool _isViewVisible = true; //para ver se a View é visível (se o login der certo, hide the view)
    }
}
