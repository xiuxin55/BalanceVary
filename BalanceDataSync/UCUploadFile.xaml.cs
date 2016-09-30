using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BalanceDataSync
{
    /// <summary>
    /// UCUploadFile.xaml 的交互逻辑
    /// </summary>
    public partial class UCUploadFile : UserControl
    {
        public UCUploadFile()
        {
            InitializeComponent();
            VM  = new UCUploadFileVM();
            this.DataContext = VM;
        }
        public UCUploadFileVM VM { get; set; }
        private void CheckBox_Click(object sender, RoutedEventArgs e)
        {

            CheckBox cb = sender as CheckBox;
            VM.IsSelectedAll = cb.IsChecked==null? false:cb.IsChecked.Value;
        }
    }
}
