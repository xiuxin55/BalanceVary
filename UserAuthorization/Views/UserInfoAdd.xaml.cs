using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
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

namespace UserAuthorization
{
    /// <summary>
    /// UserInfo.xaml 的交互逻辑
    /// </summary>
    public partial class UserInfoAdd : MetroWindow
    {
        public UserInfoAdd()
        {
            InitializeComponent();
            VM = new UserInfoVM();
            VM.OnePassword = this.pwdBox;
            VM.RepeatePassword = this.pwdRepeatBox;
            VM.Owner = this;

            this.DataContext = VM;
        }
       
        public UserInfoVM VM { get; set; }
    }
}
