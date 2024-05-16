using Microsoft.Win32;
using PlayerClassifier.WPF.ViewModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using PlayerClassifier.WPF.ViewModel;

namespace PlayerClassifier.WPF.View
{
    /// <summary>
    /// Interação lógica para ClassifyView.xam
    /// </summary>
    public partial class ClassifyView : UserControl
    {
        public ClassifyView()
        {
            InitializeComponent();
        }

        private void btnUploadFile_Click (object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Arquivos csv | *.csv";
            bool? fileOpened = openFileDialog.ShowDialog();

            if (fileOpened == true)
            {
                string path = openFileDialog.FileName;
                string fileName = openFileDialog.SafeFileName;
                var classifyBinding = new ClassifyPlayerViewModel();
                classifyBinding.fileWasUploaded(path);
                //MessageBox.Show(path);
                //MessageBox.Show(fileName);
            }
            else
            {
                Console.WriteLine("erro");
            }
        }
    }
}
