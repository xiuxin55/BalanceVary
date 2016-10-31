using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using Microsoft.Practices.Prism.ViewModel;
using Microsoft.Practices.Prism.Commands;
using System.Windows;
using BalanceReport;
using BalanceReport.Salary;
using UserAuthorization;

namespace MainHome
{
    public class MainWindowVM : NotificationObject
    {
       
        public MainWindowVM()
        {
            CompanyDataCommand = new DelegateCommand(CompanyDataCommandExecute);
            SalaryDataCommand = new DelegateCommand(SalaryDataExecute);
            UserSetCommand = new DelegateCommand(UserSetExecute);
        }
        #region 属性
        #endregion
        #region 命令
        public DelegateCommand CompanyDataCommand { get; set; }
        public DelegateCommand SalaryDataCommand { get; set; }
        public DelegateCommand UserSetCommand { get; set; }

        #endregion
        #region 命令执行方法
        private void CompanyDataCommandExecute()
        {

            BalanceWindow bw = new BalanceWindow();
            bw.Show();
        }
        private void SalaryDataExecute()
        {
            SalaryWindow sw = new SalaryWindow();
            sw.Show();
        }
        private void UserSetExecute()
        {
            UserWindow uw = new UserWindow();
            uw.Show();
        }
        #endregion
        #region 内部方法

        #endregion
    }
}
