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
using WSBalanceClient;

namespace BalanceReport.ViewModels
{
    public class WebsiteManageVM:NotificationObject
    {
       
        public WebsiteManageVM()
        {
            AddWebsiteCommand = new DelegateCommand(AddWebsiteExecute);
            UpdateWebsiteCommand = new DelegateCommand(UpdateWebsiteExecute);
            DeleteWebsiteCommand = new DelegateCommand(DeleteWebsiteExecute);
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
        public DelegateCommand AddWebsiteCommand { get; set; }
        public DelegateCommand UpdateWebsiteCommand { get; set; }
        public DelegateCommand DeleteWebsiteCommand { get; set; }
        public DelegateCommand SearchWebsiteCommand { get; set; }
        #endregion
        #region 命令执行方法
        private void AddWebsiteExecute()
        {
            WebsiteAdd waui = new WebsiteAdd(true, null);
            waui.ShowDialog();
            SearchWebsiteExecute();
        }
        private void UpdateWebsiteExecute()
        {
            if (SelectedWebsiteInfoModel != null)
            {
                WebsiteAdd waui = new WebsiteAdd(false, SelectedWebsiteInfoModel);
                waui.ShowDialog();
                SearchWebsiteExecute();
            }
        }
        private void DeleteWebsiteExecute()
        {
            if (SelectedWebsiteInfoModel != null && SelectedWebsiteInfoModel.ID != null)
            {
                if (MessageBox.Show("是否删除", "消息提示", MessageBoxButton.YesNo) == MessageBoxResult.Yes && WSWebsiteInfoService.Instance.Delete(SelectedWebsiteInfoModel))
                {
                    MessageBox.Show("删除成功");
                    SearchWebsiteExecute();
                }
            }
        }
        private void SearchWebsiteExecute()
        {
            if (SearchWebsiteInfoModel == null)
            {
                SearchWebsiteInfoModel = new WebsiteInfo();
            }
            try
            {
                WebsiteInfoList = new ObservableCollection<WebsiteInfo>(WSWebsiteInfoService.Instance.Select(SearchWebsiteInfoModel));
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
