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
using BalanceReport.Dao;
using System.Threading;
using BalanceReport.Views;
using BalanceReport.Common;
using BalanceReport.Models;
using MahApps.Metro.Controls;

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
        /// 导入数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Import_Click(object sender, RoutedEventArgs e)
        {
            
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
            this.DragMove();
        }
        #endregion
        /// <summary>
        /// 导入数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ImportButton_Click(object sender, RoutedEventArgs e)
        {
            ImportSelectDate s = new ImportSelectDate();
            s.txt_Remark.Visibility = Visibility.Collapsed;
            if ((bool)s.ShowDialog()==false )
            {
                return;
            }
            OpenFileDialog op = new OpenFileDialog();
            if ((bool)op.ShowDialog())
            {
                this.WebsiteManageTab.IsSelected = true;
                CommonData.Instance.ExcelContentType = 0;
                Thread th = new Thread(new ParameterizedThreadStart(ThreadImport));
                th.Start(op.FileName);
                this.ImportButton.IsEnabled = false;
                this.ManagersImportButton.IsEnabled = false;
                this.LinkImportButton.IsEnabled = false;
            }
        }
        private void ThreadImport(object filename)
        {
            int result = 0;
            List<ImportDataModel> value ;
            if (CommonData.Instance.ExcelContentType == 0)
            {
                value=ImportDataDao.Instance.ImportData(filename.ToString(), out result);
            }
            else
            {
                value = ImportDataDao.Instance.MonthImportData(filename.ToString(), out result);
            }
            if (value != null)
            {
                string mess = "导入成功";
                if (result > 0)
                {
                    mess = mess + "\n 1、存在未关联账户，请关联";
                }
                string str;
                int i = 0;
                str = ImportDataDao.Instance.NotHandleWebsiteInfo(out i);
                if (i > 0)
                {
                    mess = mess + "\n 2、有未知网点，请到 " + str + " 文件中查看";
                }

                MessageBox.Show(mess);
            }
            else
            {
                //MessageBox.Show("导入失败,数据库连接失败");
            }
            this.Dispatcher.Invoke(new Action(delegate()
            {
                this.ImportButton.IsEnabled = true;
                this.ManagersImportButton.IsEnabled = true;
                this.LinkImportButton.IsEnabled = true;
            }));
            CommonData.Instance.ImportTime = null;
        }
        private void menuButton_Click(object sender, RoutedEventArgs e)
        {
            Menu.IsOpen = true;
        }

        private void ManagersImportButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            if ((bool)op.ShowDialog())
            {
                this.WebsiteManageTab.IsSelected = true;
                Thread th = new Thread(new ParameterizedThreadStart(ManagerImportThread));
                th.Start(op.FileName);
                this.ImportButton.IsEnabled = false;
                this.ManagersImportButton.IsEnabled = false;
                this.LinkImportButton.IsEnabled = false;
            }
        }
        private void ManagerImportThread(object filename)
        {

            if (ImportDataDao.Instance.ManagersImportData(filename.ToString()) != null)
            {
                string mess = "导入成功";
                int result = 0;
                string str = ImportDataDao.Instance.ManagerNotHandleWebsiteInfo(out result);
                if (result > 0)
                {
                    mess = mess + "，客户经理表中存在未知网点，请到 " + str + " 文件中查看";
                }
                MessageBox.Show(mess);
            }
            else
            {
                MessageBox.Show("导入失败,数据库连接失败");
            }
            this.Dispatcher.Invoke(new Action(delegate()
            {
                this.ImportButton.IsEnabled = true;
                this.ManagersImportButton.IsEnabled = true;
                this.LinkImportButton.IsEnabled = true;
            }));
        }
        private void MonthImportButton_Click(object sender, RoutedEventArgs e)
        {
            ImportSelectDate s = new ImportSelectDate();
            s.txt_Remark.Visibility = Visibility.Visible ;
            if ((bool)s.ShowDialog() == false)
            {
                return;
            }
            OpenFileDialog op = new OpenFileDialog();
            if ((bool)op.ShowDialog())
            {
                CommonData.Instance.ExcelContentType = 1;
                this.WebsiteManageTab.IsSelected = true;
                Thread th = new Thread(new ParameterizedThreadStart(ThreadImport));
                th.Start(op.FileName);
                this.ImportButton.IsEnabled = false;
                this.LinkImportButton.IsEnabled = false;
                this.ManagersImportButton.IsEnabled = false;
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
                this.WebsiteManageTab.IsSelected = true;
                Thread th = new Thread(new ParameterizedThreadStart(LinkImportThread));
                th.Start(op.FileName);
                this.ImportButton.IsEnabled = false;
                this.LinkImportButton.IsEnabled = false;
                this.ManagersImportButton.IsEnabled = false;
            }
        }
        private void LinkImportThread(object filename)
        {

            if (ImportDataDao.Instance.LinkImportData(filename.ToString()) != null)
            {
                string mess = "导入成功";
                int result = 0;
                string str = ImportDataDao.Instance.ManagerNotHandleWebsiteInfo(out result);
                if (result > 0)
                {
                    mess = mess + "，客户经理表中存在未知网点，请到 " + str + " 文件中查看";
                }
                MessageBox.Show(mess);
            }
            else
            {
                MessageBox.Show("导入失败,数据库连接失败");
            }
            this.Dispatcher.Invoke(new Action(delegate()
            {
                this.ImportButton.IsEnabled = true;
                this.LinkImportButton.IsEnabled = true;
                this.ManagersImportButton.IsEnabled = true;
            }));
        }
    }
}
