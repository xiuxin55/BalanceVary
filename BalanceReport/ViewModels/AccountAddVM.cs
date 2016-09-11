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
    public class AccountAddVM : NotificationObject
    {
        //public AccountAddVM(bool IsAdd)
        //{
        //    OkAccountCommand = new DelegateCommand(OkAccountExecute);
        //    CancelAccountCommand = new DelegateCommand(CancelAccountAccountExecute);
        //    AddAccountInfoModel = new AccountInfoModel();
        //    this.IsAdd = IsAdd;
           
        //}
        //#region 属性
        //private bool IsAdd = false;
        // private AccountInfoModel _addAccountInfoModel;
        ///// <summary>
        ///// 被选中的行
        ///// </summary>
        // public AccountInfoModel AddAccountInfoModel
        //{
        //    get { return _addAccountInfoModel; }
        //    set
        //    {
        //        _addAccountInfoModel = value;
        //        this.RaisePropertyChanged("AddAccountInfoModel");
        //    }
        //}
        // public AccountInfoModel OldAccountInfoModel { get; set; }
        // public BalanceReport.Views.AccountAdd AccountAddUI { get; set; }
        // private ObservableCollection<AccountInfoModel> _AccountInfoList;
        // /// <summary>
        // /// 网点集合
        // /// </summary>
        // public ObservableCollection<AccountInfoModel> AccountInfoList
        // {
        //     get { return _AccountInfoList; }
        //     set
        //     {
        //         _AccountInfoList = value;
        //         this.RaisePropertyChanged("AccountInfoList");
        //     }
        // }
       
        //#endregion
        //#region 命令
        //public DelegateCommand OkAccountCommand { get; set; }
        //public DelegateCommand CancelAccountCommand { get; set; }
     
        //#endregion
        //#region 命令执行方法
        //private void OkAccountExecute()
        //{
        //    if (AddAccountInfoModel == null || AddAccountInfoModel.SubAccountNumber == null || AddAccountInfoModel.AccountID == null || AddAccountInfoModel.AccountName == null || AddAccountInfoModel.WebsiteID == null || AddAccountInfoModel.AccountType == null
        //        || AddAccountInfoModel.ManagerID == null )
        //    {
        //        MessageBox.Show("所有内容均不能为空");
        //        return;
        //    }
        //    if (IsAdd)
        //    {
        //        AddAccountInfoModel.ID = Guid.NewGuid().ToString();
        //        AccountInfoModel wim = AccountInfoDao.Instance.SelectObjectAccountID(AddAccountInfoModel.AccountID, AddAccountInfoModel.SubAccountNumber);
        //        if (wim.ID != null)
        //        {
        //            MessageBox.Show("该账号+子账号已存在");
        //            if (AccountAddUI != null)
        //            {
        //                AccountAddUI.Close();
                        
        //            }
        //            return;
        //        }
        //        if (AccountInfoDao.Instance.Add(AddAccountInfoModel))
        //        {
        //            MessageBox.Show("新增成功");
        //            if (AccountAddUI != null)
        //            {
        //                AccountAddUI.Close();
        //            }
        //        }
        //        else
        //        {
        //            MessageBox.Show("新增失败");
        //        }
        //    }
        //    else
        //    {
        //        if (AccountInfoDao.Instance.Update(AddAccountInfoModel, OldAccountInfoModel))
        //        {
        //            MessageBox.Show("修改成功");
        //            if (AccountAddUI != null)
        //            {
        //                AccountAddUI.Close();
        //            }
        //        }
        //        else
        //        {
        //            MessageBox.Show("修改失败");
        //        }
        //    }

        //}
        //private void CancelAccountAccountExecute()
        //{
        //    if (AccountAddUI != null)
        //    {
        //        AccountAddUI.Close();
        //    }
        //}
        
        //#endregion
        //#region 内部方法
        
        //#endregion
    }
}
