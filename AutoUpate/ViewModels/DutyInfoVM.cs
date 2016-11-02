using AvalonDock;
using System;
using System.Linq;
using System.Collections.Generic;
using FundsRegulatoryClient.JG_DepositSrv;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using FinancialRegulation.Page.Fund;
using FinancialRegulation.ViewModel;
using System.Data;
using FundsRegulatoryClient;
using System.Windows;
using MahApps.Metro.Controls;

namespace UserAuthorization
{
    /// <summary>
    ///新建或修改职责
    /// </summary>
    [System.Runtime.InteropServices.GuidAttribute("DEEF5BD6-8EB4-41E8-8849-48347844D170")]
    public class DutyInfoVM : BaseManageVM<DutyModel>
    {


        #region 构造加载

        /// <summary>
        /// 加载命令
        /// </summary>
        public override void LoadCommand()
        {

            OKCommand = new Microsoft.Practices.Prism.Commands.DelegateCommand(OkExecute);
        }
        
        DutyModel _SelectDuty;
        public DutyModel SelectDuty
        {
            get
            {
                if (_SelectDuty==null)
                {
                    _SelectDuty = new DutyModel();
                }
                return _SelectDuty;
            }
            set
            {
                _SelectDuty = value;
                RaisePropertyChanged("SelectDuty");
            }
        }

        #endregion 构造加载

        #region 变量属性
        public MetroWindow Owner { get; set; }

     

        

        #endregion 变量属性

        #region 命令定义


        public Microsoft.Practices.Prism.Commands.DelegateCommand OKCommand { get; set; }
      
        #endregion 命令定义

        #region 命令方法
        public void OkExecute()
        {
           if(SelectDuty!=null)
            {
               if(string.IsNullOrWhiteSpace(SelectDuty.DutyCode))
               {
                   MessageBox.Show("编号不能为空");
                   return;
               }
               if (string.IsNullOrWhiteSpace(SelectDuty.DutyName))
               {
                   MessageBox.Show("名称不能为空");
                   return;
               }
                FundsRegulatoryClient.DutyManageSrv.Duty dt = new FundsRegulatoryClient.DutyManageSrv.Duty();
                dt.DutyID = SelectDuty.DutyId?? Guid.NewGuid().ToString();
                dt.DutyCode = SelectDuty.DutyCode;
                dt.DutyName = SelectDuty.DutyName;
                dt.Describe = SelectDuty.DutyDescribe;
                try
                {
                    if (SelectDuty.DutyId != null)
                    {
                        if (DutyManageClient.Current.UpdateDuty(dt) == "1")
                        {
                            MessageBox.Show("操作成功");
                        }
                    }
                    else
                    {
                        dt.Describe = dt.Describe ?? "";
                        if (DutyManageClient.Current.InsertDuty(dt) == "1")
                        {
                            MessageBox.Show("操作成功");
                        }
                    }
                    if(Owner!=null)
                    {
                        Owner.Close();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }
            }
        }
 
        #endregion 命令方法

        
    }
}