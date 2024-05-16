using PlayerClassifier.WPF.Model;
using PlayerClassifier.WPF.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PlayerClassifier.WPF.ViewModel
{
    public class ClassifyPlayerViewModel : ViewModelBase
    {
        private string _uploadedFile;
        IUserRepository _userRepository;
        public string UserFile { get { return _uploadedFile; } set { _uploadedFile = value; OnPropertyChanged(nameof(UserFile)); } }


        public ICommand ClassifyCommand { get; set; }

        public ClassifyPlayerViewModel() {

            _userRepository = new UserRepository();
            ClassifyCommand = new ViewModelCommand(ExecuteClassifyCommand, CanExecuteClassifyCommand);
        }


        private bool CanExecuteClassifyCommand(object obj)
        {
            bool canExecute;
            if (string.IsNullOrEmpty(UserFile))
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
            var classifyPlayer = _userRepository.ClassifyPlayer(UserFile);
        }

        public bool fileWasUploaded(string filePath)
        {
            if (filePath == null)
            {
                return false;
            } else
            {
                UserFile = filePath;
                OnPropertyChanged(nameof(UserFile));
                ClassifyCommand = new ViewModelCommand(ExecuteClassifyCommand, CanExecuteClassifyCommand);
                return true;
            }
        }
    }
}
