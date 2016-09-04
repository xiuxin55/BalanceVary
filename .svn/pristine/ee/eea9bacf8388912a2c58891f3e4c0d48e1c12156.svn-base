using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Windows.Media.Imaging;
using System.IO;

namespace BalanceReport.Tools
{
    public class Byte__ToBitmapImageConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value != null)
            {
                BitmapImage bitImg = new BitmapImage();
                MemoryStream ms = new MemoryStream(value as byte[]);
                bitImg.BeginInit();
                bitImg.StreamSource = ms;
                bitImg.EndInit();
                return bitImg;
            }
            else
            {
                return new NotImplementedException();
            }
        }


        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
