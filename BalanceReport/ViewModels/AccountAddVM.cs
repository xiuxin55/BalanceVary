using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Prism.ViewModel;
using Microsoft.Practices.Prism.Commands;
using System.Windows;
using System.Collections.ObjectModel;
using WSBalanceClient.AccountInfoService;
using WSBalanceClient;
namespace BalanceReport.ViewModels
{
    public class AccountAddVM : NotificationObject
    {
       
        public AccountAddVM(bool IsAdd)
        {
            OkAccountCommand = new DelegateCommand(OkAccountExecute);
            CancelAccountCommand = new DelegateCommand(CancelAccountAccountExecute);
            AddAccountInfo = new AccountInfo();
            this.IsAdd = IsAdd;

        }
        #region 属性
        private bool IsAdd = false;
        private AccountInfo _addAccountInfo;
        /// <summary>
        /// 被选中的行
        /// </summary>
        public AccountInfo AddAccountInfo
        {
            get { return _addAccountInfo; }
            set
            {
                _addAccountInfo = value;
                this.RaisePropertyChanged("AddAccountInfo");
            }
        }
        public AccountInfo OldAccountInfo { get; set; }
        public BalanceReport.Views.AccountAdd AccountAddUI { get; set; }
        private ObservableCollection<AccountInfo> _AccountInfoList;
        /// <summary>
        /// 网点集合
        /// </summary>
        public ObservableCollection<AccountInfo> AccountInfoList
        {
            get { return _AccountInfoList; }
            set
            {
                _AccountInfoList = value;
                this.RaisePropertyChanged("AccountInfoList");
            }
        }

        #endregion
        #region 命令
        public DelegateCommand OkAccountCommand { get; set; }
        public DelegateCommand CancelAccountCommand { get; set; }

        #endregion
        #region 命令执行方法
        private void OkAccountExecute()
        {
            if (AddAccountInfo == null || AddAccountInfo.SubAccountNumber == null || AddAccountInfo.AccountID == null || AddAccountInfo.AccountName == null || AddAccountInfo.WebsiteID == null || AddAccountInfo.AccountType == null
                || AddAccountInfo.ManagerID == null)
            {
                MessageBox.Show("所有内容均不能为空");
                return;
            }
            if (IsAdd)
            {
                AddAccountInfo.ID = Guid.NewGuid().ToString();
                AccountInfo temp = new AccountInfo();
                temp.AccountID = AddAccountInfo.AccountID;
                temp.SubAccountNumber = AddAccountInfo.SubAccountNumber;
                AccountInfo wim = WSAccountInfoService.Instance.Select(temp).FirstOrDefault();
                if (wim.ID != null)
                {
                    MessageBox.Show("该账号+子账号已存在");
                    if (AccountAddUI != null)
                    {
                        AccountAddUI.Close();

                    }
                    return;
                }
                if (WSAccountInfoService.Instance.Add(AddAccountInfo))
                {
                    MessageBox.Show("新增成功");
                    if (AccountAddUI != null)
                    {
                        AccountAddUI.Close();
                    }
                }
                else
                {
                    MessageBox.Show("新增失败");
                }
            }
            else
            {
                if (WSAccountInfoService.Instance.Update(AddAccountInfo))
                {
                    MessageBox.Show("修改成功");
                    if (AccountAddUI != null)
                    {
                        AccountAddUI.Close();
                    }
                }
                else
                {
                    MessageBox.Show("修改失败");
                }
            }

        }
        private void CancelAccountAccountExecute()
        {
            if (AccountAddUI != null)
            {
                AccountAddUI.Close();
            }
        }

        #endregion
        #region 内部方法

        #endregion
    }
}
