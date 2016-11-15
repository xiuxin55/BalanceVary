using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using Microsoft.Practices.Prism.ViewModel;
using Microsoft.Practices.Prism.Commands;
using System.Windows;
using BalanceReport.Views;

using Utility;

using WSBalanceClient;
using WSBalanceClient.AccountAndNameLinkInfoService;

namespace BalanceReport.ViewModels
{
    public class AccountAndNameLinkManageVM : BaseVM
    {
      
        public AccountAndNameLinkManageVM()
        {
            AddAccountCommand = new DelegateCommand(AddAccountExecute);
            UpdateAccountCommand = new DelegateCommand(UpdateAccountExecute);
            DeleteAccountCommand = new DelegateCommand(DeleteAccountExecute);
            SearchAccountCommand = new DelegateCommand(SearchAccountExecute);
            CheckCommand = new DelegateCommand<object>(CheckCommandExecute);
   
            SearchAccountAndNameLinkInfoModel = new AccountAndNameLinkInfo();
            SearchAccountExecute();
        }
        #region 属性
        private AccountAndNameLinkInfo _selectedAccountAndNameLinkInfoModel;
        /// <summary>
        ///被选中的行 
        /// </summary>
        public AccountAndNameLinkInfo SelectedAccountAndNameLinkInfoModel
        {
            get { return _selectedAccountAndNameLinkInfoModel; }
            set
            {
                _selectedAccountAndNameLinkInfoModel = value;
                this.RaisePropertyChanged("SelectedAccountAndNameLinkInfoModel");
            }
        }


        private AccountAndNameLinkInfo _searchAccountAndNameLinkInfoModel;
        /// <summary>
        /// 查询
        /// </summary>
        public AccountAndNameLinkInfo SearchAccountAndNameLinkInfoModel
        {
            get { return _searchAccountAndNameLinkInfoModel; }
            set
            {
                _searchAccountAndNameLinkInfoModel = value;
                this.RaisePropertyChanged("SearchAccountAndNameLinkInfoModel");
            }
        }
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
        public List<AccountAndNameLinkInfo> SelectedItemList { get; set; }
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
            AccountAndNameLinkInfoAdd waui = new AccountAndNameLinkInfoAdd(true, null);
            waui.ShowDialog();
            SearchAccountExecute();
        }
        private void UpdateAccountExecute()
        {
            if (SelectedAccountAndNameLinkInfoModel != null)
            {
                AccountAndNameLinkInfoAdd waui = new AccountAndNameLinkInfoAdd(false, SelectedAccountAndNameLinkInfoModel);
                waui.ShowDialog();
                SearchAccountExecute();
            }
        }
        private void DeleteAccountExecute()
        {
            if (SelectedAccountAndNameLinkInfoModel != null && SelectedAccountAndNameLinkInfoModel.ID != null)
            {
                if (MessageBox.Show("是否删除", "消息提示", MessageBoxButton.YesNo) == MessageBoxResult.Yes && WSAccountAndNameLinkInfoService.Instance.Delete(SelectedAccountAndNameLinkInfoModel))
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
                SelectedItemList = new List<AccountAndNameLinkInfo>();
            }
            if (SearchAccountAndNameLinkInfoModel == null)
            {
                SearchAccountAndNameLinkInfoModel = new AccountAndNameLinkInfo();
            }
      
            SearchAccountAndNameLinkInfoModel.StartIndex = 1;
            SearchAccountAndNameLinkInfoModel.EndIndex = PageSize;
            AccountAndNameLinkInfoList =new ObservableCollection<AccountAndNameLinkInfo>(WSAccountAndNameLinkInfoService.Instance.Select(SearchAccountAndNameLinkInfoModel));
            Total = WSAccountAndNameLinkInfoService.Instance.SelectCount(SearchAccountAndNameLinkInfoModel);
        }
        /// <summary>
        /// 复选框的选中的方法
        /// </summary>
        /// <param name="obj"></param>
        private void CheckCommandExecute(object obj)
        {
            if (obj != null)
            {
                AccountAndNameLinkInfo m = obj as AccountAndNameLinkInfo;
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
            //    foreach (AccountAndNameLinkInfo item in SelectedItemList)
            //    {
            //        item.ManagerID = al.ManagerID;
            //        item.WebsiteID = al.WebsiteID;
            //        item.CorrelationState = al.State;
            //    }
            //    if (WSAccountAndNameLinkInfoService.Instance.Update(SelectedItemList))
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

        #region 分页抽象方法
        public override void LoadPageData(int startindex, int endindex)
        {
            SearchAccountAndNameLinkInfoModel.StartIndex = startindex;
            SearchAccountAndNameLinkInfoModel.EndIndex = endindex;
            AccountAndNameLinkInfoList = new ObservableCollection<AccountAndNameLinkInfo>(WSAccountAndNameLinkInfoService.Instance.Select(SearchAccountAndNameLinkInfoModel));
        }
        #endregion
    }
}
