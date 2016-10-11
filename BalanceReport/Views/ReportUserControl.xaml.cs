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



        private void CityDataGrid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.page.DataContext = this.CityDataGrid.DataContext;
        }

        private void CountyDataGrid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.page.DataContext = this.CountyDataGrid.DataContext;
        }

        private void CityCompanyDataGrid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.page.DataContext = this.CityCompanyDataGrid.DataContext;
        }

        private void CountyCompanyDataGrid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.page.DataContext = this.CountyCompanyDataGrid.DataContext;
        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TabControl tc = sender as TabControl;
            if(tc.SelectedIndex==0)
            {
                this.page.DataContext = this.CityDataGrid.DataContext;
            }
            if (tc.SelectedIndex == 1)
            {
                this.page.DataContext = this.CountyDataGrid.DataContext;
            }
            if (tc.SelectedIndex == 2)
            {
                this.page.DataContext = this.CityWebsiteDataGrid.DataContext;
            }
            if (tc.SelectedIndex == 3)
            {
                this.page.DataContext = this.CountyWebsiteDataGrid.DataContext;
            }
            if (tc.SelectedIndex == 4)
            {
                this.page.DataContext = this.CityCompanyDataGrid.DataContext;
            }
            if (tc.SelectedIndex == 5)
            {
                this.page.DataContext = this.CountyCompanyDataGrid.DataContext;
            }
        }
    }
}
