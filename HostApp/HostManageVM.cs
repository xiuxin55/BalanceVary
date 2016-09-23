using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using Microsoft.Practices.Prism.ViewModel;
using Microsoft.Practices.Prism.Commands;
using System.Windows;
using System.Reflection;
using WcfBalanceServiceLibrary;
using Common;

namespace HostApp
{
    /// <summary>
    /// 宿主VM
    /// </summary>
    public class HostManageVM:NotificationObject
    {
        public HostManageVM()
        {
            StartServiceCommand = new DelegateCommand(StartServiceExecute);
            StopServiceCommand = new DelegateCommand(StopServiceExecute);
            CheckBoxClickCommand = new DelegateCommand<object>(CheckBoxClickExecute);
            try
            {
                ServiceList = new ObservableCollection<ServiceModel>(AppConfigManager.GetServiceList());
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(HostManageVM), ex);
            }
            //SearchWebsiteCommand = new DelegateCommand(SearchWebsiteExecute);
            //SearchWebsiteExecute();
        }
        //#region 属性
        // private WebsiteInfoModel _selectedWebsiteInfoModel;
        ///// <summary>
        /////被选中的行 
        ///// </summary>
        //public WebsiteInfoModel SelectedWebsiteInfoModel
        //{
        //    get { return _selectedWebsiteInfoModel; }
        //    set { _selectedWebsiteInfoModel = value;
        //    this.RaisePropertyChanged("SelectedWebsiteInfoModel");
        //    }
        //}


        //private WebsiteInfoModel _searchWebsiteInfoModel;
        ///// <summary>
        ///// 查询
        ///// </summary>
        //public WebsiteInfoModel SearchWebsiteInfoModel
        //{
        //    get { return _searchWebsiteInfoModel; }
        //    set
        //    {
        //        _searchWebsiteInfoModel = value;
        //        this.RaisePropertyChanged("SearchWebsiteInfoModel");
        //    }
        //}
        private ObservableCollection<ServiceModel> _ServiceList;
        /// <summary>
        /// 服务集合
        /// </summary>
        public ObservableCollection<ServiceModel> ServiceList
        {
            get { return _ServiceList; }
            set
            {
                _ServiceList = value;
                this.RaisePropertyChanged("ServiceList");
            }
        }
       
        //#endregion
        #region 命令
        public DelegateCommand StartServiceCommand { get; set; }
        public DelegateCommand StopServiceCommand { get; set; }
        public DelegateCommand<object> CheckBoxClickCommand { get; set; }
        public DelegateCommand SearchWebsiteCommand { get; set; }
        #endregion
        //#region 命令执行方法
        private void StartServiceExecute()
        {
            try
            {
                foreach (var item in ServiceList)
                {
                    if (item.IsSelected && item.IsStart == "未启动")
                    {
                        Assembly ass = Assembly.Load(item.AssemblyName);

                        Type result = ass.GetType(item.ClassName);
                        ManageService.Instance.StartService(item.ClassName, result);
                        item.IsStart = "已启动";
                        item.StartTime = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
                    }
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(HostManageVM), ex);
            }
            
        }
            
        private void StopServiceExecute()
        {
            try
            {
                foreach (var item in ServiceList)
                {
                    if (item.IsSelected && item.IsStart == "已启动")
                    {
                        ManageService.Instance.CloseService(item.ClassName);
                        item.IsStart = "未启动";
                        item.StopTime = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
                    }
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(HostManageVM), ex);
            }
        }
        private void CheckBoxClickExecute(object  obj)
        {
            
            foreach (var item in ServiceList)
            {
                item.IsSelected = obj == null ? false:(bool)obj ;
            }
        }
        //private void SearchWebsiteExecute()
        //{
        //    if (SearchWebsiteInfoModel == null)
        //    {
        //        SearchWebsiteInfoModel = new WebsiteInfoModel();
        //    }
        //    WebsiteInfoList = WebsiteInfoDao.Instance.GetWebsiteFromObject(SearchWebsiteInfoModel);
        //}
        //#endregion
        //#region 内部方法
        
        //#endregion
    }
}
