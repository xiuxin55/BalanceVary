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

namespace BalanceReport.ViewModels
{
    public class WebsiteSelectVM:NotificationObject
    {
        private WebsiteInfoService.WebsiteInfoServiceClient client = new WebsiteInfoServiceClient();
        public WebsiteSelectVM()
        {
            AddWebsiteCommand = new DelegateCommand(AddWebsiteExecute);
            UpdateWebsiteCommand = new DelegateCommand(UpdateWebsiteExecute);
            DeleteWebsiteCommand = new DelegateCommand(DeleteWebsiteExecute);
            SearchWebsiteCommand = new DelegateCommand(SearchWebsiteExecute);
            OkWebsiteCommand = new DelegateCommand(OkWebsiteExecute);
            SearchWebsiteExecute();
        }
        #region 属性
        public BalanceReport.Views.WebsiteSelect WebsiteSelectUI { get; set; }
        private WebsiteInfo _selectedWebsiteInfo;
        /// <summary>
        ///被选中的行 
        /// </summary>
        public WebsiteInfo SelectedWebsiteInfo
        {
            get { return _selectedWebsiteInfo; }
            set
            {
                _selectedWebsiteInfo = value;
                this.RaisePropertyChanged("SelectedWebsiteInfo");
            }
        }


        private WebsiteInfo _searchWebsiteInfo;
        /// <summary>
        /// 查询
        /// </summary>
        public WebsiteInfo SearchWebsiteInfo
        {
            get { return _searchWebsiteInfo; }
            set
            {
                _searchWebsiteInfo = value;
                this.RaisePropertyChanged("SearchWebsiteInfo");
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
        public DelegateCommand OkWebsiteCommand { get; set; }

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
            if (SelectedWebsiteInfo != null)
            {
                WebsiteAdd waui = new WebsiteAdd(false, SelectedWebsiteInfo);
                waui.ShowDialog();
                SearchWebsiteExecute();
            }
        }
        private void DeleteWebsiteExecute()
        {
            if (SelectedWebsiteInfo != null && SelectedWebsiteInfo.ID != null)
            {
                if (client.Delete(SelectedWebsiteInfo))
                {
                    MessageBox.Show("删除成功");
                    SearchWebsiteExecute();
                }
                else
                {
                    MessageBox.Show("删除失败,数据库连接失败");
                }
            }
        }
        private void SearchWebsiteExecute()
        {
            if (SearchWebsiteInfo == null)
            {
                SearchWebsiteInfo = new WebsiteInfo();
            }
            WebsiteInfoList = new ObservableCollection<WebsiteInfo> ( client.Select(SearchWebsiteInfo));
        }
        //public WebsiteInfo ReturnWebsiteInfo { get; set; }
        private void OkWebsiteExecute()
        {

            if (SelectedWebsiteInfo != null && WebsiteSelectUI != null)
            {
                WebsiteSelectUI.DialogResult = true; ;
            }
        }

        #endregion
        #region 内部方法

        #endregion
    }
}
