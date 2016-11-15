using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using Microsoft.Practices.Prism.ViewModel;
using Microsoft.Practices.Prism.Commands;
using System.Windows;
using BalanceReport.Views;
using WSBalanceClient.WebsiteInfoService;
using Common;
using WSBalanceClient.CompanyBalanceService;
using Utility;
using WSBalanceClient.AccountBalanceService;
using BalanceReport.LocalModel;
using WSBalanceClient.SystemSetInfoService;
using BalanceReport.Helper;
using WSBalanceClient;
namespace BalanceReport.ViewModels
{
   

    public class CountyCompanyDataGridVM : BaseVM
    {
       
        public CountyCompanyDataGridVM()
        {
            SearchCompanyCommand = new DelegateCommand(SearchCompanyExecute);
            SearchAccountCommand = new DelegateCommand(SearchAccountExecute);
            SearchAccountBalanceModel = new AccountBalance();
            SearchCompanyBalanceoModel = new CompanyBalance();
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
            get { return _selectedWebsiteInfoModel ?? new WebsiteInfo(); ; }
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
            //if (SearchAccountBalanceModel == null)
            //{
            //    SearchAccountBalanceModel = new AccountBalance();
            //}
            SearchAccountBalanceModel.OrderbyColomnName = OrderByColomnHelper.GetOrderByColomn();
            SearchAccountBalanceModel.SubOrderbyColomnName = OrderByColomnHelper.GetSubOrderByColomn();
            SearchAccountBalanceModel.WebsiteID = SelectedWebsiteInfoModel != null ? SelectedWebsiteInfoModel.WebsiteID : null;
            SearchAccountBalanceModel.StartIndex = 1;
            SearchAccountBalanceModel.EndIndex = PageSize;
            SearchAccountBalanceModel.AccountType = -1;
            if (BalanceModeHelper.GetBalanceModeobj().EveryDayBalance)
            {
                AccountBalanceList = new ObservableCollection<AccountBalance>(WSAccountBalanceService.Instance.Select(SearchAccountBalanceModel));
            }
            else
            {
                SearchAccountBalanceModel.StartBalanceTime = SearchAccountBalanceModel.StartBalanceTime ?? DateTime.Parse(DateTime.Now.AddDays(-1).ToShortDateString());
                SearchAccountBalanceModel.EndBalanceTime = SearchAccountBalanceModel.EndBalanceTime ?? DateTime.Parse(DateTime.Now.ToShortDateString());
                 
                AccountBalanceList = new ObservableCollection<AccountBalance>(WSAccountBalanceService.Instance.CallTimeSpanProc(SearchAccountBalanceModel));
                SearchAccountBalanceModel.BalanceTime = SearchAccountBalanceModel.StartBalanceTime;
            }
            Total = WSAccountBalanceService.Instance.SelectCount(SearchAccountBalanceModel);
        }
        private void SearchCompanyExecute()
        {
            Total = 0;
            //if (SearchCompanyBalanceoModel == null)
            //{
            //    SearchCompanyBalanceoModel = new CompanyBalance();
            //}
            
            SearchCompanyBalanceoModel.OrderbyColomnName = OrderByColomnHelper.GetOrderByColomn();
            SearchCompanyBalanceoModel.SubOrderbyColomnName = OrderByColomnHelper.GetSubOrderByColomn();
            SearchCompanyBalanceoModel.WebsiteID = SelectedWebsiteInfoModel!=null ?SelectedWebsiteInfoModel.WebsiteID:null;
            SearchCompanyBalanceoModel.StartIndex = 1;
            SearchCompanyBalanceoModel.EndIndex = PageSize;
            if (BalanceModeHelper.GetBalanceModeobj().EveryDayBalance)
            {
                CompanyBalanceList = new ObservableCollection<CompanyBalance>(WSCompanyBalanceService.Instance.Select(SearchCompanyBalanceoModel));
            }
            else
            {
                SearchCompanyBalanceoModel.StartBalanceTime = SearchCompanyBalanceoModel.StartBalanceTime ?? DateTime.Parse(DateTime.Now.AddDays(-1).ToShortDateString());
                SearchCompanyBalanceoModel.EndBalanceTime = SearchCompanyBalanceoModel.EndBalanceTime ?? DateTime.Parse(DateTime.Now.ToShortDateString());
                 
                CompanyBalanceList = new ObservableCollection<CompanyBalance>(WSCompanyBalanceService.Instance.CallTimeSpanProc(SearchCompanyBalanceoModel));
                SearchCompanyBalanceoModel.BalanceTime = SearchCompanyBalanceoModel.StartBalanceTime;

            }
            Total = WSCompanyBalanceService.Instance.SelectCount(SearchCompanyBalanceoModel);
        }

        private void LoadData()
        {
            try
            {
                WebsiteInfo model = new WebsiteInfo();
                model.Institution = "县行";
                WebsiteInfoList = new ObservableCollection<WebsiteInfo>(WSWebsiteInfoService.Instance.Select(model));
                model.WebsiteName = "全部";
                WebsiteInfoList.Insert(0, model);
                List<SystemSetInfo> setList = new List<SystemSetInfo>(WSBalanceClient.WSSystemSetInfoService.Instance.Select(null));
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
                    CompanyBalanceList = new ObservableCollection<CompanyBalance>(WSCompanyBalanceService.Instance.Select(SearchCompanyBalanceoModel));
                }
                else
                {
                    CompanyBalanceList = new ObservableCollection<CompanyBalance>(WSCompanyBalanceService.Instance.CallTimeSpanProc(SearchCompanyBalanceoModel));
                }
            }
            if (SelectedTabItemIndex == 1)
            {
                SearchAccountBalanceModel.StartIndex = startindex;
                SearchAccountBalanceModel.EndIndex = endindex;
                if (BalanceModeHelper.GetBalanceModeobj().EveryDayBalance)
                {
                    AccountBalanceList = new ObservableCollection<AccountBalance>(WSAccountBalanceService.Instance.Select(SearchAccountBalanceModel));
                }
                else
                {
                    AccountBalanceList = new ObservableCollection<AccountBalance>(WSAccountBalanceService.Instance.CallTimeSpanProc(SearchAccountBalanceModel));
                }
            }
        }
        #endregion
        #region 内部方法

        #endregion
    }
}
