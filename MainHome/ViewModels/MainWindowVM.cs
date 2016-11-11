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
using System.Windows.Controls.Primitives;
using MahApps.Metro.Controls;
using UserAuthorization.Helper;

namespace MainHome
{
    public class MainWindowVM : NotificationObject
    {
       
        public MainWindowVM()
        {
            CompanyDataCommand = new DelegateCommand(CompanyDataCommandExecute);
            SalaryDataCommand = new DelegateCommand(SalaryDataExecute);
            UserSetCommand = new DelegateCommand(UserSetExecute);
            FunctionSetCommand = new DelegateCommand(FunctionSetExecute);
            LookUploadFileCommand = new DelegateCommand(LookUploadFileExecute);
        }
        
        #region 属性
        public Popup  Menu { get; set; }
        #endregion
        #region 命令
        public DelegateCommand CompanyDataCommand { get; set; }
        public DelegateCommand SalaryDataCommand { get; set; }
        public DelegateCommand UserSetCommand { get; set; }
        public DelegateCommand FunctionSetCommand { get; set; }
        public DelegateCommand LookUploadFileCommand { get; set; }
        
        #endregion
        #region 命令执行方法
        private void CompanyDataCommandExecute()
        {
            if (Menu != null)
            {
                Menu.IsOpen = false;
            }
            if (UserLoginHelper.Instance.CheckAuthrization(typeof(BalanceWindow).FullName))
            {
                BalanceWindow win = new BalanceWindow();
                win.Show();
            }
            else
            {
                MessageBox.Show("权限不足");
            }

        }
        private void SalaryDataExecute()
        {
            if (Menu != null)
            {
                Menu.IsOpen = false;
            }
            if (UserLoginHelper.Instance.CheckAuthrization(typeof(SalaryWindow).FullName))
            {
                SalaryWindow win = new SalaryWindow();
                win.Show();
            }
            else
            {
                MessageBox.Show("权限不足");
            }

        }
        private void UserSetExecute()
        {
            if (Menu != null)
            {
                Menu.IsOpen = false;
            }
            if (UserLoginHelper.Instance.CheckAuthrization(typeof(UserWindow).FullName))
            {
                UserWindow win = new UserWindow();
                win.Show();
            }
            else
            {
                MessageBox.Show("权限不足");
            }

}
        private void FunctionSetExecute()
        {
            if (Menu != null)
            {
                Menu.IsOpen = false;
            }
            if (UserLoginHelper.Instance.CheckAuthrization(typeof(FunctionWindow).FullName))
            {
                FunctionWindow win = new FunctionWindow();
                win.Show();
            }
            else
            {
                MessageBox.Show("权限不足");
            }
        }

        private void LookUploadFileExecute()
        {
            if (Menu != null)
            {
                Menu.IsOpen = false;
            }
            if (UserLoginHelper.Instance.CheckAuthrization(typeof(UpLoadFileWindow).FullName))
            {
                UpLoadFileWindow win = new UpLoadFileWindow();
                win.Show();
            }
            else
            {
                MessageBox.Show("权限不足");
            }
            
        }
        #endregion
        #region 内部方法

        #endregion
    }
}
