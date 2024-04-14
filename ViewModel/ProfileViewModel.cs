using PlayerClassifier.WPF.Model;
using PlayerClassifier.WPF.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.Drawing;
using System.IO;

namespace PlayerClassifier.WPF.ViewModel
{
    public class ProfileViewModel : ViewModelBase
    {
        private IUserRepository _userRepository;
        private UserModel _currentUser;
        private string _userCargo;
        public bool IsTextBoxEnabled { get; set; }
        public UserModel CurrentUser { get { return _currentUser; } set { _currentUser = value; OnPropertyChanged(nameof(CurrentUser)); } }
        public string UserCargo
        {
            get { return _userCargo; }
            set { _userCargo = value; OnPropertyChanged(nameof(UserCargo)); }
        }
        public ProfileViewModel()
        {
            _userRepository = new UserRepository();
            CurrentUser = new UserModel();
            loadCargo();
            IsTextBoxEnabled = false;
        }
        private void loadCargo()
        {
            var user = _userRepository.GetByUserName(Thread.CurrentPrincipal.Identity.Name);
            if (user != null)
            {
                {
                    UserCargo = user.UserJob;
                };
            }
            else
            {
                //CurrentUser.displayName = "Usuário inválido.";
                Application.Current.Shutdown();
            }
        }
        public void ToggleEditMode()
        {
            IsTextBoxEnabled = !IsTextBoxEnabled;
            OnPropertyChanged(nameof(IsTextBoxEnabled)); // Notifique a mudança
        }
        public void SetProfilePictureFromImageSource(ImageSource imageSource)
        {
            if (imageSource == null)
                return;

            // Converter o ImageSource em Bitmap
            Bitmap bitmap = ImageSourceToBitmap(imageSource);

            // Atribuir o Bitmap ao campo profilePicture do CurrentUser
            //CurrentUser.profilePicture = bitmap;

            // Notificar a mudança na propriedade do CurrentUser (se necessário)
            OnPropertyChanged(nameof(CurrentUser));
        }

        private Bitmap ImageSourceToBitmap(ImageSource imageSource)
        {
            Bitmap bitmap = null;

            if (imageSource != null)
            {
                using (MemoryStream stream = new MemoryStream())
                {
                    BitmapEncoder encoder = GetBitmapEncoderFromImageSource(imageSource);
                    if (encoder != null)
                    {
                        encoder.Frames.Add(BitmapFrame.Create(imageSource as BitmapSource));
                        encoder.Save(stream);
                        bitmap = new Bitmap(stream);
                        Console.WriteLine($"Bitmap convertido: {bitmap}");
                    }
                }
            }

            return bitmap;
        }

        private BitmapEncoder GetBitmapEncoderFromImageSource(ImageSource imageSource)
        {
            if (imageSource is BitmapSource bitmapSource)
            {
                // Obter o formato do arquivo com base na extensão da imagem (se disponível)
                string fileExtension = GetImageFileExtension(imageSource);

                if (!string.IsNullOrEmpty(fileExtension))
                {
                    switch (fileExtension.ToLower())
                    {
                        case ".png":
                            return new PngBitmapEncoder();
                        case ".jpg":
                        case ".jpeg":
                            return new JpegBitmapEncoder();
                        // Adicione outros formatos de imagem conforme necessário
                        default:
                            return null;
                    }
                }
            }

            return null;
        }

        private string GetImageFileExtension(ImageSource imageSource)
        {
            if (imageSource is BitmapImage bitmapImage && !string.IsNullOrEmpty(bitmapImage.UriSource?.AbsolutePath))
            {
                string filePath = bitmapImage.UriSource.AbsolutePath;
                return Path.GetExtension(filePath);
            }

            return null;
        }
    }
}
