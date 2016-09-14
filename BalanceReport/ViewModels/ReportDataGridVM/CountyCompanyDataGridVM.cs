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

namespace BalanceReport.ViewModels
{
    public class CountyCompanyDataGridVM : NotificationObject
    {
        private WebsiteInfoService.WebsiteInfoServiceClient client = new WebsiteInfoServiceClient();
        public CountyCompanyDataGridVM()
        {
            SearchWebsiteCommand = new DelegateCommand(SearchWebsiteExecute);
            SearchWebsiteExecute();
        }
        #region 属性
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
                this.RaisePropertyChanged("SelectedWebsiteInfoModel");
            }
        }


        private WebsiteInfo _searchWebsiteInfoModel;
        /// <summary>
        /// 查询
        /// </summary>
        public WebsiteInfo SearchWebsiteInfoModel
        {
            get { return _searchWebsiteInfoModel; }
            set
            {
                _searchWebsiteInfoModel = value;
                this.RaisePropertyChanged("SearchWebsiteInfoModel");
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

        #endregion
        #region 命令
        public DelegateCommand SearchWebsiteCommand { get; set; }
        #endregion
        #region 命令执行方法
        private void SearchWebsiteExecute()
        {
            if (SearchWebsiteInfoModel == null)
            {
                SearchWebsiteInfoModel = new WebsiteInfo();
            }
            try
            {
                SearchWebsiteInfoModel.Institution = "县行";
                WebsiteInfoList = new ObservableCollection<WebsiteInfo>(client.Select(SearchWebsiteInfoModel));
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(WebsiteManageVM), ex);
            }
            
        }
        #endregion
        #region 内部方法

        #endregion
    }
}
