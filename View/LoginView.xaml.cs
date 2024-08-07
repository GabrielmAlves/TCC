using System;
using System.Windows;
using System.Windows.Input;

namespace PlayerClassifier.WPF.View
{
    public partial class LoginView : Window
    {
        public LoginView()
        {
            InitializeComponent();
            LoadUserName();
        }

        private void Window_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void RememberMeCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            SaveUserName();
        }

        private void RememberMeCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            SaveUserName();
        }

        private void SaveUserName()
        {
            if (checkbox.IsChecked == true)
            {
                Properties.Settings.Default.UserName = txtUserName.Text;
            }
            else
            {
                Properties.Settings.Default.UserName = "";
            }
            Properties.Settings.Default.Save();
        }

        private void LoadUserName()
        {
            if (!string.IsNullOrEmpty(Properties.Settings.Default.UserName))
            {
                txtUserName.Text = Properties.Settings.Default.UserName;
                checkbox.IsChecked = true;
            }
            else
            {
                txtUserName.Clear();
                checkbox.IsChecked = false;
            }
        }
    }
}
