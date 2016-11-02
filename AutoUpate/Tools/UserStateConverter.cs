using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace UserAuthorization.Tools
{
    public class UserStateConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int state = value == null ? 0 : (int)value;
            if (state ==0)
            {
                return "正常";
            }
            else if(state == 1)
            {
                return "已删除";
            }
            else
            {
                return "已锁定";
            }

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
  
}
