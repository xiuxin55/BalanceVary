using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using Microsoft.Practices.Prism.ViewModel;
using Microsoft.Practices.Prism.Commands;
using System.Windows;
using BalanceReport.Views;
using BalanceReport.WebsiteInfoService;
using Common;
using BalanceReport.CompanyBalanceService;
using Utility;
using BalanceReport.AccountBalanceService;

namespace BalanceReport.ViewModels
{
    public class CityCompanyDataGridVM : BaseVM
    {
        private WebsiteInfoService.WebsiteInfoServiceClient clientwebsite = new WebsiteInfoServiceClient();
        private CompanyBalanceServiceClient clientcompanybalance = new CompanyBalanceServiceClient();
        private AccountBalanceService.AccountBalanceServiceClient clientAccountBalance = new AccountBalanceServiceClient();
        public CityCompanyDataGridVM()
        {
            SearchCompanyCommand = new DelegateCommand(SearchCompanyExecute);
            LoadData();
          //  SearchWebsiteExecute();
        }
        #region 属性

        private int _SelectedTabItemIndex;
        public int SelectedTabItemIndex
        {
            get { return _SelectedTabItemIndex; }
            set
            {
                _SelectedTabItemIndex = value;
                if (_SelectedTabItemIndex == 0)
                {
                    SearchCompanyExecute();
                }
                else
                {
                    SearchAccountExecute();
                }
                this.RaisePropertyChanged("SelectedTabItemIndex");
            }
        }
        private WebsiteInfo _selectedWebsiteInfoModel;
        /// <summary>
        ///被选中的行 
        /// </summary>
        public WebsiteInfo SelectedWebsiteInfoModel
        {
            get { return _selectedWebsiteInfoModel; }
            set
            {
                _selectedWebsiteInfoModel = value;
                if (_SelectedTabItemIndex == 0)
                {
                    SearchCompanyExecute();
                }
                else
                {
                    SearchAccountExecute();
                }
                this.RaisePropertyChanged("SelectedWebsiteInfoModel");
            }
        }


        private CompanyBalance _searchCompanyBalanceModel;
        /// <summary>
        /// 查询
        /// </summary>
        public CompanyBalance SearchCompanyBalanceoModel
        {
            get { return _searchCompanyBalanceModel; }
            set
            {
                _searchCompanyBalanceModel = value;
                
                this.RaisePropertyChanged("SearchCompanyBalanceoModel");
            }
        }
        private ObservableCollection<WebsiteInfo> _websiteInfoList;
        /// <summary>
        /// 网点集合
        /// </summary>
        public ObservableCollection<WebsiteInfo> WebsiteInfoList
        {
            get { return _websiteInfoList; }
            set
            {
                _websiteInfoList = value;
                this.RaisePropertyChanged("WebsiteInfoList");
            }
        }


        private ObservableCollection<CompanyBalance> _CompanyBalanceList;
        /// <summary>
        /// 集合
        /// </summary>
        public ObservableCollection<CompanyBalance> CompanyBalanceList
        {
            get { return _CompanyBalanceList; }
            set
            {
                _CompanyBalanceList = value;
                this.RaisePropertyChanged("CompanyBalanceList");
            }
        }
        private ObservableCollection<AccountBalance> _AccountBalanceList;
        /// <summary>
        /// 集合
        /// </summary>
        public ObservableCollection<AccountBalance> AccountBalanceList
        {
            get { return _AccountBalanceList; }
            set
            {
                _AccountBalanceList = value;
                this.RaisePropertyChanged("AccountBalanceList");
            }
        }

        private AccountBalance _searchAccountBalanceModel;
        /// <summary>
        /// 查询
        /// </summary>
        public AccountBalance SearchAccountBalanceModel
        {
            get { return _searchAccountBalanceModel; }
            set
            {
                _searchAccountBalanceModel = value;

                this.RaisePropertyChanged("SearchAccountBalanceModel");
            }
        }
        #endregion
        #region 命令
        public DelegateCommand SearchCompanyCommand { get; set; }
        #endregion
        #region 命令执行方法
        private void SearchAccountExecute()
        {
            Total = 0;
            SearchAccountBalanceModel = new AccountBalance();

            SearchAccountBalanceModel.OrderbyColomnName = "BalanceTime";
            SearchAccountBalanceModel.WebsiteID = SelectedWebsiteInfoModel.WebsiteID;
            SearchAccountBalanceModel.StartIndex = 1;
            SearchAccountBalanceModel.EndIndex = PageSize;
            SearchAccountBalanceModel.AccountType = -1;
            AccountBalanceList = new ObservableCollection<AccountBalance>(clientAccountBalance.Select(SearchAccountBalanceModel));
            Total = clientAccountBalance.SelectCount(SearchAccountBalanceModel);
        }
        private void SearchCompanyExecute()
        {
            SearchCompanyBalanceoModel = new CompanyBalance();
            SearchCompanyBalanceoModel.OrderbyColomnName = "BalanceTime";
            SearchCompanyBalanceoModel.WebsiteID = SelectedWebsiteInfoModel.WebsiteID;
            SearchCompanyBalanceoModel.StartIndex = 1;
            SearchCompanyBalanceoModel.EndIndex = PageSize;
            CompanyBalanceList = new ObservableCollection<CompanyBalance>(clientcompanybalance.Select(SearchCompanyBalanceoModel));
            Total = clientcompanybalance.SelectCount(SearchCompanyBalanceoModel);
        }

        private void LoadData()
        {
            try
            {
                WebsiteInfo model = new WebsiteInfo();
                model.Institution = "市行";
                WebsiteInfoList = new ObservableCollection<WebsiteInfo>(clientwebsite.Select(model));
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(CityCompanyDataGridVM), ex);
            }
        }
     
        public override void LoadPageData(int startindex, int endindex)
        {
            if (SelectedTabItemIndex == 0)
            {
                SearchCompanyBalanceoModel.StartIndex = startindex;
                SearchCompanyBalanceoModel.EndIndex = endindex;
                CompanyBalanceList = new ObservableCollection<CompanyBalance>(clientcompanybalance.Select(SearchCompanyBalanceoModel));
            }
            if (SelectedTabItemIndex == 1)
            {
                SearchAccountBalanceModel.StartIndex = startindex;
                SearchAccountBalanceModel.EndIndex = endindex;
                AccountBalanceList = new ObservableCollection<AccountBalance>(clientAccountBalance.Select(SearchAccountBalanceModel));
            }
        }
        #endregion
        #region 内部方法

        #endregion
    }
}
