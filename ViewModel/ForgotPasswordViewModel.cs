using PlayerClassifier.WPF.Model;
using PlayerClassifier.WPF.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using static IronPython.Modules._ast;

namespace PlayerClassifier.WPF.ViewModel
{
    public class ForgotPasswordViewModel : ViewModelBase
    {
        private string _username;
        private SecureString _newpassword;
        private string _errorMessage;
        private IUserRepository _userRepository;
        private bool _isViewVisible;
        public string UserName { get { return _username; } set { _username = value; OnPropertyChanged(nameof(UserName)); } }
        public SecureString NewPassword { get { return _newpassword;} set { _newpassword = value; OnPropertyChanged(nameof(NewPassword)); } }
        public string ErrorMessage { get { return _errorMessage; } set { _errorMessage = value; OnPropertyChanged(nameof(ErrorMessage)); } }
        public bool IsViewVisible { get { return _isViewVisible; } set { _isViewVisible = value; OnPropertyChanged(nameof(IsViewVisible)); } }

        public ICommand ConfirmPasswordCommand { get; }

        public ForgotPasswordViewModel()
        {
            _userRepository = new UserRepository();
            ConfirmPasswordCommand = new ViewModelCommand(ExecuteConfirmPasswordCommand, CanExecuteConfirmPasswordCommand);
        }

        private bool CanExecuteConfirmPasswordCommand(object obj)
        {
            bool isFieldsOk;
            // || Name.All(c => char.IsLetter(c) && !char.IsPunctuation(c)) || string.IsNullOrEmpty(UserName) || Password == null || Password.Length < 8 || string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Cargo) || Cargo.All(c => char.IsLetter(c) && !char.IsPunctuation(c))
            if (string.IsNullOrEmpty(UserName) || NewPassword == null || NewPassword.Length < 8)
            {
                isFieldsOk = false;
                return isFieldsOk;
            }
            else
            {
                var isValidUser = _userRepository.GetByUserName(UserName);
                if (isValidUser != null) {
                    isFieldsOk = true;
                } else
                {
                    isFieldsOk = false;
                }
                
            }
            return isFieldsOk;
        }

        private void ExecuteConfirmPasswordCommand(object obj)
        {
            throw new NotImplementedException();
        }
    }
}
