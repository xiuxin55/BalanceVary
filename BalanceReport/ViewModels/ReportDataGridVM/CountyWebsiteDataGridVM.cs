using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using Microsoft.Practices.Prism.ViewModel;
using Microsoft.Practices.Prism.Commands;
using System.Windows;
using BalanceReport.Views;

using Common;
using WSBalanceClient.WebsiteBalanceService;
using Utility;
using BalanceReport.LocalModel;
using WSBalanceClient.SystemSetInfoService;
using BalanceReport.Helper;
using WSBalanceClient;
namespace BalanceReport.ViewModels
{

    public class CountyWebsiteDataGridVM : BaseVM
    {
      
        public CountyWebsiteDataGridVM()
        {
            SearchWebsiteCommand = new DelegateCommand(SearchWebsiteExecute);
            SearchWebsiteBalanceModel = new WebsiteBalance();
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
        private WSBalanceClient.WebsiteInfoService.WebsiteInfo _selectedWebsiteInfoModel;
        /// <summary>
        ///被选中的行 
        /// </summary>
        public WSBalanceClient.WebsiteInfoService.WebsiteInfo SelectedWebsiteInfoModel
        {
            get { return _selectedWebsiteInfoModel??new WSBalanceClient.WebsiteInfoService.WebsiteInfo(); }
            set
            {
                _selectedWebsiteInfoModel = value;
                SearchWebsiteExecute();
                this.RaisePropertyChanged("SelectedWebsiteInfoModel");
            }
        }


        private WebsiteBalance _searchWebsiteBalanceModel;
        /// <summary>
        /// 查询
        /// </summary>
        public WebsiteBalance SearchWebsiteBalanceModel
        {
            get { return _searchWebsiteBalanceModel; }
            set
            {
                _searchWebsiteBalanceModel = value;

                this.RaisePropertyChanged("SearchWebsiteBalanceModel");
            }
        }
        private ObservableCollection<WSBalanceClient.WebsiteInfoService.WebsiteInfo> _websiteInfoList;
        /// <summary>
        /// 网点集合
        /// </summary>
        public ObservableCollection<WSBalanceClient.WebsiteInfoService.WebsiteInfo> WebsiteInfoList
        {
            get { return _websiteInfoList; }
            set
            {
                _websiteInfoList = value;
                this.RaisePropertyChanged("WebsiteInfoList");
            }
        }


        private ObservableCollection<WebsiteBalance> _WebsiteBalanceList;
        /// <summary>
        /// 集合
        /// </summary>
        public ObservableCollection<WebsiteBalance> WebsiteBalanceList
        {
            get { return _WebsiteBalanceList; }
            set
            {
                _WebsiteBalanceList = value;
                this.RaisePropertyChanged("WebsiteBalanceList");
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
        public DelegateCommand SearchWebsiteCommand { get; set; }
        #endregion
        #region 命令执行方法
        private void SearchWebsiteExecute()
        {
            Total = 0;
            //if (SearchWebsiteBalanceModel == null)
            //{
            //    SearchWebsiteBalanceModel = new WebsiteBalance();
            //}
            SearchWebsiteBalanceModel.EndIndex = int.MaxValue;
            SearchWebsiteBalanceModel.OrderbyColomnName = OrderByColomnHelper.GetOrderByColomn();
            SearchWebsiteBalanceModel.SubOrderbyColomnName = OrderByColomnHelper.GetSubOrderByColomn();
            SearchWebsiteBalanceModel.WebsiteID = SelectedWebsiteInfoModel.WebsiteID;
            SearchWebsiteBalanceModel.StartIndex = 1;
            SearchWebsiteBalanceModel.EndIndex = PageSize;
            if (BalanceModeHelper.GetBalanceModeobj().EveryDayBalance)
            {
                WebsiteBalanceList = new ObservableCollection<WebsiteBalance>(WSWebsiteBalanceService.Instance.Select(SearchWebsiteBalanceModel));
            }
            else
            {
                SearchWebsiteBalanceModel.StartBalanceTime = SearchWebsiteBalanceModel.StartBalanceTime ?? DateTime.Parse(DateTime.Now.AddDays(-1).ToShortDateString());
                SearchWebsiteBalanceModel.EndBalanceTime = SearchWebsiteBalanceModel.EndBalanceTime ?? DateTime.Parse(DateTime.Now.ToShortDateString());
                 
                WebsiteBalanceList = new ObservableCollection<WebsiteBalance>(WSWebsiteBalanceService.Instance.CallTimeSpanProc(SearchWebsiteBalanceModel));
                SearchWebsiteBalanceModel.BalanceTime = SearchWebsiteBalanceModel.StartBalanceTime;

            }
            Total = WSWebsiteBalanceService.Instance.SelectCount(SearchWebsiteBalanceModel);
        }

        private void LoadData()
        {
            try
            {
                WSBalanceClient.WebsiteInfoService.WebsiteInfo model = new WSBalanceClient.WebsiteInfoService.WebsiteInfo();
                model.Institution = "县行";
                WebsiteInfoList = new ObservableCollection<WSBalanceClient.WebsiteInfoService.WebsiteInfo>(WSWebsiteInfoService.Instance.Select(model));
                WSBalanceClient.WebsiteInfoService.WebsiteInfo temp = new WSBalanceClient.WebsiteInfoService.WebsiteInfo();
                temp.Institution = "县行";
                temp.WebsiteName = "全部";
                WebsiteInfoList.Insert(0, temp);

               
                List<SystemSetInfo> setList = new List<SystemSetInfo>(WSSystemSetInfoService.Instance.Select(null));
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
            SearchWebsiteBalanceModel.StartIndex = startindex;
            SearchWebsiteBalanceModel.EndIndex = endindex;
            if (BalanceModeHelper.GetBalanceModeobj().EveryDayBalance)
            {
                WebsiteBalanceList = new ObservableCollection<WebsiteBalance>(WSWebsiteBalanceService.Instance.Select(SearchWebsiteBalanceModel));
            }
            else
            {
                WebsiteBalanceList = new ObservableCollection<WebsiteBalance>(WSWebsiteBalanceService.Instance.CallTimeSpanProc(SearchWebsiteBalanceModel));
            }
        }
        #endregion
        #region 内部方法

        #endregion
    }
}
