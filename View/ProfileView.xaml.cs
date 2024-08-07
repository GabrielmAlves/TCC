using Microsoft.Win32;
using Org.BouncyCastle.Tls;
using PlayerClassifier.WPF.ViewModel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
//using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PlayerClassifier.WPF.View
{
    /// <summary>
    /// Interação lógica para ProfileView.xam
    /// </summary>
    public partial class ProfileView : UserControl
    {
        public bool IsTextBoxEnabled { get; set; }
        public ProfileView()
        {
            InitializeComponent();
            txtCargo.IsEnabled = false;
        }

        private void btnSelectPicture_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Imagens png | *.png";
            bool? fileOpened = openFileDialog.ShowDialog();

            if (fileOpened == true)
            {
                string path = openFileDialog.FileName;
                string fileName = openFileDialog.SafeFileName;
                //imageName.ImageSource = new BitmapImage(new Uri(openFileDialog.FileName));
                var image = imageName.ImageSource = new BitmapImage(new Uri(openFileDialog.FileName));
                var profileBinding = new ProfileViewModel();
                //profileBinding.ImageUploaded = 1;
                profileBinding.SetProfilePictureFromImageSource(image);
            } else
            {
                Console.WriteLine("erro");
            }
        }

        private void btnEditButton_Click(object sender, RoutedEventArgs e)
        {
            if (txtCargo.IsEnabled)
            {
                txtCargo.IsEnabled = false;
            }
            else
            {
                txtCargo.IsEnabled = true;
                var profileBinding = new ProfileViewModel();
                //profileBinding.JobChanged = 1;
            }
        }

        private void btnSaveChanges_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
