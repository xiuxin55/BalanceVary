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
using System.IO;
using WSBalanceClient;

namespace PersonGold.Views
{
    /// <summary>
    /// ManagerAdd.xaml 的交互逻辑
    /// </summary>
    public partial class ImportTemplate : MetroWindow
    {
        
        public ImportTemplate()
        {
            InitializeComponent();
           

        }
        public string DateStr { get; set; }

        #region 窗口基本按键方法
        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
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
        /// 确定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Confirm_Click(object sender, RoutedEventArgs e)
        {
            //if (this.datePicker_import.SelectedDate == null)
            //{
            //    MessageBox.Show("未选择日期");
            //    return;
            //}
            //else
            //{
            //    ImportTime =DateTime.Parse( this.datePicker_import.SelectedDate.Value.ToString("yyyy-MM-dd"));
            //}
            //this.DialogResult = true;
        }

        public DateTime ImportTime { get; set; }

        private void SaveDownloadFile(string filename)
        {
            System.Windows.Forms.FolderBrowserDialog folder = new System.Windows.Forms.FolderBrowserDialog();
            if (folder.ShowDialog() != System.Windows.Forms.DialogResult.OK)
            {
                return;
            }
            string savepath = folder.SelectedPath;
            byte[] filebytes=WSServiceFile.Instance.DownLoadTemplateFile(filename);
            if (filebytes==null || filebytes.Length==0)
            {
                MessageBox.Show("模版不存在");
                return;
            }
            FileStream fs = null;

            try
            {
                if (File.Exists(savepath + "\\" + filename))
                {
                    fs = File.Create(savepath + "\\" + filename.Substring(0, filename.Length - 4)+DateTime.Now.ToString("yyyyMMddhhmmss")+".xls");
                }
                else
                {
                    fs = File.Create(savepath + "\\" + filename);
                }
                
                fs.Write(filebytes, 0, filebytes.Length);
                MessageBox.Show("下载完成");
            }
            catch (Exception ex)
            {
                MessageBox.Show("同名文件正在打开，请先关闭");
            }
            finally
            {

                if (fs != null)
                {
                    fs.Close();
                }
            }
        }

        private void btn_staff_Click(object sender, RoutedEventArgs e)
        {
            SaveDownloadFile("人员导入模版.xls");
        }

        private void btn_debtcard_Click(object sender, RoutedEventArgs e)
        {
            SaveDownloadFile("储蓄类模版.xls");
        }

        private void btn_Insurance_Click(object sender, RoutedEventArgs e)
        {
            SaveDownloadFile("保险类模版.xls");
        }

        private void btn_creditcard_Click(object sender, RoutedEventArgs e)
        {
            SaveDownloadFile("信用卡类模版.xls");
        }
        private void btn_cardbasedata_Click(object sender, RoutedEventArgs e)
        {
            SaveDownloadFile("储蓄类基础数据模版.xls");
        }
        
    }
}
