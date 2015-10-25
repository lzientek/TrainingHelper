using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace TrainingHelper.PcClient.Common.Converter
{
    public class PathToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string path = (string)value;
            string fallback = (string)parameter;
            var img = new BitmapImage();
            if (string.IsNullOrWhiteSpace(path))
            {
                if (string.IsNullOrWhiteSpace(fallback))
                {
                    return img;
                }

                var str = Application.GetResourceStream(new Uri(fallback,UriKind.Relative));
                using (var stream = str.Stream)
                {
                    img.BeginInit();

                    img.StreamSource = stream;
                    img.EndInit();
                }
                return img;
            }
            try
            {
                img.UriSource = new Uri(path);
            }
            catch (Exception)
            {
            }


            return img;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
