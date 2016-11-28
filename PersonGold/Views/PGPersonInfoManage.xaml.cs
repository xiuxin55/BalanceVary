using PersonGold.ViewModels;
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

namespace PersonGold.Views
{
    /// <summary>
    /// PGPersonInfoManage.xaml 的交互逻辑
    /// </summary>
    public partial class PGPersonInfoManage : UserControl
    {
        public PGPersonInfoManage()
        {
            InitializeComponent();

            this.DataContext = new PGPersonInfoManageVM();
        }

        private void AddDepartment_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
