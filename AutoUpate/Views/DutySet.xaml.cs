using FundsRegulatoryClient;
using MahApps.Metro.Controls;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace UserAuthorization
{
    /// <summary>
    /// DutySet.xaml 的交互逻辑
    /// </summary>
    public partial class DutySet : MetroWindow
    {
        public DutySet()
        {
            InitializeComponent();
            VM = new DutySetVM();
            VM.Owner = this;
            this.DataContext = VM;
        }
        public DutySetVM VM { get; set; }

        private void btnConfirm_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
