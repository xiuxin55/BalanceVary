using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using Microsoft.Practices.Prism.ViewModel;
using Microsoft.Practices.Prism.Commands;
using System.Windows;
using BalanceReport.Views;
using BalanceReport.AccountInfoService;

namespace BalanceReport.ViewModels
{
    public class AccountManageVM:NotificationObject
    {
        private AccountInfoService.AccountInfoServiceClient client = new AccountInfoServiceClient();
        public AccountManageVM()
        {
            AddAccountCommand = new DelegateCommand(AddAccountExecute);
            UpdateAccountCommand = new DelegateCommand(UpdateAccountExecute);
            DeleteAccountCommand = new DelegateCommand(DeleteAccountExecute);
            SearchAccountCommand = new DelegateCommand(SearchAccountExecute);
            CheckCommand = new DelegateCommand<object>(CheckCommandExecute);
            ManyLinkCommand = new DelegateCommand(ManyLinkCommandExecute);
            SearchAccountInfoModel = new AccountInfo();
            SearchAccountInfoModel.CorrelationState = "全部";
            SearchAccountExecute();
        }
        #region 属性
        private AccountInfo _selectedAccountInfoModel;
        /// <summary>
        ///被选中的行 
        /// </summary>
        public AccountInfo SelectedAccountInfoModel
        {
            get { return _selectedAccountInfoModel; }
            set
            {
                _selectedAccountInfoModel = value;
                this.RaisePropertyChanged("SelectedAccountInfoModel");
            }
        }


        private AccountInfo _searchAccountInfoModel;
        /// <summary>
        /// 查询
        /// </summary>
        public AccountInfo SearchAccountInfoModel
        {
            get { return _searchAccountInfoModel; }
            set
            {
                _searchAccountInfoModel = value;
                this.RaisePropertyChanged("SearchAccountInfoModel");
            }
        }
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
        public List<AccountInfo> SelectedItemList { get; set; }
        #endregion
        #region 命令
        public DelegateCommand AddAccountCommand { get; set; }
        public DelegateCommand UpdateAccountCommand { get; set; }
        public DelegateCommand DeleteAccountCommand { get; set; }
        public DelegateCommand SearchAccountCommand { get; set; }
        public DelegateCommand ManyLinkCommand { get; set; }

        /// <summary>
        /// 复选框命令
        /// </summary>
        public DelegateCommand<object> CheckCommand { get; set; }
        #endregion
        #region 命令执行方法
        private void AddAccountExecute()
        {
            AccountAdd waui = new AccountAdd(true, null);
            waui.ShowDialog();
            SearchAccountExecute();
        }
        private void UpdateAccountExecute()
        {
            if (SelectedAccountInfoModel != null)
            {
                AccountAdd waui = new AccountAdd(false, SelectedAccountInfoModel);
                waui.ShowDialog();
                SearchAccountExecute();
            }
        }
        private void DeleteAccountExecute()
        {
            if (SelectedAccountInfoModel != null && SelectedAccountInfoModel.ID != null)
            {
                if (MessageBox.Show("是否删除", "消息提示", MessageBoxButton.YesNo) == MessageBoxResult.Yes && client.Delete(SelectedAccountInfoModel))
                {
                    MessageBox.Show("删除成功");
                    SearchAccountExecute();
                }
            }
        }
        private void SearchAccountExecute()
        {
            if (SelectedItemList != null)
            {
                SelectedItemList.Clear();
            }
            else
            {
                SelectedItemList = new List<AccountInfo>();
            }
            if (SearchAccountInfoModel == null)
            {
                SearchAccountInfoModel = new AccountInfo();
            }
            if (SearchAccountInfoModel.CorrelationState == "全部")
                 SearchAccountInfoModel.CorrelationState = null;
            AccountInfoList =new ObservableCollection<AccountInfo>( client.Select(SearchAccountInfoModel));
        }
        /// <summary>
        /// 复选框的选中的方法
        /// </summary>
        /// <param name="obj"></param>
        private void CheckCommandExecute(object obj)
        {
            if (obj != null)
            {
                AccountInfo m = obj as AccountInfo;
                if (SelectedItemList.Contains(m))
                {
                    SelectedItemList.Remove(m);
                }
                else
                {
                    SelectedItemList.Add(m);
                }
            }
        }
        private void ManyLinkCommandExecute()
        {
            //AccountLink al = new AccountLink();
            //if (SelectedItemList.Count == 0)
            //{
            //    MessageBox.Show("未选择");
            //    return;
            //}
            //if ((bool)al.ShowDialog())
            //{
            //    foreach (AccountInfo item in SelectedItemList)
            //    {
            //        item.ManagerID = al.ManagerID;
            //        item.WebsiteID = al.WebsiteID;
            //        item.CorrelationState = al.State;
            //    }
            //    if (client.Update(SelectedItemList))
            //    {
            //        MessageBox.Show("关联成功");

            //    }
            //    else
            //    {
            //        MessageBox.Show("关联失败");
            //    }
            //}
            //SearchAccountExecute();
        }
        #endregion
        #region 内部方法

        #endregion
    }
}
