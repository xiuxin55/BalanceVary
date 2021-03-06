﻿using BalanceReport;
using BalanceReport.Salary;
using MahApps.Metro.Controls;
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

namespace MainHome
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            MainWindowVM VM= new MainWindowVM();
            VM.Menu  = this.Menu;
            this.DataContext = VM;
        }

        private void MetroWindow_Closed(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
