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
using BalanceReport.WebsiteBalanceService;
using Utility;
using BalanceReport.LocalModel;

namespace BalanceReport.ViewModels
{
    public class CityWebsiteDataGridVM : BaseVM
    {
        private WebsiteInfoService.WebsiteInfoServiceClient clientwebsite = new WebsiteInfoService.WebsiteInfoServiceClient();
        private WebsiteBalanceServiceClient clientwebsitebalance = new WebsiteBalanceServiceClient();
        public CityWebsiteDataGridVM()
        {
            SearchWebsiteCommand = new DelegateCommand(SearchWebsiteExecute);
            LoadData();
          //  SearchWebsiteExecute();
        }
        #region 属性
        public DataGridColomnState ColomnState
        {
            get { return LocalCommonData.ColomnState; }

        }
        private WebsiteInfoService.WebsiteInfo _selectedWebsiteInfoModel;
        /// <summary>
        ///被选中的行 
        /// </summary>
        public WebsiteInfoService.WebsiteInfo SelectedWebsiteInfoModel
        {
            get { return _selectedWebsiteInfoModel; }
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


        #endregion
        #region 命令
        public DelegateCommand SearchWebsiteCommand { get; set; }
        #endregion
        #region 命令执行方法
        private void SearchWebsiteExecute()
        {
            Total = 0;
            SearchWebsiteBalanceModel = new WebsiteBalance();
            SearchWebsiteBalanceModel.OrderbyColomnName = "BalanceTime";
            SearchWebsiteBalanceModel.WebsiteID = SelectedWebsiteInfoModel.WebsiteID;
            SearchWebsiteBalanceModel.StartIndex = 1;
            SearchWebsiteBalanceModel.EndIndex = PageSize;
            WebsiteBalanceList = new ObservableCollection<WebsiteBalance>(clientwebsitebalance.Select(SearchWebsiteBalanceModel));
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
            WebsiteBalanceList = new ObservableCollection<WebsiteBalance>(clientwebsitebalance.Select(SearchWebsiteBalanceModel));
        }
        #endregion
        #region 内部方法

        #endregion
    }
}
