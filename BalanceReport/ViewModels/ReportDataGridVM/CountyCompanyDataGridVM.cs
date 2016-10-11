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

namespace BalanceReport.ViewModels
{
   

    public class CountyCompanyDataGridVM : BaseVM
    {
        private WebsiteInfoService.WebsiteInfoServiceClient clientwebsite = new WebsiteInfoServiceClient();
        private CompanyBalanceServiceClient clientcompanybalance = new CompanyBalanceServiceClient();
        public CountyCompanyDataGridVM()
        {
            SearchWebsiteCommand = new DelegateCommand(SearchWebsiteExecute);
            LoadData();
            //  SearchWebsiteExecute();
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
                SearchWebsiteExecute();
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


        #endregion
        #region 命令
        public DelegateCommand SearchWebsiteCommand { get; set; }
        #endregion
        #region 命令执行方法
        private void SearchWebsiteExecute()
        {
            SearchCompanyBalanceoModel = new CompanyBalance();
            SearchCompanyBalanceoModel.EndIndex = int.MaxValue;
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
                model.Institution = "县行";
                WebsiteInfoList = new ObservableCollection<WebsiteInfo>(clientwebsite.Select(model));
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(WebsiteManageVM), ex);
            }
        }

        public override void LoadPageData(int startindex, int endindex)
        {
            SearchCompanyBalanceoModel.StartIndex = startindex;
            SearchCompanyBalanceoModel.EndIndex = endindex;
            CompanyBalanceList = new ObservableCollection<CompanyBalance>(clientcompanybalance.Select(SearchCompanyBalanceoModel));
        }
        #endregion
        #region 内部方法

        #endregion
    }
}
