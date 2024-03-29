using PlayerClassifier.WPF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using PlayerClassifier.WPF.Model;

namespace PlayerClassifier.WPF.ViewModel
{
    public class SignUpViewModel: ViewModelBase
    {
        private string _nome;
        private string _userName;
        private SecureString _password;
        private string _email;
        private string _cargo;
        private bool _isViewVisible = false;
        private IUserRepository _userRepository;
    }
}
