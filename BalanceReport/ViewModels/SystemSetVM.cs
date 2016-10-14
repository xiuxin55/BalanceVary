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
using BalanceReport.Helper;

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

        private SystemSetInfo ColomnOderbySet;
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


        private ResultOrderBy _SystemSetOrderInfo;
        /// <summary>
        ///列表结果按照哪一列排序
        /// </summary>
        public ResultOrderBy ResultOrderSystemSetInfo
        {
            get
            {
                return _SystemSetOrderInfo;
            }
            set
            {
                _SystemSetOrderInfo = value;
                this.RaisePropertyChanged("ResultOrderSystemSetInfo");
            }
        }
        bool isColomnDisplayAdd = true;
        bool isColomnOrderByAdd = true;
        #endregion
        #region 命令
        public DelegateCommand OkSystemSetCommand { get; set; }

        #endregion

        #region 命令执行方法
        private void OkSystemSetExecute()
        {
            if (isColomnDisplayAdd)
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


            if (isColomnOrderByAdd)
            {
                ResultOrderSystemSetInfo = new ResultOrderBy();
                ColomnOderbySet = new SystemSetInfo();
                ColomnOderbySet.ID = Guid.NewGuid().ToString();
                ColomnOderbySet.SetName = ResultOrderBy.GetSetName();
                ColomnOderbySet.SetContent = ResultOrderSystemSetInfo.ToString();
                client.Add(ColomnOderbySet);
                OrderByColomnHelper.SetOrderByColomn(ColomnOderbySet.SetContent);
            }
            else
            {
                ColomnOderbySet.SetContent = ResultOrderSystemSetInfo.ToString();
                client.Update(ColomnOderbySet);
                OrderByColomnHelper.SetOrderByColomn(ColomnOderbySet.SetContent);
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
            isColomnDisplayAdd = ColomnSet == null;

            ColomnOderbySet = setList != null ? setList.Find(e => e.SetName.ToLower() == ResultOrderBy.GetSetName().ToLower()) : null;
            ResultOrderSystemSetInfo = ColomnOderbySet != null ? ResultOrderBy.SystemSetInfoToOrderBy(ColomnOderbySet) : null;
            isColomnOrderByAdd = ColomnOderbySet == null;
        }
        #endregion
    }
}
