﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using Microsoft.Practices.Prism.ViewModel;
using Microsoft.Practices.Prism.Commands;
using System.Windows;
using BalanceReport.Views;

using Common;
using BalanceReport.WebsiteBalanceService;
using Utility;
using BalanceReport.LocalModel;
using BalanceReport.SystemSetInfoService;
using BalanceReport.Helper;

namespace BalanceReport.ViewModels
{
    public class CityWebsiteDataGridVM : BaseVM
    {
        private WebsiteInfoService.WebsiteInfoServiceClient clientwebsite = new WebsiteInfoService.WebsiteInfoServiceClient();
        private WebsiteBalanceServiceClient clientwebsitebalance = new WebsiteBalanceServiceClient();
        public CityWebsiteDataGridVM()
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
        private WebsiteInfoService.WebsiteInfo _selectedWebsiteInfoModel;
        /// <summary>
        ///被选中的行 
        /// </summary>
        public WebsiteInfoService.WebsiteInfo SelectedWebsiteInfoModel
        {
            get { return _selectedWebsiteInfoModel ?? new WebsiteInfoService.WebsiteInfo(); ; }
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
        private ObservableCollection<WebsiteInfoService.WebsiteInfo> _websiteInfoList;
        /// <summary>
        /// 网点集合
        /// </summary>
        public ObservableCollection<WebsiteInfoService.WebsiteInfo> WebsiteInfoList
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
            //if (SearchWebsiteBalanceModel==null)
            //{
            //    SearchWebsiteBalanceModel = new WebsiteBalance();
            //}
           
            SearchWebsiteBalanceModel.OrderbyColomnName = OrderByColomnHelper.GetOrderByColomn();
            SearchWebsiteBalanceModel.SubOrderbyColomnName = OrderByColomnHelper.GetSubOrderByColomn();
            SearchWebsiteBalanceModel.WebsiteID = SelectedWebsiteInfoModel.WebsiteID;
            SearchWebsiteBalanceModel.StartIndex = 1;
            SearchWebsiteBalanceModel.EndIndex = PageSize;
            if (BalanceModeHelper.GetBalanceModeobj().EveryDayBalance)
            {
                WebsiteBalanceList = new ObservableCollection<WebsiteBalance>(clientwebsitebalance.Select(SearchWebsiteBalanceModel));
            }
            else
            {
                SearchWebsiteBalanceModel.StartBalanceTime = SearchWebsiteBalanceModel.StartBalanceTime ?? DateTime.Parse(DateTime.Now.AddDays(-1).ToShortDateString());
                SearchWebsiteBalanceModel.EndBalanceTime = SearchWebsiteBalanceModel.EndBalanceTime ?? DateTime.Parse(DateTime.Now.ToShortDateString());
             
                WebsiteBalanceList = new ObservableCollection<WebsiteBalance>(clientwebsitebalance.CallTimeSpanProc(SearchWebsiteBalanceModel));
                SearchWebsiteBalanceModel.BalanceTime = SearchWebsiteBalanceModel.StartBalanceTime;
            }
            
            Total = clientwebsitebalance.SelectCount(SearchWebsiteBalanceModel);
        }

        private void LoadData()
        {
            try
            {
                WebsiteInfoService.WebsiteInfo model = new WebsiteInfoService.WebsiteInfo();
                model.Institution = "市行";
                WebsiteInfoList = new ObservableCollection<WebsiteInfoService.WebsiteInfo>(clientwebsite.Select(model));
                WebsiteInfoService.WebsiteInfo temp = new WebsiteInfoService.WebsiteInfo();
                temp.Institution = "市行";
                temp.WebsiteName = "全部";
                WebsiteInfoList.Insert(0, temp);

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
            SearchWebsiteBalanceModel.StartIndex = startindex;
            SearchWebsiteBalanceModel.EndIndex = endindex;
            if (BalanceModeHelper.GetBalanceModeobj().EveryDayBalance)
            {
                WebsiteBalanceList = new ObservableCollection<WebsiteBalance>(clientwebsitebalance.Select(SearchWebsiteBalanceModel));
            }
            else
            {
                 
                WebsiteBalanceList = new ObservableCollection<WebsiteBalance>(clientwebsitebalance.CallTimeSpanProc(SearchWebsiteBalanceModel));
            }
        }
        #endregion
        #region 内部方法

        #endregion
    }
}
