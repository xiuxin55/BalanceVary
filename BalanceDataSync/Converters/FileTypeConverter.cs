using Common.Client;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace BalanceDataSync.Converters
{
    public class FileTypeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            object r = value ?? "";
            if (r.ToString() == FileType.Day.ToString())
            {
                return "日数据";
            }
            if (r.ToString() == FileType.Month.ToString())
            {
                return "月数据";
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
