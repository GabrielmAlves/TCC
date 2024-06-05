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
    public class CompareViewModel : ViewModelBase
    {
        private string _uploadedFiles;
        private UserAccountModel _currentUser;
        IUserRepository _userRepository;
        int firstTime = 2;
        public string UserFiles { get { return _uploadedFiles; } set { _uploadedFiles = value; OnPropertyChanged(nameof(UserFiles)); } }
        public UserAccountModel CurrentUser { get { return _currentUser; } set { _currentUser = value; OnPropertyChanged(nameof(CurrentUser)); } }

        public ICommand CompareCommand { get; set; }

        public CompareViewModel()
        {

            _userRepository = new UserRepository();
            CurrentUser = new UserAccountModel();
            CompareCommand = new ViewModelCommand(ExecuteCompareCommand, CanExecuteCompareCommand);
        }


        private bool CanExecuteCompareCommand(object obj)
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

        private void ExecuteCompareCommand(object obj)
        {
            var user = _userRepository.GetByUserName(Thread.CurrentPrincipal.Identity.Name);
            if (user != null)
            {
                var userInfo = _userRepository.GetUploadedFiles(Thread.CurrentPrincipal.Identity.Name);
                UserFiles = userInfo.PlayersComparedFile;
                var comparePlayers = _userRepository.ComparePlayers(UserFiles);
                MessageBox.Show("Resultado da comparação: ", comparePlayers);
            }
        }

        public void loadFiles(string path1, string path2)
        {
            var user = _userRepository.GetByUserName(Thread.CurrentPrincipal.Identity.Name);
            if (user != null)
            {
                {
                    _userRepository.AddUploadedFiles(path1, path2, Thread.CurrentPrincipal.Identity.Name);
                };
            }
            else
            {
                Application.Current.Shutdown();
            }
        }

        public bool filesUploaded(string filePath1, string filePath2)
        {
            if (filePath1 == null || filePath2 == null)
            {
                return false;
            }
            else
            {
                firstTime = 1;
                loadFiles(filePath1, filePath2);
                return true;
            }
        }

    }
}
