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
using BalanceReport.ViewModels;

namespace BalanceReport.WesiteWindow
{
    /// <summary>
    /// WebsiteManage.xaml 的交互逻辑
    /// </summary>
    public partial class WebsiteManage : UserControl
    {
        public WebsiteManage()
        {
            InitializeComponent();
            try
            {
                this.DataContext = new WebsiteManageVM();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

        private void AddWebsite_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
