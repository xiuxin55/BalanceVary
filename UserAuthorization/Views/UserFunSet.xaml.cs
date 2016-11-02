
using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace UserAuthorization
{
    /// <summary>
    /// FunSetForm.xaml 的交互逻辑
    /// </summary>
    public partial class UserFunSet : MetroWindow
    {
        public UserFunSet()
        {
            InitializeComponent();
            VM = new UserFunSetVM();
            VM.Owner = this;
            this.DataContext = VM;
        }
        public UserFunSetVM VM { get; set; }
    }
}
