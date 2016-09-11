using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Prism.ViewModel;
using Microsoft.Practices.Prism.Commands;
using System.Windows;
using System.Collections.ObjectModel;

namespace BalanceReport.ViewModels
{
    public class ManagersAddVM : NotificationObject
    {
        //public ManagersAddVM(bool IsAdd)
        //{
        //    OkManagersCommand = new DelegateCommand(OkManagersExecute);
        //    CancelManagersCommand = new DelegateCommand(CancelManagersManagersExecute);
        //    AddManagersInfoModel = new ManagersInfoModel();
        //    this.IsAdd = IsAdd;
           
        //}
        //#region 属性
        //private bool IsAdd = false;
        // private ManagersInfoModel _addManagersInfoModel;
        ///// <summary>
        ///// 被选中的行
        ///// </summary>
        // public ManagersInfoModel AddManagersInfoModel
        //{
        //    get { return _addManagersInfoModel; }
        //    set
        //    {
        //        _addManagersInfoModel = value;
        //        this.RaisePropertyChanged("AddManagersInfoModel");
        //    }
        //}
        // public BalanceReport.Views.ManagersAdd ManagersAddUI { get; set; }
        // private ObservableCollection<ManagersInfoModel> _ManagersInfoList;
        // /// <summary>
        // /// 网点集合
        // /// </summary>
        // public ObservableCollection<ManagersInfoModel> ManagersInfoList
        // {
        //     get { return _ManagersInfoList; }
        //     set
        //     {
        //         _ManagersInfoList = value;
        //         this.RaisePropertyChanged("ManagersInfoList");
        //     }
        // }
       
        //#endregion
        //#region 命令
        //public DelegateCommand OkManagersCommand { get; set; }
        //public DelegateCommand CancelManagersCommand { get; set; }
     
        //#endregion
        //#region 命令执行方法
        //private void OkManagersExecute()
        //{
        //    if (AddManagersInfoModel==null || AddManagersInfoModel.ManagerID == null || AddManagersInfoModel.ManagerName == null || AddManagersInfoModel.WebsiteID == null || AddManagersInfoModel.ManagerTelphone == null)
        //    {
        //        MessageBox.Show("所有内容均不能为空");
        //        return;
        //    }
        //    if (IsAdd)
        //    {
        //        AddManagersInfoModel.ID = Guid.NewGuid().ToString();
        //        ManagersInfoModel wim=ManagersInfoDao.Instance.SelectObjectManagersID(AddManagersInfoModel.ManagerID);
        //        if (wim.ID != null)
        //        {
        //            MessageBox.Show("该号已存在");
        //            if (ManagersAddUI != null)
        //            {
        //                ManagersAddUI.Close();
                        
        //            }
        //            return;
        //        }
        //        if (ManagersInfoDao.Instance.Add(AddManagersInfoModel))
        //        {
        //            MessageBox.Show("新增成功");
        //            if (ManagersAddUI != null)
        //            {
        //                ManagersAddUI.Close();
        //            }
        //        }
        //        else
        //        {
        //            MessageBox.Show("新增失败,数据库连接失败");
        //        }
        //    }
        //    else
        //    {
        //        if (ManagersInfoDao.Instance.Update(AddManagersInfoModel))
        //        {
        //            MessageBox.Show("修改成功");
        //            if (ManagersAddUI != null)
        //            {
        //                ManagersAddUI.Close();
        //            }
        //        }
        //        else
        //        {
        //            MessageBox.Show("修改失败,数据库连接失败");
        //        }
        //    }

        //}
        //private void CancelManagersManagersExecute()
        //{
        //    if (ManagersAddUI != null)
        //    {
        //        ManagersAddUI.Close();
        //    }
        //}
        
        //#endregion
        //#region 内部方法
        
        //#endregion
    }
}
