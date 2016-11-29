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
using MahApps.Metro.Controls;
using Common.Client;
using PersonGold.Views;

namespace PersonGold
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class PersonGoldWindow : MetroWindow
    {
        public PersonGoldWindow()
        {
            InitializeComponent();
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

        private void PersonInfoImportButton_Click(object sender, RoutedEventArgs e)
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
                WSBalanceClient.Helper.UploadFile.Upload(op.FileName, FileType.PGPersonInfo ); ;
            }
        }
        List<int> CacheUC = new List<int>();
        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TabControl tb = sender as TabControl;
            if (tb == null || CacheUC.Contains(tb.SelectedIndex))
            {
                return;
            }
            TabItem ti = tb.SelectedItem as TabItem;
            switch (tb.SelectedIndex)
            {
                case 0:
                    ti.Content = new PGPersonInfoManage();
                    CacheUC.Add(tb.SelectedIndex);
                    break;
                case 1:
                   
                    break;
                case 2:
                    
                    break;
                case 3:
                    
                    break;
                case 4:
                   
                    break;
                default:
                    break;
            }
        }

        private void DebitCardImportButton_Click(object sender, RoutedEventArgs e)
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
                WSBalanceClient.Helper.UploadFile.Upload(op.FileName, FileType.PGDebitCardInfo, s.ImportTime);
            }
        }
    }
}
