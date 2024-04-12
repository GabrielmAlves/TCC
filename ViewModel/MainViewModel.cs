using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using FontAwesome.Sharp;
using PlayerClassifier.WPF.Model;
using PlayerClassifier.WPF.Repositories;

namespace PlayerClassifier.WPF.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private ViewModelBase _currentChildView;
        private string _childViewName;
        private IconChar _icon;
        private UserAccountModel __currentUserAccount;
        private IUserRepository userRepository;
        
        public UserAccountModel CurrentUserAccount { get { return __currentUserAccount; } set { __currentUserAccount = value; OnPropertyChanged(nameof(CurrentUserAccount)); } }

        public ViewModelBase CurrentChildView 
        { 
            get
            { 
                return _currentChildView; 
            } 
            set 
            { 
                _currentChildView = value;
                OnPropertyChanged(nameof(CurrentChildView));
            } 
        }
        public string ChildViewName
        {
            get
            {
                return _childViewName;
            }
            set
            {
                _childViewName = value;
                OnPropertyChanged(nameof(ChildViewName));
            }
        }
        public IconChar Icon
        {
            get
            {
                return _icon;
            }
            set
            {
                _icon = value;
                OnPropertyChanged(nameof(Icon));
            }
        }


        public ICommand ShowHomeViewCommand { get; }
        public ICommand ShowClassifyViewCommand { get; }
        public ICommand ShowCompareViewCommand { get; }
        public ICommand ShowHistoryViewCommand { get; }
        public ICommand ShowObservationViewCommand { get; }
        //public ICommand ShowProfileViewCommand { get; }


        public MainViewModel()
        {
            userRepository = new UserRepository();
            CurrentUserAccount = new UserAccountModel();

            ShowHomeViewCommand = new ViewModelCommand(ExecuteShowHomeViewCommand);
            ShowClassifyViewCommand = new ViewModelCommand(ExecuteShowClassifyViewCommand);
            ShowCompareViewCommand = new ViewModelCommand(ExecuteShowCompareViewCommand);
            ShowHistoryViewCommand = new ViewModelCommand(ExecuteShowHistoryViewCommand);
            ShowObservationViewCommand = new ViewModelCommand(ExecuteShowObservationViewCommand);
            //ShowProfileViewCommand = new ViewModelCommand(ExecuteShowProfileViewCommand);
            ExecuteShowHomeViewCommand(null);

            //loadCurrentUserData();
        }

        //private void ExecuteShowProfileViewCommand(object obj)
        //{
        //    CurrentChildView = new ProfileViewModel();
        //    ChildViewName = "Seu perfil";
        //    Icon = IconChar.UserCircle;
        //}

        private void ExecuteShowObservationViewCommand(object obj)
        {
            CurrentChildView = new ObservationViewModel();
            ChildViewName = "Em observação";
            Icon = IconChar.Binoculars;
        }

        private void ExecuteShowHistoryViewCommand(object obj)
        {
            CurrentChildView = new HistoryViewModel();
            ChildViewName = "Histórico";
            Icon = IconChar.History;
        }

        private void ExecuteShowCompareViewCommand(object obj)
        {
            CurrentChildView = new CompareViewModel();
            ChildViewName = "Compare";
            Icon = IconChar.FutbolBall;
        }

        private void ExecuteShowClassifyViewCommand(object obj)
        {
            CurrentChildView = new ClassifyPlayerViewModel();
            ChildViewName = "Classificar jogador";
            Icon = IconChar.FutbolBall;
        }

        private void ExecuteShowHomeViewCommand(object obj)
        {
            CurrentChildView = new HomeViewModel();
            ChildViewName = "Home";
            Icon = IconChar.Home;
        }

        }
    }
