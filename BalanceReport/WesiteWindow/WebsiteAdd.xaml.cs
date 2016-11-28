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
using System.Windows.Shapes;
using BalanceReport.ViewModels;
using MahApps.Metro.Controls;
using WSBalanceClient.WebsiteInfoService;

namespace BalanceReport.WesiteWindow
{
    /// <summary>
    /// WebsiteAdd.xaml 的交互逻辑
    /// </summary>
    public partial class WebsiteAdd : MetroWindow
    {
        public WebsiteAdd(bool IsAdd, WebsiteInfo WIM)
        {
            InitializeComponent();
            WebsiteAddVM wa = new WebsiteAddVM(IsAdd);
            wa.WebsiteAddUI = this;
            if (WIM != null)
            {
                wa.AddWebsiteInfoModel = WIM;
            }
            this.DataContext = wa;
        }
        #region 窗口基本按键方法
        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void mniButton_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void maxButton_Click(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Normal)
                WindowState = WindowState.Maximized;
            else
                WindowState = WindowState.Normal;
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
        #endregion
    }
}
