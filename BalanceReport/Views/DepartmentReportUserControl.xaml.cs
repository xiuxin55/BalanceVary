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
using BalanceReport.Views.ReportDataGrid;

namespace BalanceReport.Views
{
    /// <summary>
    /// ReportUserControl.xaml 的交互逻辑
    /// </summary>
    public partial class DepartmentReportUserControl : UserControl
    {
        public DepartmentReportUserControl()
        {
            InitializeComponent();
        }
        Dictionary<int, UserControl> CacheUC = new Dictionary<int, UserControl>();
        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TabControl tc = sender as TabControl; 
            if (tc == null)
            {
                return;
            }
            TabItem ti = tc.SelectedItem as TabItem;
            if (tc.SelectedIndex == 0)
            {
                if (!CacheUC.Keys.Contains(tc.SelectedIndex))
                {
                    ti.Content = CacheUC[tc.SelectedIndex] = new DepartmentDataGrid();
                }
                this.page.DataContext = CacheUC[tc.SelectedIndex].DataContext;
            }
            if (tc.SelectedIndex == 1)
            {
                if (!CacheUC.Keys.Contains(tc.SelectedIndex))
                {
                    ti.Content = CacheUC[tc.SelectedIndex] = new CustomerManagerDataGrid();
                }
                this.page.DataContext = CacheUC[tc.SelectedIndex].DataContext;
            }
            if (tc.SelectedIndex == 2)
            {
              //  this.page.DataContext = this.CityWebsiteDataGrid.DataContext;
            }
            if (tc.SelectedIndex == 3)
            {
               
            }
            if (tc.SelectedIndex == 4)
            {
                
            }
            if (tc.SelectedIndex == 5)
            {
               
            }
        }
    }
}
