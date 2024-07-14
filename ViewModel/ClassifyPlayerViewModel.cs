using PlayerClassifier.WPF.Model;
using PlayerClassifier.WPF.Repositories;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace PlayerClassifier.WPF.ViewModel
{
    public class ClassifyPlayerViewModel : ViewModelBase
    {
        private string _uploadedFile;
        private UserAccountModel _currentUser;
        private IUserRepository _userRepository;
        private int firstTime = 2;
        private string _classificationResult;
        private bool _isModalVisible;
        private bool _isClassifying;

        public string UserFile { get { return _uploadedFile; } set { _uploadedFile = value; OnPropertyChanged(nameof(UserFile)); } }
        public UserAccountModel CurrentUser { get { return _currentUser; } set { _currentUser = value; OnPropertyChanged(nameof(CurrentUser)); } }
        public string ClassificationResult { get { return _classificationResult; } set { _classificationResult = value; OnPropertyChanged(nameof(ClassificationResult)); } }
        public bool IsModalVisible { get { return _isModalVisible; } set { _isModalVisible = value; OnPropertyChanged(nameof(IsModalVisible)); } }
        public bool IsClassifying { get { return _isClassifying; } set { _isClassifying = value; OnPropertyChanged(nameof(IsClassifying)); } }

        public ICommand ClassifyCommand { get; set; }
        public ICommand CloseModalCommand { get; set; }
        public ICommand PutPlayerOnWatchCommand { get; set; }

        public ClassifyPlayerViewModel()
        {
            _userRepository = new UserRepository();
            CurrentUser = new UserAccountModel();
            ClassifyCommand = new ViewModelCommand(async obj => await ExecuteClassifyCommand(obj), CanExecuteClassifyCommand);
            CloseModalCommand = new ViewModelCommand(obj => IsModalVisible = false);
            PutPlayerOnWatchCommand = new ViewModelCommand(obj => PutPlayerOnWatch());
        }

        private bool CanExecuteClassifyCommand(object obj)
        {
            return !IsClassifying && firstTime != 0;
        }

        private async Task ExecuteClassifyCommand(object obj)
        {
            IsClassifying = true;

            var user = _userRepository.GetByUserName(Thread.CurrentPrincipal.Identity.Name);
            if (user != null)
            {
                var userInfo = _userRepository.GetUploadedFile(Thread.CurrentPrincipal.Identity.Name);
                UserFile = userInfo.UploadedFile;
                var classifyPlayerResult = await Task.Run(() => _userRepository.ClassifyPlayer(UserFile));
                ClassificationResult = classifyPlayerResult;
                IsModalVisible = true;
            }

            IsClassifying = false;
        }

        public void LoadFile(string path)
        {
            var user = _userRepository.GetByUserName(Thread.CurrentPrincipal.Identity.Name);
            if (user != null)
            {
                CurrentUser.UploadedFile = path;
                OnPropertyChanged(nameof(CurrentUser));
                _userRepository.AddUploadedFile(path, CurrentUser, Thread.CurrentPrincipal.Identity.Name);
            }
            else
            {
                Application.Current.Shutdown();
            }
        }

        public bool FileWasUploaded(string filePath)
        {
            if (filePath == null)
            {
                return false;
            }
            else
            {
                firstTime = 1;
                LoadFile(filePath);
                return true;
            }
        }

        private void PutPlayerOnWatch()
        {
            string pattern = @"([^\\]+)_dataset";

            Match match = Regex.Match(UserFile, pattern);

            if (match.Success)
            {
                string result = match.Groups[1].Value;
                _userRepository.GetPlayerInfo(result);
            }
            else
            {
                Console.WriteLine("Não foi possível encontrar um match usando o pattern de regex.");
            }
            MessageBox.Show("Jogador colocado em observação!");
        }
    }
}
