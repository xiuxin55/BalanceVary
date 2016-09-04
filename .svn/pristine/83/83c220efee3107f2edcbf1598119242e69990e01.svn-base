using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BalanceReport.Models;
using System.Collections.ObjectModel;
using Microsoft.Practices.Prism.ViewModel;
using Microsoft.Practices.Prism.Commands;
using BalanceReport.Dao;

namespace BalanceReport.ViewModels
{
    public class ReportUserControlVM : NotificationObject
    {
        public ReportUserControlVM()
        {
        }
        #region 属性
        private WebsiteInfoModel _selectWebsiteInfoModel;
        /// <summary>
        /// 被选中的行
        /// </summary>
        public WebsiteInfoModel SelectWebsiteInfoModel
        {
            get { return _selectWebsiteInfoModel; }
            set
            {
                _selectWebsiteInfoModel = value;
                this.RaisePropertyChanged("SelectWebsiteInfoModel");
            }
        }
        //public BalanceReport.Views.WebsiteAdd WebsiteAddUI { get; set; }
        private ObservableCollection<WebsiteInfoModel> _websiteInfoModelList;
        /// <summary>
        /// 网点集合
        /// </summary>
        public ObservableCollection<WebsiteInfoModel> WebsiteInfoModelList
        {
            get { return _websiteInfoModelList; }
            set
            {
                _websiteInfoModelList = value;
                this.RaisePropertyChanged("WebsiteInfoModelList");
            }
        }
        public void GetWebsiteByType(string jigou)
        {
            WebsiteInfoModelList=null;
            WebsiteInfoModel SearchWebsiteInfoModel = new WebsiteInfoModel();
            
            if (jigou == "市行")
            {
                SearchWebsiteInfoModel.Institution = jigou;
                WebsiteInfoModelList = WebsiteInfoDao.Instance.GetWebsiteFromObject(SearchWebsiteInfoModel);
            }
            else
            {
                SearchWebsiteInfoModel.Institution = jigou;
                WebsiteInfoModelList = WebsiteInfoDao.Instance.GetWebsiteFromObject(SearchWebsiteInfoModel);
            }
            if (WebsiteInfoModelList != null)
            {
                WebsiteInfoModelList.Insert(0, SearchWebsiteInfoModel);
            }
        }
        #endregion
        #region 命令
        public DelegateCommand OkWebsiteCommand { get; set; }
        public DelegateCommand CancelWebsiteCommand { get; set; }

        #endregion
    }
}
