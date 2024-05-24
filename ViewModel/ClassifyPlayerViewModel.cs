using IronPython.Compiler.Ast;
using PlayerClassifier.WPF.Model;
using PlayerClassifier.WPF.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace PlayerClassifier.WPF.ViewModel
{
    public class ClassifyPlayerViewModel : ViewModelBase
    {
        private string _uploadedFile;
        private UserAccountModel _currentUser;
        IUserRepository _userRepository;
        int firstTime = 2;
        public string UserFile { get { return _uploadedFile; } set { _uploadedFile = value; OnPropertyChanged(nameof(UserFile)); } }
        public UserAccountModel CurrentUser { get { return _currentUser; } set { _currentUser = value; OnPropertyChanged(nameof(CurrentUser)); } }

        public ICommand ClassifyCommand { get; set; }

        public ClassifyPlayerViewModel()
        {

            _userRepository = new UserRepository();
            CurrentUser = new UserAccountModel();
            ClassifyCommand = new ViewModelCommand(ExecuteClassifyCommand, CanExecuteClassifyCommand);
        }


        private bool CanExecuteClassifyCommand(object obj)
        {
            bool canExecute;

            if (firstTime == 0)
            {
                canExecute = false;
            }
            else 
            {
                canExecute = true;
            }
            return canExecute;
        }

        private void ExecuteClassifyCommand(object obj)
        {
            var user = _userRepository.GetByUserName(Thread.CurrentPrincipal.Identity.Name);
            if (user != null)
            {
                var userInfo = _userRepository.GetUploadedFile(Thread.CurrentPrincipal.Identity.Name);
                UserFile = userInfo.UploadedFile;
                var classifyPlayer = _userRepository.ClassifyPlayer(UserFile);
                MessageBox.Show("Resultado da classificação: ", classifyPlayer);
            }
        }

        public void loadFile(string path)
        {
            var user = _userRepository.GetByUserName(Thread.CurrentPrincipal.Identity.Name);
            if (user != null)
            {
                {
                    CurrentUser.UploadedFile = path;
                    OnPropertyChanged(nameof(CurrentUser));
                    _userRepository.AddUploadedFile(path, CurrentUser, Thread.CurrentPrincipal.Identity.Name);
                };
            }
            else
            {
                Application.Current.Shutdown();
            }
        }

        public bool fileWasUploaded(string filePath)
        {
            if (filePath == null)
            {
                return false;
            }
            else
            {
                firstTime = 1;
                loadFile(filePath);
                return true;
            }
        }
    }
}
