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
using BalanceReport.Views.ReportDataGrid;

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



        
        Dictionary<int, UserControl> CacheUC = new Dictionary<int, UserControl>();
        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TabControl tc = sender as TabControl;
            if (tc == null )
            {
                return;
            }
            TabItem ti = tc.SelectedItem as TabItem;
            if (tc.SelectedIndex==0)
            {
                if (!CacheUC.Keys.Contains(tc.SelectedIndex))
                {
                    ti.Content = CacheUC[tc.SelectedIndex] = new CityDataGrid();
                }
                this.page.DataContext = CacheUC[tc.SelectedIndex].DataContext;
            }
            if (tc.SelectedIndex == 1)
            {
                if (!CacheUC.Keys.Contains(tc.SelectedIndex))
                {
                    ti.Content = CacheUC[tc.SelectedIndex] = new CountyDataGrid();
                }
                this.page.DataContext = CacheUC[tc.SelectedIndex].DataContext;
            }
            if (tc.SelectedIndex == 2)
            {
                if (!CacheUC.Keys.Contains(tc.SelectedIndex))
                {
                    ti.Content = CacheUC[tc.SelectedIndex] = new CityWebsiteDataGrid();
                }
                this.page.DataContext = CacheUC[tc.SelectedIndex].DataContext;
            }
            if (tc.SelectedIndex == 3)
            {
                if (!CacheUC.Keys.Contains(tc.SelectedIndex))
                {
                    ti.Content = CacheUC[tc.SelectedIndex] = new CountyWebsiteDataGrid();
                }
                this.page.DataContext = CacheUC[tc.SelectedIndex].DataContext;
            }
            if (tc.SelectedIndex == 4)
            {
                if (!CacheUC.Keys.Contains(tc.SelectedIndex))
                {
                    ti.Content = CacheUC[tc.SelectedIndex] = new CityCompanyDataGrid();
                }
                this.page.DataContext = CacheUC[tc.SelectedIndex].DataContext;
            }
            if (tc.SelectedIndex == 5)
            {
                if (!CacheUC.Keys.Contains(tc.SelectedIndex))
                {
                    ti.Content = ti.Content = CacheUC[tc.SelectedIndex] = new CountyCompanyDataGrid();
                }
                this.page.DataContext = CacheUC[tc.SelectedIndex].DataContext;
            }
        }
    }
}
