using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Prism.ViewModel;
using Microsoft.Practices.Prism.Commands;
using BalanceReport.Models;
using BalanceReport.Dao;
using System.Windows;

namespace BalanceReport.ViewModels
{
    public class WebsiteAddVM : NotificationObject
    {
        public WebsiteAddVM(bool IsAdd)
        {
            OkWebsiteCommand = new DelegateCommand(OkWebsiteExecute);
            CancelWebsiteCommand = new DelegateCommand(CancelWebsiteWebsiteExecute);
            this.IsAdd = IsAdd;
            AddWebsiteInfoModel = new WebsiteInfoModel();
           
        }
        #region 属性
        private bool IsAdd = false;
         private WebsiteInfoModel _addWebsiteInfoModel;
        /// <summary>
        /// 被选中的行
        /// </summary>
         public WebsiteInfoModel AddWebsiteInfoModel
        {
            get { return _addWebsiteInfoModel; }
            set
            {
                _addWebsiteInfoModel = value;
                this.RaisePropertyChanged("AddWebsiteInfoModel");
            }
        }
         public BalanceReport.Views.WebsiteAdd WebsiteAddUI { get; set; }
        //private ObservableCollection<WebsiteInfoModel> _websiteInfoList;
        ///// <summary>
        ///// 网点集合
        ///// </summary>
        //public ObservableCollection<WebsiteInfoModel> WebsiteInfoList
        //{
        //    get { return _websiteInfoList; }
        //    set { _websiteInfoList = value;
        //    this.RaisePropertyChanged("WebsiteInfoList");
        //    }
        //}
       
        #endregion
        #region 命令
        public DelegateCommand OkWebsiteCommand { get; set; }
        public DelegateCommand CancelWebsiteCommand { get; set; }
     
        #endregion
        #region 命令执行方法
        private void OkWebsiteExecute()
        {
    
            if (AddWebsiteInfoModel==null || AddWebsiteInfoModel.WebsiteID == null || AddWebsiteInfoModel.WebsiteName == null || AddWebsiteInfoModel.WebsiteAddress == null || AddWebsiteInfoModel.WebsiteTel == null
                || AddWebsiteInfoModel.WebsiteManager == null || AddWebsiteInfoModel.ManagerTelphone == null || AddWebsiteInfoModel.Institution == null)
            {
                MessageBox.Show("所有内容均不能为空");
                return;
            }
            if (IsAdd)
            {
                AddWebsiteInfoModel.ID = Guid.NewGuid().ToString();
                WebsiteInfoModel wim=WebsiteInfoDao.Instance.SelectObjectWebsiteID(AddWebsiteInfoModel.WebsiteID);
                if (wim.ID != null)
                {
                    MessageBox.Show("该网点已存在");
                    if (WebsiteAddUI != null)
                    {
                        WebsiteAddUI.Close();
                        
                    }
                    return;
                }
                if (WebsiteInfoDao.Instance.Add(AddWebsiteInfoModel))
                {
                    MessageBox.Show("新增成功");
                    if (WebsiteAddUI != null)
                    {
                        WebsiteAddUI.Close();
                    }
                }
                else
                {
                    MessageBox.Show("新增失败,数据库连接失败");
                }
            }
            else
            {
                if (WebsiteInfoDao.Instance.Update(AddWebsiteInfoModel))
                {
                    MessageBox.Show("修改成功");
                    if (WebsiteAddUI != null)
                    {
                        WebsiteAddUI.Close();
                    }
                }
                else
                {
                    MessageBox.Show("修改失败,数据库连接失败");
                }
            }

        }
        private void CancelWebsiteWebsiteExecute()
        {
            if (WebsiteAddUI != null)
            {
                WebsiteAddUI.Close();
            }
        }
        
        #endregion
        #region 内部方法
        
        #endregion
    }
}
