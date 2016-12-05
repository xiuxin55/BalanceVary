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

namespace BalanceReport.Salary
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class SalaryWindow : MetroWindow
    {
        public SalaryWindow()
        {
            InitializeComponent();
            VM = new SalaryWindowVM();
            this.DataContext = VM;
        }
        SalaryWindowVM VM;

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
        /// 导入
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
                UploadFile.Upload(op.FileName, FileType.SalaryInfo, s.ImportTime);
            }
        }

        private void CheckBox_Click(object sender, RoutedEventArgs e)
        {
            CheckBox cb = sender as CheckBox;
            VM.IsSelectAll = cb.IsChecked == null ? false : cb.IsChecked.Value;
        }

        private void ImportTemplate_Click(object sender, RoutedEventArgs e)
        {
            ImportTemplate win = new ImportTemplate();
            win.Show();
        }
    }
}
