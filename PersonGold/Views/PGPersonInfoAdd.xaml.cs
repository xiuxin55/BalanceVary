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
using MahApps.Metro.Controls;
using WSBalanceClient.WebsiteInfoService;
using PersonGold.ViewModels;
using WSBalanceClient.PGPersonInfoService;

namespace PersonGold.Views
{
    /// <summary>
    /// WebsiteAdd.xaml 的交互逻辑
    /// </summary>
    public partial class PGPersonInfoAdd : MetroWindow
    {
        public PGPersonInfoAdd(bool IsAdd, PGPersonInfo WIM)
        {
            InitializeComponent();
            PGPersonInfoAddVM wa = new PGPersonInfoAddVM(IsAdd);
            wa.AddUI = this;
            if (WIM != null)
            {
                wa.AddPGPersonInfoModel = WIM;
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
