using Microsoft.Win32;
using PlayerClassifier.WPF.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace PlayerClassifier.WPF.View
{
    /// <summary>
    /// Interação lógica para CompareView.xam
    /// </summary>
    public partial class CompareView : UserControl
    {
        public CompareView()
        {
            InitializeComponent();
        }

        private void btnUploadFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Arquivos csv | *.csv",
                Multiselect = true
            };
            bool? fileOpened = openFileDialog.ShowDialog();

            if (fileOpened == true)
            {
                string[] selectedFiles = openFileDialog.FileNames;
                if (selectedFiles.Length == 2)
                {
                    string filePath1 = selectedFiles[0];
                    string filePath2 = selectedFiles[1];

                    if (DataContext is CompareViewModel viewModel)
                    {
                        MessageBox.Show("Arquivo 1: " + filePath1);
                        MessageBox.Show("Arquivo 2: " + filePath2);
                        viewModel.filesUploaded(filePath1, filePath2);
                    }
                }
                else
                {
                    MessageBox.Show("Por favor, selecione exatamente 2 arquivos CSV.", "Erro na Seleção de Arquivos", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                Console.WriteLine("Erro ao abrir o diálogo de seleção de arquivos.");
            }
        }
    }
}
