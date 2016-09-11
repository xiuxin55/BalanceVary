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
using System.Web;
using System.Reflection;
using System.Collections.ObjectModel;
using System.Threading;
using BalanceReport.ViewModels;
using MahApps.Metro.Controls;

namespace BalanceReport.Views
{
    /// <summary>
    /// ReportUserControl.xaml 的交互逻辑
    /// </summary>
    public partial class ReportUserControl : TransitioningContentControl
    {
        private ReportUserControlVM VM;
        public ReportUserControl()
        {
            InitializeComponent();
        }
    }
}
