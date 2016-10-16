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
using BalanceReport.LocalModel;
using BalanceReport.SystemSetInfoService;
using BalanceReport.Helper;

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
            SearchAccountCommand = new DelegateCommand(SearchAccountExecute);
            LoadData();

          //  SearchWebsiteExecute();
        }
        #region 属性
        private DataGridColomnState _ColomnState;
        public DataGridColomnState ColomnState
        {
            get { return _ColomnState; }
            set
            {
                _ColomnState = value;
                RaisePropertyChanged("ColomnState");
            }
           
        }

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

        private BalanceMode _Mode;
        /// <summary>
        /// 余额模式
        /// </summary>
        public BalanceMode Mode
        {
            get { return _Mode; }
            set
            {
                _Mode = value;
                this.RaisePropertyChanged("Mode");
            }
        }
        #endregion
        #region 命令
        public DelegateCommand SearchCompanyCommand { get; set; }
        public DelegateCommand SearchAccountCommand { get; set; }
        #endregion
        #region 命令执行方法
        private void SearchAccountExecute()
        {
            Total = 0;
            if (SearchAccountBalanceModel == null)
            {
                SearchAccountBalanceModel = new AccountBalance();
            }
        

            SearchAccountBalanceModel.OrderbyColomnName = OrderByColomnHelper.GetOrderByColomn();
            SearchAccountBalanceModel.SubOrderbyColomnName = OrderByColomnHelper.GetSubOrderByColomn();
            SearchAccountBalanceModel.WebsiteID = SelectedWebsiteInfoModel.WebsiteID;
            SearchAccountBalanceModel.StartIndex = 1;
            SearchAccountBalanceModel.EndIndex = PageSize;
            SearchAccountBalanceModel.AccountType = -1;
            if (BalanceModeHelper.GetBalanceModeobj().EveryDayBalance)
            {
                AccountBalanceList = new ObservableCollection<AccountBalance>(clientAccountBalance.Select(SearchAccountBalanceModel));
            }
            else
            {
                SearchAccountBalanceModel.StartBalanceTime = SearchAccountBalanceModel.StartBalanceTime ?? DateTime.Parse(DateTime.Now.AddDays(-1).ToShortDateString());
                SearchAccountBalanceModel.EndBalanceTime = SearchAccountBalanceModel.EndBalanceTime ?? DateTime.Parse(DateTime.Now.ToShortDateString());
                    
                AccountBalanceList = new ObservableCollection<AccountBalance>(clientAccountBalance.CallTimeSpanProc(SearchAccountBalanceModel));
            }
            
            Total = clientAccountBalance.SelectCount(SearchAccountBalanceModel);
        }
        private void SearchCompanyExecute()
        {
            if (SearchCompanyBalanceoModel == null)
            {
                SearchCompanyBalanceoModel = new CompanyBalance();
            }
            SearchCompanyBalanceoModel.OrderbyColomnName = OrderByColomnHelper.GetOrderByColomn();
            SearchCompanyBalanceoModel.SubOrderbyColomnName = OrderByColomnHelper.GetSubOrderByColomn();
            SearchCompanyBalanceoModel.WebsiteID = SelectedWebsiteInfoModel.WebsiteID;
            SearchCompanyBalanceoModel.StartIndex = 1;
            SearchCompanyBalanceoModel.EndIndex = PageSize;
            if (BalanceModeHelper.GetBalanceModeobj().EveryDayBalance)
            {
                CompanyBalanceList = new ObservableCollection<CompanyBalance>(clientcompanybalance.Select(SearchCompanyBalanceoModel));
            }
            else
            {
                SearchCompanyBalanceoModel.StartBalanceTime = SearchCompanyBalanceoModel.StartBalanceTime ?? DateTime.Parse(DateTime.Now.AddDays(-1).ToShortDateString());
                SearchCompanyBalanceoModel.EndBalanceTime = SearchCompanyBalanceoModel.EndBalanceTime ?? DateTime.Parse(DateTime.Now.ToShortDateString());    
                CompanyBalanceList = new ObservableCollection<CompanyBalance>(clientcompanybalance.CallTimeSpanProc(SearchCompanyBalanceoModel));
            }
            
            Total = clientcompanybalance.SelectCount(SearchCompanyBalanceoModel);
        }

        private void LoadData()
        {
            try
            {
 
                WebsiteInfo model = new WebsiteInfo();
                model.Institution = "市行";
                WebsiteInfoList = new ObservableCollection<WebsiteInfo>(clientwebsite.Select(model));
                model.WebsiteName="全部";
                WebsiteInfoList.Insert(0, model);
                SystemSetInfoService.SystemSetInfoServiceClient clientSystemSetInfo = new SystemSetInfoServiceClient();
                List<SystemSetInfo> setList = new List<SystemSetInfo>(clientSystemSetInfo.Select(null));
                SystemSetInfo ColomnSet = setList != null ? setList.Find(e => e.SetName.ToLower() == DataGridColomnState.GetSetName().ToLower()) : null;
                ColomnState = ColomnSet != null ? DataGridColomnState.SystemSetInfoToState(ColomnSet) : null;

                Mode = BalanceModeHelper.GetBalanceModeobj();
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
                if (BalanceModeHelper.GetBalanceModeobj().EveryDayBalance)
                {
                    CompanyBalanceList = new ObservableCollection<CompanyBalance>(clientcompanybalance.Select(SearchCompanyBalanceoModel));
                }
                else
                {
                    SearchCompanyBalanceoModel.StartBalanceTime = SearchCompanyBalanceoModel.StartBalanceTime ?? DateTime.Parse(DateTime.Now.AddDays(-1).ToShortDateString());
                    SearchCompanyBalanceoModel.EndBalanceTime = SearchCompanyBalanceoModel.EndBalanceTime ?? DateTime.Parse(DateTime.Now.ToShortDateString());
                    

                    CompanyBalanceList = new ObservableCollection<CompanyBalance>(clientcompanybalance.CallTimeSpanProc(SearchCompanyBalanceoModel));
                }
               
            }
            if (SelectedTabItemIndex == 1)
            {
                SearchAccountBalanceModel.StartIndex = startindex;
                SearchAccountBalanceModel.EndIndex = endindex;
                if (BalanceModeHelper.GetBalanceModeobj().EveryDayBalance)
                {
                    AccountBalanceList = new ObservableCollection<AccountBalance>(clientAccountBalance.Select(SearchAccountBalanceModel));
                }
                else
                {
                    SearchAccountBalanceModel.StartBalanceTime = SearchAccountBalanceModel.StartBalanceTime ?? DateTime.Parse(DateTime.Now.AddDays(-1).ToShortDateString());
                    SearchAccountBalanceModel.EndBalanceTime = SearchAccountBalanceModel.EndBalanceTime ?? DateTime.Parse(DateTime.Now.ToShortDateString());
                    

                    AccountBalanceList = new ObservableCollection<AccountBalance>(clientAccountBalance.CallTimeSpanProc(SearchAccountBalanceModel));
                }
            }
        }
        #endregion
        #region 内部方法

        #endregion
    }
}
