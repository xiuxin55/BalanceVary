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

namespace BalanceReport.Views
{
    /// <summary>
    /// ManagerAdd.xaml 的交互逻辑
    /// </summary>
    public partial class ImportSelectDate : MetroWindow
    {
        public ImportSelectDate()
        {
            InitializeComponent();
            this.datePicker_import.DisplayDate = DateTime.Now;

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
            if (this.datePicker_import.SelectedDate == null)
            {
                MessageBox.Show("未选择日期");
                return;
            }
            else
            {
                ImportTime =DateTime.Parse( this.datePicker_import.SelectedDate.Value.ToString("yyyy-MM-dd"));
            }
            this.DialogResult = true;
        }

        public DateTime ImportTime { get; set; }



    }
}
