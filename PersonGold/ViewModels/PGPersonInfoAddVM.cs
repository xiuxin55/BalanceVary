using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Prism.ViewModel;
using Microsoft.Practices.Prism.Commands;
using System.Windows;
using WSBalanceClient.PGPersonInfoService;
using Common;
using WSBalanceClient;

namespace PersonGold.ViewModels
{
    public class PGPersonInfoAddVM : NotificationObject
    {
       
        public PGPersonInfoAddVM(bool IsAdd)
        {
            OkCommand = new DelegateCommand(OkExecute);
            CancelCommand = new DelegateCommand(CancelExecute);
            this.IsAdd = IsAdd;
            AddPGPersonInfoModel = new PGPersonInfo();

        }
        #region 属性
        private bool IsAdd = false;
        private PGPersonInfo _addPGPersonInfoModel;
        /// <summary>
        /// 被选中的行
        /// </summary>
        public PGPersonInfo AddPGPersonInfoModel
        {
            get { return _addPGPersonInfoModel; }
            set
            {
                _addPGPersonInfoModel = value;
                this.RaisePropertyChanged("AddPGPersonInfoModel");
            }
        }
        public Views.PGPersonInfoAdd AddUI { get; set; }

        #endregion
        #region 命令
        public DelegateCommand OkCommand { get; set; }
        public DelegateCommand CancelCommand { get; set; }

        #endregion
        #region 命令执行方法
        private void OkExecute()
        {

            try
            {

                if ( AddPGPersonInfoModel.StaffCode == null || AddPGPersonInfoModel.StaffName == null || AddPGPersonInfoModel.NewWebsiteID == null 
                   )
                {
                    MessageBox.Show("人员编号、姓名、新网点号不能为空");
                    return;
                }
                if (IsAdd)
                {
                    AddPGPersonInfoModel.ID = Guid.NewGuid().ToString();
                    PGPersonInfo temp = new PGPersonInfo();
                    temp.StaffCode = AddPGPersonInfoModel.StaffCode;
                    PGPersonInfo wim = WSPGPersonInfoService.Instance.Select(temp).FirstOrDefault();
                    if (wim != null && !string.IsNullOrWhiteSpace(wim.StaffCode))
                    {
                        MessageBox.Show("该人员编号已存在");
                        //if (AddUI != null)
                        //{
                        //    AddUI.Close();

                        //}
                        return;
                    }
                    if (WSPGPersonInfoService.Instance.Add(AddPGPersonInfoModel))
                    {
                        MessageBox.Show("新增成功");
                        if (AddUI != null)
                        {
                            AddUI.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("新增失败,数据库连接失败");
                    }
                }
                else
                {
                    if (WSPGPersonInfoService.Instance.Update(AddPGPersonInfoModel))
                    {
                        MessageBox.Show("修改成功");
                        if (AddUI != null)
                        {
                            AddUI.Close();
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
                LogHelper.WriteLog(typeof(PGPersonInfoAddVM), ex);
            }
        }
        private void CancelExecute()
        {
            if (AddUI != null)
            {
                AddUI.Close();
            }
        }

        #endregion
        #region 内部方法

        #endregion
    }
}
