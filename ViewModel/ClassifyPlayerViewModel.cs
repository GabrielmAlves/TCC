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


        public ICommand ClassifyCommand {  get; }

        public ClassifyPlayerViewModel() {

            _userRepository = new UserRepository();
            ClassifyCommand = new ViewModelCommand(ExecuteClassifyCommand, CanExecuteClassifyCommand);
        }

        private void ExecuteClassifyCommand(object obj)
        {
            var classifyPlayer = _userRepository.ClassifyPlayer(UserFile);
        }

        private bool CanExecuteClassifyCommand(object obj)
        {
            if (string.IsNullOrEmpty(UserFile))
            {
                return false;
            } else
            {
                return true;
            }
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
                return true;
            }
        }
    }
}
