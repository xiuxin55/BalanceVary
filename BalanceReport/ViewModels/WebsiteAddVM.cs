using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Prism.ViewModel;
using Microsoft.Practices.Prism.Commands;
using System.Windows;
using BalanceReport.WebsiteInfoService;
using Common;

namespace BalanceReport.ViewModels
{
    public class WebsiteAddVM : NotificationObject
    {
        private WebsiteInfoService.WebsiteInfoServiceClient client = new WebsiteInfoServiceClient();
        public WebsiteAddVM(bool IsAdd)
        {
            OkWebsiteCommand = new DelegateCommand(OkWebsiteExecute);
            CancelWebsiteCommand = new DelegateCommand(CancelWebsiteWebsiteExecute);
            this.IsAdd = IsAdd;
            AddWebsiteInfoModel = new WebsiteInfo();

        }
        #region 属性
        private bool IsAdd = false;
        private WebsiteInfo _addWebsiteInfoModel;
        /// <summary>
        /// 被选中的行
        /// </summary>
        public WebsiteInfo AddWebsiteInfoModel
        {
            get { return _addWebsiteInfoModel; }
            set
            {
                _addWebsiteInfoModel = value;
                this.RaisePropertyChanged("AddWebsiteInfoModel");
            }
        }
        public BalanceReport.Views.WebsiteAdd WebsiteAddUI { get; set; }

        #endregion
        #region 命令
        public DelegateCommand OkWebsiteCommand { get; set; }
        public DelegateCommand CancelWebsiteCommand { get; set; }

        #endregion
        #region 命令执行方法
        private void OkWebsiteExecute()
        {

            try
            {

                if ( AddWebsiteInfoModel.WebsiteID == null || AddWebsiteInfoModel.WebsiteName == null || AddWebsiteInfoModel.WebsiteAddress == null || AddWebsiteInfoModel.WebsiteTel == null
                    || AddWebsiteInfoModel.WebsiteManager == null || AddWebsiteInfoModel.ManagerTelphone == null || AddWebsiteInfoModel.Institution == null)
                {
                    MessageBox.Show("所有内容均不能为空");
                    return;
                }
                if (IsAdd)
                {
                    AddWebsiteInfoModel.ID = Guid.NewGuid().ToString();
                    WebsiteInfo temp = new WebsiteInfo();
                    temp.WebsiteID = AddWebsiteInfoModel.WebsiteID;
                    WebsiteInfo wim = client.Select(temp).FirstOrDefault();
                    if (wim != null)
                    {
                        MessageBox.Show("该网点已存在");
                        if (WebsiteAddUI != null)
                        {
                            WebsiteAddUI.Close();

                        }
                        return;
                    }
                    if (client.Add(AddWebsiteInfoModel))
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
                    if (client.Update(AddWebsiteInfoModel))
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
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(WebsiteManageVM), ex);
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
