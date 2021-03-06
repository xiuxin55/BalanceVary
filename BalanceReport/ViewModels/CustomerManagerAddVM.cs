﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Prism.ViewModel;
using Microsoft.Practices.Prism.Commands;
using System.Windows;
using System.Collections.ObjectModel;
using WSBalanceClient.CustomerManagerInfoService;
using WSBalanceClient;
namespace BalanceReport.ViewModels
{
    public class CustomerManagerAddVM : NotificationObject
    {
       
        public CustomerManagerAddVM(bool IsAdd)
        {
            OkManagersCommand = new DelegateCommand(OkManagersExecute);
            CancelManagersCommand = new DelegateCommand(CancelManagersManagersExecute);
            
            this.IsAdd = IsAdd;
       
        }
        #region 属性
        private bool IsAdd = false;
        private CustomerManagerInfo _addCustomerManagerInfo;
        /// <summary>
        /// 被选中的行
        /// </summary>
        public CustomerManagerInfo AddCustomerManagerInfo
        {
            get { return _addCustomerManagerInfo; }
            set
            {
                _addCustomerManagerInfo = value;
                this.RaisePropertyChanged("AddCustomerManagerInfo");
            }
        }
        public BalanceReport.Views.CustomerManagerAdd ManagersAddUI { get; set; }
        private ObservableCollection<CustomerManagerInfo> _ManagersInfoList;
        /// <summary>
        /// 网点集合
        /// </summary>
        public ObservableCollection<CustomerManagerInfo> ManagersInfoList
        {
            get { return _ManagersInfoList; }
            set
            {
                _ManagersInfoList = value;
                this.RaisePropertyChanged("ManagersInfoList");
            }
        }

        #endregion
        #region 命令
        public DelegateCommand OkManagersCommand { get; set; }
        public DelegateCommand CancelManagersCommand { get; set; }

        #endregion
        #region 命令执行方法
        private void OkManagersExecute()
        {
            if (AddCustomerManagerInfo == null || AddCustomerManagerInfo.ManagerID == null || AddCustomerManagerInfo.ManagerName == null || AddCustomerManagerInfo.DepartmentName == null )
            {
                MessageBox.Show("必填内容不能为空");
                return;
            }
            if (IsAdd)
            {
                AddCustomerManagerInfo.ID = Guid.NewGuid().ToString();
                CustomerManagerInfo info = new CustomerManagerInfo();
                info.ManagerID = AddCustomerManagerInfo.ManagerID;
                CustomerManagerInfo wim = WSCustomerManagerInfoService.Instance.Select(info).FirstOrDefault();
                if (wim.ManagerID == AddCustomerManagerInfo.ManagerID && wim.ManagerName==AddCustomerManagerInfo.ManagerName )
                {
                    MessageBox.Show("客户经理已存在");
                    if (ManagersAddUI != null)
                    {
                        ManagersAddUI.Close();

                    }
                    return;
                }
                if (WSCustomerManagerInfoService.Instance.Add(AddCustomerManagerInfo))
                {
                    MessageBox.Show("新增成功");
                    if (ManagersAddUI != null)
                    {
                        ManagersAddUI.Close();
                    }
                }
                else
                {
                    MessageBox.Show("新增失败");
                }
            }
            else
            {
                if (WSCustomerManagerInfoService.Instance.Update(AddCustomerManagerInfo))
                {
                    MessageBox.Show("修改成功");
                    if (ManagersAddUI != null)
                    {
                        ManagersAddUI.Close();
                    }
                }
                else
                {
                    MessageBox.Show("修改失败");
                }
            }

        }
        private void CancelManagersManagersExecute()
        {
            if (ManagersAddUI != null)
            {
                ManagersAddUI.Close();
            }
        }

        #endregion
        #region 内部方法

        #endregion
    }
}
