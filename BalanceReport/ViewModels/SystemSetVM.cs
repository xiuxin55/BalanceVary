using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Prism.ViewModel;
using Microsoft.Practices.Prism.Commands;
using System.Windows;
using System.Collections.ObjectModel;
using BalanceReport.SystemSetInfoService;
using BalanceReport.LocalModel;

namespace BalanceReport.ViewModels
{
    public class SystemSetVM : NotificationObject
    {
        private SystemSetInfoService.SystemSetInfoServiceClient client = new SystemSetInfoServiceClient();
        public SystemSetVM()
        {
            OkAccountCommand = new DelegateCommand(OkAccountExecute);
            LoadData();
        }
        #region 属性
        private DataGridColomnState _SystemSetInfo;
        /// <summary>
        ///列是否显示设置
        /// </summary>
        public DataGridColomnState ColomnStateSystemSetInfo
        {
            get {
                if (_SystemSetInfo==null)
                {
                    _SystemSetInfo = new DataGridColomnState();
                    _SystemSetInfo.RegularVaryColomnState = true;
                    _SystemSetInfo.UnRegularVaryColomnState = true;
                    _SystemSetInfo.AmountVaryColomnState = true;
                }
                return _SystemSetInfo; }
            set
            {
                _SystemSetInfo = value;
                this.RaisePropertyChanged("ColomnStateSystemSetInfo");
            }
        }

        #endregion
        #region 命令
        public DelegateCommand OkAccountCommand { get; set; }

        #endregion
        #region 命令执行方法
        private void OkAccountExecute()
        {
           
        }


        #endregion
        #region 内部方法
        private void LoadData()
        {
            List<SystemSetInfo> setList = new List<SystemSetInfo>(client.Select(null));
            SystemSetInfo colomnset = setList != null? setList.Find(e => e.SetName.ToLower() == DataGridColomnState.GetSetName().ToLower()):null;
            ColomnStateSystemSetInfo = colomnset!=null? DataGridColomnState.SystemSetInfoToState(colomnset):null;
        }
        #endregion
    }
}
