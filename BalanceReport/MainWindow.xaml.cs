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
using Microsoft.Win32;
using System.Threading;
using BalanceReport.Views;
using MahApps.Metro.Controls;
using Common.Client;
using WSBalanceClient.Helper;

namespace BalanceReport
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class BalanceWindow :  MetroWindow
    {
        public BalanceWindow()
        {
            InitializeComponent();
        
        }
        
        /// <summary>
        /// 按日导入数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Import_Click(object sender, RoutedEventArgs e)
        {
            ImportSelectDate s = new ImportSelectDate();
            if ((bool)s.ShowDialog() == false)
            {
                return;
            }
            OpenFileDialog op = new OpenFileDialog();
            if ((bool)op.ShowDialog())
            {
                UploadFile.Upload(op.FileName, FileType.Day, s.ImportTime);
            }
        }
        #region 窗口基本按键方法
        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            //this.Close();
            Environment.Exit(0);
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
            //this.DragMove();
        }
        #endregion
        /// <summary>
        ///按照日导入 导入数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ImportButton_Click(object sender, RoutedEventArgs e)
        {
            ImportSelectDate s = new ImportSelectDate();
            if ((bool)s.ShowDialog() == false)
            {
                return;
            }
            OpenFileDialog op = new OpenFileDialog();
            if ((bool)op.ShowDialog())
            {
                if(op.DefaultExt.ToLower()!= "xls")
                {
                    MessageBox.Show("系统仅支持xls格式");
                    return;
                }
                UploadFile.Upload(op.FileName,FileType.Day,s.ImportTime);
            }
        }
        /// <summary>
        /// 按照月份导入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MonthImportButton_Click(object sender, RoutedEventArgs e)
        {
            ImportSelectDate s = new ImportSelectDate();
            if ((bool)s.ShowDialog() == false)
            {
                return;
            }
            OpenFileDialog op = new OpenFileDialog();
            if ((bool)op.ShowDialog())
            {
                if (!op.SafeFileName.ToLower().EndsWith(".xls"))
                {
                    MessageBox.Show("系统仅支持xls格式");
                    return;
                }
                UploadFile.Upload(op.FileName, FileType.Month, s.ImportTime);
            }
        }

        private void ManagersImportButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            if ((bool)op.ShowDialog())
            {
                //UploadFile.Upload(op.FileName, ServiceFile.FileType.Manager);
            }
        }
       
        /// <summary>
        /// 客户经理关联导入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LinkImportButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            if ((bool)op.ShowDialog())
            {
                if (!op.SafeFileName.ToLower().EndsWith(".xls"))
                {
                    MessageBox.Show("系统仅支持xls格式");
                    return;
                }
                //this.WebsiteManageTab.IsSelected = true;
                UploadFile.Upload(op.FileName, FileType.CustomerManagerLinkAccount); ;
            } 
        }

        private void SystemSetButton_Click(object sender, RoutedEventArgs e)
        {
            SystemSet ss = new SystemSet();
            ss.ShowDialog();
        }

        private void DepartmentImportButton_Click(object sender, RoutedEventArgs e)
        {
           
            OpenFileDialog op = new OpenFileDialog();
            if ((bool)op.ShowDialog())
            {
                if (!op.SafeFileName.ToLower().EndsWith(".xls"))
                {
                    MessageBox.Show("系统仅支持xls格式");
                    return;
                }
                UploadFile.Upload(op.FileName, FileType.CustomerManagerLinkAccount);
            }
        }

        private void AccountAndNameLinkButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            if ((bool)op.ShowDialog())
            {
                if (!op.SafeFileName.ToLower().EndsWith(".xls"))
                {
                    MessageBox.Show("系统仅支持xls格式");
                    return;
                }
                //this.WebsiteManageTab.IsSelected = true;
                UploadFile.Upload(op.FileName, FileType.AccountAndNameLink); ;
            }
        }

        private void ImportTemplate_Click(object sender, RoutedEventArgs e)
        {
            ImportTemplate win = new BalanceReport.ImportTemplate();
            win.Show();
        }

        List<int> CacheUC = new List<int>();
        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TabControl tb = sender as TabControl;
            if (tb==null || CacheUC.Contains(tb.SelectedIndex))
            {
                return;
            }
            TabItem ti = tb.SelectedItem as TabItem;
            switch (tb.SelectedIndex)
            {
                //case 0:
                //    ti.Content = new WebsiteManage();
                //    CacheUC.Add(tb.SelectedIndex);
                //    break;
                case 0:
                    ti.Content = new DepartmentManage();
                    CacheUC.Add(tb.SelectedIndex);
                    break;
                case 1:
                    ti.Content = new CustomerManagerList();
                    CacheUC.Add(tb.SelectedIndex);
                    break;
                case 2:
                    ti.Content = new AccountAndNameLinkManage();
                    CacheUC.Add(tb.SelectedIndex);
                    break;
                case 3:
                    ti.Content = new ReportUserControl();
                    CacheUC.Add(tb.SelectedIndex);
                    break;
                case 4:
                    ti.Content = new DepartmentReportUserControl();
                    CacheUC.Add(tb.SelectedIndex);
                    break;
                default:
                    ti.Content = new DepartmentManage();
                    CacheUC.Add(0);
                    break;
            }
        }
    }
}
