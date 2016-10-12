using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Prism.ViewModel;
using Microsoft.Practices.Prism.Commands;
using System.Windows;
using BalanceReport.DepartmentInfoService;
using Common;

namespace BalanceReport.ViewModels
{
    public class DepartmentAddVM : NotificationObject
    {
        private DepartmentInfoService.DepartmentInfoServiceClient client = new DepartmentInfoServiceClient();
        public DepartmentAddVM(bool IsAdd)
        {
            OkDepartmentCommand = new DelegateCommand(OkDepartmentExecute);
            CancelDepartmentCommand = new DelegateCommand(CancelDepartmentDepartmentExecute);
            this.IsAdd = IsAdd;
            AddDepartmentInfoModel = new DepartmentInfo();

        }
        #region 属性
        private bool IsAdd = false;
        private DepartmentInfo _addDepartmentInfoModel;
        /// <summary>
        /// 被选中的行
        /// </summary>
        public DepartmentInfo AddDepartmentInfoModel
        {
            get { return _addDepartmentInfoModel; }
            set
            {
                _addDepartmentInfoModel = value;
                this.RaisePropertyChanged("AddDepartmentInfoModel");
            }
        }
        public BalanceReport.Views.DepartmentAdd DepartmentAddUI { get; set; }

        #endregion
        #region 命令
        public DelegateCommand OkDepartmentCommand { get; set; }
        public DelegateCommand CancelDepartmentCommand { get; set; }

        #endregion
        #region 命令执行方法
        private void OkDepartmentExecute()
        {

            try
            {

                if ( AddDepartmentInfoModel.DepartmentName == null )
                {
                    MessageBox.Show("部门名称不能为空");
                    return;
                }
                if (IsAdd)
                {
                    AddDepartmentInfoModel.ID = Guid.NewGuid().ToString();
                    DepartmentInfo temp = new DepartmentInfo();
                    temp.DepartmentName = AddDepartmentInfoModel.DepartmentName;
                    DepartmentInfo wim = client.Select(temp).FirstOrDefault();
                    if (wim != null)
                    {
                        MessageBox.Show("该部门已存在");
                        if (DepartmentAddUI != null)
                        {
                            DepartmentAddUI.Close();

                        }
                        return;
                    }
                    if (client.Add(AddDepartmentInfoModel))
                    {
                        MessageBox.Show("新增成功");
                        if (DepartmentAddUI != null)
                        {
                            DepartmentAddUI.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("新增失败");
                    }
                }
                else
                {
                    if (client.Update(AddDepartmentInfoModel))
                    {
                        MessageBox.Show("修改成功");
                        if (DepartmentAddUI != null)
                        {
                            DepartmentAddUI.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("修改失败");
                    }
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(DepartmentManageVM), ex);
                throw ex;
            }
        }
        private void CancelDepartmentDepartmentExecute()
        {
            if (DepartmentAddUI != null)
            {
                DepartmentAddUI.Close();
            }
        }

        #endregion
        #region 内部方法

        #endregion
    }
}
