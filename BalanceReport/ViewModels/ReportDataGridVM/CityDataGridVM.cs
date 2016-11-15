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
using WSBalanceClient.ZoneBalanceService;
using Utility;
using BalanceReport.LocalModel;
using WSBalanceClient.SystemSetInfoService;
using BalanceReport.Helper;
using WSBalanceClient.ZoneBalanceService;
using WSBalanceClient;

namespace BalanceReport.ViewModels
{
    public class CityDataGridVM : BaseVM
    {

        public CityDataGridVM()
        {
            SearchZoneCommand = new DelegateCommand(SearchZoneExecute);
            SearchZoneBalanceModel = new ZoneBalance();
            SearchZoneExecute();
            LoadData();
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
       
        private ZoneBalance _selectedWebsiteInfoModel;
        /// <summary>
        ///被选中的行 
        /// </summary>
        public ZoneBalance SelectedWebsiteInfoModel
        {
            get { return _selectedWebsiteInfoModel; }
            set
            {
                _selectedWebsiteInfoModel = value;
                this.RaisePropertyChanged("SelectedWebsiteInfoModel");
            }
        }


        private ZoneBalance _searchZoneBalanceModel;
        /// <summary>
        /// 查询
        /// </summary>
        public ZoneBalance SearchZoneBalanceModel
        {
            get { return _searchZoneBalanceModel; }
            set
            {
                _searchZoneBalanceModel = value;
                this.RaisePropertyChanged("SearchZoneBalanceModel");
            }
        }
        private ObservableCollection<ZoneBalance> _ZoneBalanceList;
        /// <summary>
        /// 集合
        /// </summary>
        public ObservableCollection<ZoneBalance> ZoneBalanceList
        {
            get { return _ZoneBalanceList; }
            set
            {
                _ZoneBalanceList = value;
                this.RaisePropertyChanged("ZoneBalanceList");
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
        public DelegateCommand SearchZoneCommand { get; set; }
        #endregion
        #region 命令执行方法
        private void SearchZoneExecute()
        {
            //if (SearchZoneBalanceModel == null)
            //{
            //    SearchZoneBalanceModel = new ZoneBalance();
            //}
            try
            {
                Total = 0;
                SearchZoneBalanceModel.ZoneType = "市行";
                SearchZoneBalanceModel.OrderbyColomnName = OrderByColomnHelper.GetOrderByColomn();
                SearchZoneBalanceModel.SubOrderbyColomnName = OrderByColomnHelper.GetSubOrderByColomn();
                SearchZoneBalanceModel.StartIndex = 1;
                SearchZoneBalanceModel.EndIndex = PageSize;
                if (BalanceModeHelper.GetBalanceModeobj().EveryDayBalance)
                {
                    ZoneBalanceList = new ObservableCollection<ZoneBalance>(WSZoneBalanceService.Instance.Select(SearchZoneBalanceModel));
                }
                else
                {
                    SearchZoneBalanceModel.StartBalanceTime = SearchZoneBalanceModel.StartBalanceTime ?? DateTime.Parse(DateTime.Now.AddDays(-1).ToShortDateString());
                    SearchZoneBalanceModel.EndBalanceTime = SearchZoneBalanceModel.EndBalanceTime ?? DateTime.Parse(DateTime.Now.ToShortDateString());
                    SearchZoneBalanceModel.BalanceTime = SearchZoneBalanceModel.StartBalanceTime;
                    ZoneBalanceList = new ObservableCollection<ZoneBalance>(WSZoneBalanceService.Instance.CallTimeSpanProc(SearchZoneBalanceModel));
                }
                Total = WSZoneBalanceService.Instance.SelectCount(SearchZoneBalanceModel);
                
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(CityDataGridVM), ex);
            }
            
        }

        public override void LoadPageData(int startindex, int endindex)
        {
            SearchZoneBalanceModel.StartIndex = startindex;
            SearchZoneBalanceModel.EndIndex = endindex;
            if (BalanceModeHelper.GetBalanceModeobj().EveryDayBalance)
            {
                ZoneBalanceList = new ObservableCollection<ZoneBalance>(WSZoneBalanceService.Instance.Select(SearchZoneBalanceModel));
            }
            else
            {
                SearchZoneBalanceModel.StartBalanceTime = SearchZoneBalanceModel.StartBalanceTime ?? DateTime.Parse(DateTime.Now.AddDays(-1).ToShortDateString());
                SearchZoneBalanceModel.EndBalanceTime = SearchZoneBalanceModel.StartBalanceTime ?? DateTime.Parse(DateTime.Now.ToShortDateString());
                ZoneBalanceList = new ObservableCollection<ZoneBalance>(WSZoneBalanceService.Instance.CallTimeSpanProc(SearchZoneBalanceModel));
            }
          
        }
        #endregion
        #region 内部方法
        private void LoadData()
        {
            List<SystemSetInfo> setList = new List<SystemSetInfo>(WSSystemSetInfoService.Instance.Select(null));
            SystemSetInfo ColomnSet = setList != null ? setList.Find(e => e.SetName.ToLower() == DataGridColomnState.GetSetName().ToLower()) : null;
            ColomnState = ColomnSet != null ? DataGridColomnState.SystemSetInfoToState(ColomnSet) : null;

            //ZoneBalance zb = new ZoneBalance();
            //zb.OrderbyColomnName = OrderByColomnHelper.GetSubOrderByColomn();
            //zb.SubOrderbyColomnName = OrderByColomnHelper.GetSubOrderByColomn();
            //zb.StartIndex = 0;
            //zb.EndIndex = 1000000;
            //zb.StartBalanceTime = DateTime.Parse("2016-10-21");
            //zb.EndBalanceTime = DateTime.Parse("2016-10-22");
            //List<ZoneBalance> rr= WSZoneBalanceService.Instance.CallTimeSpanProc(zb).ToList();
            Mode = BalanceModeHelper.GetBalanceModeobj();
        }
        #endregion
    }
}
