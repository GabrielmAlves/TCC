using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace PlayerClassifier.WPF.Converters
{
    public class ByteArrayToImageSourceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is byte[] byteArray)
            {
                try
                {
                    BitmapImage imageSource = new BitmapImage();
                    using (MemoryStream stream = new MemoryStream(byteArray))
                    {
                        stream.Position = 0;
                        imageSource.BeginInit();
                        imageSource.CacheOption = BitmapCacheOption.OnLoad;
                        imageSource.StreamSource = stream;
                        imageSource.EndInit();
                    }
                    return imageSource;
                }
                catch (Exception)
                {
                    return DependencyProperty.UnsetValue; 
                }
            }

            return DependencyProperty.UnsetValue; 
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
