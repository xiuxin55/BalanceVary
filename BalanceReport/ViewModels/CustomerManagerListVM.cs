using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using Microsoft.Practices.Prism.ViewModel;
using Microsoft.Practices.Prism.Commands;
using System.Windows;
using BalanceReport.Views;
using WSBalanceClient.CustomerManagerInfoService;
using WSBalanceClient;
namespace BalanceReport.ViewModels
{
    public class CustomerManagerListVM : NotificationObject
    {
      
        public CustomerManagerListVM()
        {
            AddManagersCommand = new DelegateCommand(AddManagersExecute);
            UpdateManagersCommand = new DelegateCommand(UpdateManagersExecute);
            DeleteManagersCommand = new DelegateCommand(DeleteManagersExecute);
            SearchManagersCommand = new DelegateCommand(SearchManagersExecute);
            LinkAccountCommand = new DelegateCommand(LinkAccountExecute);
            SearchManagersExecute();
        }
        #region 属性
        private CustomerManagerInfo _searchCustomerManagerInfo;
        /// <summary>
        /// 查询
        /// </summary>
        public CustomerManagerInfo SearchCustomerManagerInfo
        {
            get { return _searchCustomerManagerInfo; }
            set
            {
                _searchCustomerManagerInfo = value;
                this.RaisePropertyChanged("SearchCustomerManagerInfo");
            }
        }
        private CustomerManagerInfo _selectedCustomerManagerInfo;
        /// <summary>
        /// 被选中的行
        /// </summary>
        public CustomerManagerInfo SelectedCustomerManagerInfo
        {
            get { return _selectedCustomerManagerInfo; }
            set
            {
                _selectedCustomerManagerInfo = value;
                this.RaisePropertyChanged("SelectedCustomerManagerInfo");
            }
        }
        private ObservableCollection<CustomerManagerInfo> _ManagersInfoList;
        /// <summary>
        /// 网点集合
        /// </summary>
        public ObservableCollection<CustomerManagerInfo> ManagersInfoList
        {
            get { return _ManagersInfoList; }
            set
            {
                _ManagersInfoList = value;
                this.RaisePropertyChanged("ManagersInfoList");
            }
        }

        #endregion
        #region 命令
        public DelegateCommand AddManagersCommand { get; set; }
        public DelegateCommand UpdateManagersCommand { get; set; }
        public DelegateCommand DeleteManagersCommand { get; set; }
        public DelegateCommand SearchManagersCommand { get; set; }
        public DelegateCommand LinkAccountCommand { get; set; }
        
        #endregion
        #region 命令执行方法
        private void AddManagersExecute()
        {
            CustomerManagerAdd waui = new CustomerManagerAdd(true, null);
            waui.ShowDialog();
            SearchManagersExecute();
        }
        private void UpdateManagersExecute()
        {
            if (SelectedCustomerManagerInfo != null)
            {
                CustomerManagerAdd waui = new CustomerManagerAdd(false, SelectedCustomerManagerInfo);
                waui.ShowDialog();
                SearchManagersExecute();
            }
        }
        private void DeleteManagersExecute()
        {
            if (SelectedCustomerManagerInfo != null && SelectedCustomerManagerInfo.ID != null)
            {
                if (MessageBox.Show("是否删除", "消息提示", MessageBoxButton.YesNo) == MessageBoxResult.Yes && WSCustomerManagerInfoService.Instance.Delete(SelectedCustomerManagerInfo))
                {
                    MessageBox.Show("删除成功");
                    SearchManagersExecute();
                }
            }
        }
        private void SearchManagersExecute()
        {
            if (SearchCustomerManagerInfo == null)
            {
                SearchCustomerManagerInfo = new CustomerManagerInfo();
            }
            ManagersInfoList =new ObservableCollection<CustomerManagerInfo>( WSCustomerManagerInfoService.Instance.Select(SearchCustomerManagerInfo));
        }
        private void LinkAccountExecute()
        {

        }
        #endregion
        #region 内部方法

        #endregion
    }
}
