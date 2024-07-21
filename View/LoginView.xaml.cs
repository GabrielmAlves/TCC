using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PlayerClassifier.WPF.View
{
    /// <summary>
    /// Lógica interna para LoginView.xaml
    /// </summary>
    public partial class LoginView : Window
    {
        public LoginView()
        {
            InitializeComponent();
            LoadUserName();
        }

        private void Window_MouseDown (object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed )
            {
                DragMove();
            }
        }

        private void btnMinimize_Click (object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnClose_Click (object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void RememberMeCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if (checkbox.IsChecked == true)
            {
                Properties.Settings.Default.UserName = txtUserName.Text;
                Properties.Settings.Default.Save();
            }
        }

        private void LoadUserName()
        {
            if (!string.IsNullOrEmpty(Properties.Settings.Default.UserName))
            {
                txtUserName.Text = Properties.Settings.Default.UserName;
                checkbox.IsChecked = true;
            }
        }
    }
}
