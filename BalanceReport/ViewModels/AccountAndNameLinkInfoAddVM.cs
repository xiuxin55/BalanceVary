using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Prism.ViewModel;
using Microsoft.Practices.Prism.Commands;
using System.Windows;
using System.Collections.ObjectModel;
using WSBalanceClient.AccountAndNameLinkInfoService;
using WSBalanceClient;
namespace BalanceReport.ViewModels
{
    public class AccountAndNameLinkInfoAddVM : NotificationObject
    {
      
        public AccountAndNameLinkInfoAddVM(bool IsAdd)
        {
            OkAccountCommand = new DelegateCommand(OkAccountExecute);
            CancelAccountCommand = new DelegateCommand(CancelAccountAccountExecute);
            if (IsAdd)
            {
                AddAccountAndNameLinkInfo = new AccountAndNameLinkInfo();
            }
            
            this.IsAdd = IsAdd;

        }
        #region 属性
        private bool IsAdd = false;
        private AccountAndNameLinkInfo _addAccountAndNameLinkInfo;
        /// <summary>
        /// 被选中的行
        /// </summary>
        public AccountAndNameLinkInfo AddAccountAndNameLinkInfo
        {
            get { return _addAccountAndNameLinkInfo; }
            set
            {
                _addAccountAndNameLinkInfo = value;
                this.RaisePropertyChanged("AddAccountAndNameLinkInfo");
            }
        }
        public AccountAndNameLinkInfo OldAccountAndNameLinkInfo { get; set; }
        public BalanceReport.Views.AccountAndNameLinkInfoAdd AccountAddUI { get; set; }
        private ObservableCollection<AccountAndNameLinkInfo> _AccountAndNameLinkInfoList;
        /// <summary>
        /// 集合
        /// </summary>
        public ObservableCollection<AccountAndNameLinkInfo> AccountAndNameLinkInfoList
        {
            get { return _AccountAndNameLinkInfoList; }
            set
            {
                _AccountAndNameLinkInfoList = value;
                this.RaisePropertyChanged("AccountAndNameLinkInfoList");
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
            if (AddAccountAndNameLinkInfo == null || AddAccountAndNameLinkInfo.AccountID == null ||  AddAccountAndNameLinkInfo.CompanyName == null)
            {
                MessageBox.Show("所有内容均不能为空");
                return;
            }
            if (IsAdd)
            {
                AddAccountAndNameLinkInfo.ID = Guid.NewGuid().ToString();
                AccountAndNameLinkInfo temp = new AccountAndNameLinkInfo();
                temp.AccountID = AddAccountAndNameLinkInfo.AccountID;
                temp.CompanyName = AddAccountAndNameLinkInfo.CompanyName;
                temp.StartIndex = 0;
                temp.EndIndex = int.MaxValue;
                AccountAndNameLinkInfo wim = WSAccountAndNameLinkInfoService.Instance.Select(temp).FirstOrDefault();
                if (wim!=null && wim.ID != null)
                {
                    MessageBox.Show("该关联已存在");
                    if (AccountAddUI != null)
                    {
                        AccountAddUI.Close();

                    }
                    return;
                }
                if (WSAccountAndNameLinkInfoService.Instance.Add(AddAccountAndNameLinkInfo))
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
                if (WSAccountAndNameLinkInfoService.Instance.Update(AddAccountAndNameLinkInfo))
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
