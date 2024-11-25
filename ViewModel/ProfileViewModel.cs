﻿using PlayerClassifier.WPF.Model;
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
using System.Drawing.Imaging;

namespace PlayerClassifier.WPF.ViewModel
{
    public class ProfileViewModel : ViewModelBase
    {
        private IUserRepository _userRepository;
        private UserAccountModel _currentUser;
        private string _userCargo;
        private byte[] _profilePicture;
        private int _imageUploaded;
        private int _jobChanged;

        public UserAccountModel CurrentUser { get { return _currentUser; } set { _currentUser = value; OnPropertyChanged(nameof(CurrentUser)); } }
        public string UserCargo
        {
            get { return _userCargo; }
            set { _userCargo = value; OnPropertyChanged(nameof(UserCargo)); }
        }
        public byte[] ProfilePicture
        {
            get { return _profilePicture; }
            set { _profilePicture = value; OnPropertyChanged(nameof(_profilePicture)); }
        }

        public int ImageUploaded
        {
            get { return _imageUploaded; }
            set { _imageUploaded = value; OnPropertyChanged(nameof(ImageUploaded)); }
        }

        public int JobChanged
        {
            get { return _jobChanged; }
            set { _jobChanged = value; OnPropertyChanged(nameof(JobChanged)); }
        }

        public ICommand SaveChangesCommand { get; }
        public ProfileViewModel()
        {
            _userRepository = new UserRepository();
            CurrentUser = new UserAccountModel();
            loadCargo();
            loadProfilePicture();
            SaveChangesCommand = new ViewModelCommand(ExecuteSaveChangesCommand, CanExecuteSaveChangesCommand);
        }

        private bool CanExecuteSaveChangesCommand(object obj)
        {
            if (ImageUploaded != 1 || JobChanged != 1)
            {
                return true;
            } else
            {
                return false;
            }
        }

        private void ExecuteSaveChangesCommand(object obj)
        {
            _userRepository.UpdateProfileChanges(UserCargo, Thread.CurrentPrincipal.Identity.Name, CurrentUser);
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
                Application.Current.Shutdown();
            }
        }

        private void loadProfilePicture()
        {
            var user = _userRepository.GetByUserName(Thread.CurrentPrincipal.Identity.Name);
            if (user != null)
            {
                {
                    var userImage = _userRepository.GetProfilePicture(Thread.CurrentPrincipal.Identity.Name);
                    ProfilePicture = userImage.ProfilePicture;
                };
            }
            else
            {
                Application.Current.Shutdown();
            }
        }
        public void SetProfilePictureFromImageSource(ImageSource imageSource)
        {
            if (imageSource == null)
                return;

            string imageFormat = GetImageFileExtension(imageSource);
            Bitmap bitmap = ImageSourceToBitmap(imageSource);
            byte[] imageBytes = bitmapToBytes(bitmap, imageFormat);
            CurrentUser.profilePicture = imageBytes;
            OnPropertyChanged(nameof(CurrentUser));
            _userRepository.AddProfilePicture(imageBytes, CurrentUser, Thread.CurrentPrincipal.Identity.Name);
        }

        private byte[] bitmapToBytes(Bitmap bitmap, string imageFormatExtension)
        {
            ImageFormat imageFormat = null;

            switch (imageFormatExtension.ToLower())
            {
                case ".png":
                    imageFormat = ImageFormat.Png;
                    break;
                case ".jpg":
                case ".jpeg":
                    throw new ArgumentException("Formato de imagem inválido");
                default:
                    throw new ArgumentException("Formato de imagem inválido");
            }

            using (MemoryStream stream = new MemoryStream())
            {
                bitmap.Save(stream, imageFormat);
                return stream.ToArray();
            }
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
