using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace PersonGold.Tools
{
    public class TimeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            DateTime? dtime = value as DateTime?;
            if (dtime != null)
            {
                return dtime.Value.ToString("yyyy年MM月dd日");
            }
            return null;
           
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class TimeToyyyyMMConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            DateTime? dtime = value as DateTime?;
            if (dtime != null)
            {
                return dtime.Value.ToString("yyyy年MM月");
            }
            return null;

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
