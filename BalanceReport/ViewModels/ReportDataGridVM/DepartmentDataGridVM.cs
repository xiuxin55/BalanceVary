using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using Microsoft.Practices.Prism.ViewModel;
using Microsoft.Practices.Prism.Commands;
using System.Windows;
using BalanceReport.Views;
using BalanceReport.DepartmentInfoService;
using Common;
using BalanceReport.DepartmentBalanceService;
using Utility;
using BalanceReport.LocalModel;
using BalanceReport.SystemSetInfoService;
using BalanceReport.Helper;

namespace BalanceReport.ViewModels
{
    public class DepartmentDataGridVM: BaseVM
    {
        private DepartmentInfoService.DepartmentInfoServiceClient clientDepartment = new DepartmentInfoServiceClient();
        private DepartmentBalanceServiceClient clientDepartmentBalance = new DepartmentBalanceServiceClient();
      
        public DepartmentDataGridVM()
        {
            SearchDepartmentCommand = new DelegateCommand(SearchDepartmentExecute);
            LoadData();
        }
        #region 属性
        private DataGridColomnState _ColomnState;
        public DataGridColomnState ColomnState
        {
            get { return _ColomnState; }
            set
            {
                _ColomnState = value;
                RaisePropertyChanged("ColomnState");
            }

        }
        private DepartmentInfo _selectedDepartmentInfoModel;
        /// <summary>
        ///被选中的行 
        /// </summary>
        public DepartmentInfo SelectedDepartmentInfoModel
        {
            get { return _selectedDepartmentInfoModel; }
            set
            {
                _selectedDepartmentInfoModel = value;
                SearchDepartmentExecute();
                this.RaisePropertyChanged("SelectedDepartmentInfoModel");
            }
        }


        private DepartmentBalance _searchDepartmentBalanceModel;
        /// <summary>
        /// 查询
        /// </summary>
        public DepartmentBalance SearchDepartmentBalanceoModel
        {
            get { return _searchDepartmentBalanceModel; }
            set
            {
                _searchDepartmentBalanceModel = value;
                
                this.RaisePropertyChanged("SearchDepartmentBalanceoModel");
            }
        }
        private ObservableCollection<DepartmentInfo> _DepartmentInfoList;
        /// <summary>
        /// 网点集合
        /// </summary>
        public ObservableCollection<DepartmentInfo> DepartmentInfoList
        {
            get { return _DepartmentInfoList; }
            set
            {
                _DepartmentInfoList = value;
                this.RaisePropertyChanged("DepartmentInfoList");
            }
        }


        private ObservableCollection<DepartmentBalance> _DepartmentBalanceList;
        /// <summary>
        /// 集合
        /// </summary>
        public ObservableCollection<DepartmentBalance> DepartmentBalanceList
        {
            get { return _DepartmentBalanceList; }
            set
            {
                _DepartmentBalanceList = value;
                this.RaisePropertyChanged("DepartmentBalanceList");
            }
        }
       
        #endregion
        #region 命令
        public DelegateCommand SearchDepartmentCommand { get; set; }
        #endregion
        #region 命令执行方法
   
        private void SearchDepartmentExecute()
        {
            Total = 0;
            SearchDepartmentBalanceoModel = new DepartmentBalance();
            SearchDepartmentBalanceoModel.OrderbyColomnName = OrderByColomnHelper.GetOrderByColomn();
            SearchDepartmentBalanceoModel.DepartmentID = SelectedDepartmentInfoModel.DepartmentID;
            SearchDepartmentBalanceoModel.DepartmentName = SelectedDepartmentInfoModel.DepartmentName=="全部"? null: SelectedDepartmentInfoModel.DepartmentName;
            SearchDepartmentBalanceoModel.StartIndex = 1;
            SearchDepartmentBalanceoModel.EndIndex = PageSize;
            DepartmentBalanceList = new ObservableCollection<DepartmentBalance>(clientDepartmentBalance.Select(SearchDepartmentBalanceoModel));
            Total = clientDepartmentBalance.SelectCount(SearchDepartmentBalanceoModel);
        }

        private void LoadData()
        {
            try
            {
                DepartmentInfo model = new DepartmentInfo();
               
                DepartmentInfoList = new ObservableCollection<DepartmentInfo>(clientDepartment.Select(model));
                model.DepartmentName = "全部";
                DepartmentInfoList.Insert(0, model);

                SystemSetInfoService.SystemSetInfoServiceClient clientSystemSetInfo = new SystemSetInfoServiceClient();
                List<SystemSetInfo> setList = new List<SystemSetInfo>(clientSystemSetInfo.Select(null));
                SystemSetInfo ColomnSet = setList != null ? setList.Find(e => e.SetName.ToLower() == DataGridColomnState.GetSetName().ToLower()) : null;
                ColomnState = ColomnSet != null ? DataGridColomnState.SystemSetInfoToState(ColomnSet) : null;
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(DepartmentDataGridVM), ex);
            }
        }

        public override void LoadPageData(int startindex, int endindex)
        {

            SearchDepartmentBalanceoModel.StartIndex = startindex;
            SearchDepartmentBalanceoModel.EndIndex = endindex;
            DepartmentBalanceList = new ObservableCollection<DepartmentBalance>(clientDepartmentBalance.Select(SearchDepartmentBalanceoModel));
        }
        #endregion
        #region 内部方法

        #endregion
    }
}
