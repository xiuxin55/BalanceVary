using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace BalanceDataSync.Converters
{
    public class FileStateConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int state;

            if(!int.TryParse(value.ToString(), out state)) { return null; }

            switch (state)
            {
                case 0:
                    return "上传成功";

                case 1:
                    return "计算成功";
                case 2:
                    return "计算失败";
                default:
                    return null;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
