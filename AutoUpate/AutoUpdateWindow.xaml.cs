﻿
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

namespace AutoUpdate
{
    /// <summary>
    /// AutoUpdateWindow.xaml 的交互逻辑
    /// </summary>
    public partial class AutoUpdateWindow : Window
    {
        public AutoUpdateWindow()
        {
            InitializeComponent();
            AutoUpdateWindowVM VM = new AutoUpdateWindowVM();
            VM.WinOwner = this;
            this.DataContext = VM;
            //if (VM.CheckAutoUpdate())
            //{
            //    this.ShowDialog();
            //}
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
           // this.Close();
        }


    }
}
