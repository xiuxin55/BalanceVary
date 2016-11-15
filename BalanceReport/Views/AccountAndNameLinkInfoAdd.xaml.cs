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
using WSBalanceClient.AccountAndNameLinkInfoService;

namespace BalanceReport.Views
{
    /// <summary>
    /// ManagerAdd.xaml 的交互逻辑
    /// </summary>
    public partial class AccountAndNameLinkInfoAdd : MetroWindow
    {
        public AccountAndNameLinkInfoAdd(bool IsAdd, AccountAndNameLinkInfo MIM)
        {
            InitializeComponent();
            AccountAndNameLinkInfoAddVM wa = new AccountAndNameLinkInfoAddVM(IsAdd);
            wa.AccountAddUI = this;
            if (MIM != null)
            {
                wa.AddAccountAndNameLinkInfo = MIM;
                wa.OldAccountAndNameLinkInfo = new AccountAndNameLinkInfo();
                wa.OldAccountAndNameLinkInfo.AccountID = MIM.AccountID;
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

        //private void textBox4_GotFocus(object sender, RoutedEventArgs e)
        //{
        //    WebsiteSelect ws = new WebsiteSelect();
        //    if ((bool)ws.ShowDialog())
        //    {
        //       // this.textBox4.Text = ws.WSVM.SelectedWebsiteInfoModel.WebsiteID;

        //    }
        //    this.button1.Focus();
        //}

        private void textBox2_GotFocus(object sender, RoutedEventArgs e)
        {
            ManagersSelect ws = new ManagersSelect();
            if ((bool)ws.ShowDialog())
            {
               // this.textBox2.Text = ws.WSVM.SelectedManagersInfoModel.ManagerID;


            }
            this.button1.Focus();
        }




    }
}
