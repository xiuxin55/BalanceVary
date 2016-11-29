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
    /// PGWebistePerformanceInfoManage.xaml 的交互逻辑
    /// </summary>
    public partial class PGWebistePerformanceInfoManage : UserControl
    {
        public PGWebistePerformanceInfoManage()
        {
            InitializeComponent();

            this.DataContext = new PGWebistePerformanceInfoManageVM();
        }

        private void AddDepartment_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
