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
            OkSystemSetCommand = new DelegateCommand(OkSystemSetExecute);
            LoadData();
        }
        #region 属性
        private SystemSetInfo ColomnSet;
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
        bool isAdd = true;
        #endregion
        #region 命令
        public DelegateCommand OkSystemSetCommand { get; set; }

        #endregion

        #region 命令执行方法
        private void OkSystemSetExecute()
        {
            if (isAdd)
            {
                ColomnSet = new SystemSetInfo();
                ColomnSet.ID = Guid.NewGuid().ToString();
                ColomnSet.SetName = DataGridColomnState.GetSetName();
                ColomnSet.SetContent = ColomnStateSystemSetInfo.ToString();
                client.Add(ColomnSet);
            }
            else
            {
                ColomnSet.SetContent = ColomnStateSystemSetInfo.ToString();
                client.Update(ColomnSet);
            }
            MessageBox.Show("操作成功");
        }


        #endregion
        #region 内部方法
        private void LoadData()
        {
            List<SystemSetInfo> setList = new List<SystemSetInfo>(client.Select(null));
            ColomnSet = setList != null? setList.Find(e => e.SetName.ToLower() == DataGridColomnState.GetSetName().ToLower()):null;
            ColomnStateSystemSetInfo = ColomnSet != null? DataGridColomnState.SystemSetInfoToState(ColomnSet) :null;
            isAdd = ColomnSet == null;
        }
        #endregion
    }
}
