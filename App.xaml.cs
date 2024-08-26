using System.Configuration;
using System.Data;
using System.Windows;
using PlayerClassifier.WPF.View;
using PlayerClassifier.WPF.ViewModel;

namespace PlayerClassifier.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected void ApplicationStart(object sender, EventArgs e)
        {
            var loginView = new LoginView();
            loginView.Show();
            loginView.IsVisibleChanged += (s, ev) =>
            {
                if (loginView.IsVisible == false && loginView.IsLoaded)
                {
                    var mainView = new MainWindow();
                    mainView.Show();
                    //loginView.Close();
                }
            };

            loginView.Closed += (s, ev) =>
            {
                if (!Application.Current.Windows.OfType<MainWindow>().Any())
                {
                    Application.Current.Shutdown();
                }
            };
        }
    }

}
