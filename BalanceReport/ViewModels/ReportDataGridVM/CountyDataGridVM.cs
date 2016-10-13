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
using BalanceReport.ZoneBalanceService;
using Utility;
using BalanceReport.LocalModel;
using BalanceReport.SystemSetInfoService;

namespace BalanceReport.ViewModels
{
    public class CountyDataGridVM : BaseVM
    {
        private ZoneBalanceServiceClient client = new ZoneBalanceServiceClient();
        public CountyDataGridVM()
        {
            SearchWebsiteCommand = new DelegateCommand(SearchWebsiteExecute);
            SearchWebsiteExecute();
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

        #endregion
        #region 命令
        public DelegateCommand SearchWebsiteCommand { get; set; }
        #endregion
        #region 命令执行方法
        private void SearchWebsiteExecute()
        {
            if (SearchZoneBalanceModel == null)
            {
                SearchZoneBalanceModel = new ZoneBalance();
            }
            try
            {
                Total = 0;
                SearchZoneBalanceModel.ZoneType = "县行";
                SearchZoneBalanceModel.EndIndex = int.MaxValue;
                SearchZoneBalanceModel.OrderbyColomnName = "BalanceTime";

                SearchZoneBalanceModel.StartIndex = 1;
                SearchZoneBalanceModel.EndIndex = PageSize;
                ZoneBalanceList = new ObservableCollection<ZoneBalance>(client.Select(SearchZoneBalanceModel));
                Total = client.SelectCount(SearchZoneBalanceModel);
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(CountyDataGridVM), ex);
            }

        }

        public override void LoadPageData(int startindex, int endindex)
        {
            SearchZoneBalanceModel.StartIndex = startindex;
            SearchZoneBalanceModel.EndIndex = endindex;
            ZoneBalanceList = new ObservableCollection<ZoneBalance>(client.Select(SearchZoneBalanceModel));
        }
        #endregion
        #region 内部方法
        private void LoadData()
        {
            SystemSetInfoService.SystemSetInfoServiceClient clientSystemSetInfo = new SystemSetInfoServiceClient();
            List<SystemSetInfo> setList = new List<SystemSetInfo>(clientSystemSetInfo.Select(null));
            SystemSetInfo ColomnSet = setList != null ? setList.Find(e => e.SetName.ToLower() == DataGridColomnState.GetSetName().ToLower()) : null;
            ColomnState = ColomnSet != null ? DataGridColomnState.SystemSetInfoToState(ColomnSet) : null;
        }
        #endregion
    }
}
