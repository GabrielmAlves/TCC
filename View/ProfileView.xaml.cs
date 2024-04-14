using Microsoft.Win32;
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
        public ProfileView()
        {
            InitializeComponent();
        }

        private void btnSelectPicture_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Arquivos csv | *.png;*.jpg;*.jpeg";
            bool? fileOpened = openFileDialog.ShowDialog();

            if (fileOpened == true)
            {
                string path = openFileDialog.FileName;
                string fileName = openFileDialog.SafeFileName;
                imageName.ImageSource = new BitmapImage(new Uri(openFileDialog.FileName));
            } else
            {

            }
        }
    }
}
