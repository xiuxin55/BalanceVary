using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using Microsoft.Practices.Prism.ViewModel;
using Microsoft.Practices.Prism.Commands;
using System.Windows;
using BalanceReport.Views;
using WSBalanceClient.DepartmentInfoService;
using Common;
using WSBalanceClient.DepartmentBalanceService;
using Utility;
using BalanceReport.LocalModel;
using WSBalanceClient.SystemSetInfoService;
using BalanceReport.Helper;
using WSBalanceClient;
namespace BalanceReport.ViewModels
{
    public class DepartmentDataGridVM: BaseVM
    {
       
        public DepartmentDataGridVM()
        {
            SearchDepartmentCommand = new DelegateCommand(SearchDepartmentExecute);
            SearchDepartmentBalanceoModel = new DepartmentBalance();
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
            get { return _selectedDepartmentInfoModel ?? new DepartmentInfo(); ; }
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
        private BalanceMode _Mode;
        /// <summary>
        /// 余额模式
        /// </summary>
        public BalanceMode Mode
        {
            get { return _Mode; }
            set
            {
                _Mode = value;
                this.RaisePropertyChanged("Mode");
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
            //if (SearchDepartmentBalanceoModel == null)
            //{
            //    SearchDepartmentBalanceoModel = new DepartmentBalance();
            //}
            SearchDepartmentBalanceoModel.OrderbyColomnName = OrderByColomnHelper.GetOrderByColomn();
            SearchDepartmentBalanceoModel.SubOrderbyColomnName = OrderByColomnHelper.GetSubOrderByColomn();
            SearchDepartmentBalanceoModel.DepartmentID = SelectedDepartmentInfoModel.DepartmentID;
            SearchDepartmentBalanceoModel.DepartmentName = SelectedDepartmentInfoModel.DepartmentName=="全部"? null: SelectedDepartmentInfoModel.DepartmentName;
            SearchDepartmentBalanceoModel.StartIndex = 1;
            SearchDepartmentBalanceoModel.EndIndex = PageSize;
            if (BalanceModeHelper.GetBalanceModeobj().EveryDayBalance)
            {
                DepartmentBalanceList = new ObservableCollection<DepartmentBalance>(WSDepartmentBalanceService.Instance.Select(SearchDepartmentBalanceoModel));
            }
            else
            {
                SearchDepartmentBalanceoModel.StartBalanceTime = SearchDepartmentBalanceoModel.StartBalanceTime ?? DateTime.Parse(DateTime.Now.AddDays(-1).ToShortDateString());
                SearchDepartmentBalanceoModel.EndBalanceTime = SearchDepartmentBalanceoModel.EndBalanceTime ?? DateTime.Parse(DateTime.Now.ToShortDateString());
                 
                DepartmentBalanceList = new ObservableCollection<DepartmentBalance>(WSDepartmentBalanceService.Instance.CallTimeSpanProc(SearchDepartmentBalanceoModel));
                SearchDepartmentBalanceoModel.BalanceTime = SearchDepartmentBalanceoModel.StartBalanceTime;

            }
            Total = WSDepartmentBalanceService.Instance.SelectCount(SearchDepartmentBalanceoModel);
        }

        private void LoadData()
        {
            try
            {
                DepartmentInfo model = new DepartmentInfo();
               
                DepartmentInfoList = new ObservableCollection<DepartmentInfo>(WSDepartmentInfoService.Instance.Select(model));
                model.DepartmentName = "全部";
                DepartmentInfoList.Insert(0, model);

               
                List<SystemSetInfo> setList = new List<SystemSetInfo>(WSSystemSetInfoService.Instance.Select(null));
                SystemSetInfo ColomnSet = setList != null ? setList.Find(e => e.SetName.ToLower() == DataGridColomnState.GetSetName().ToLower()) : null;
                ColomnState = ColomnSet != null ? DataGridColomnState.SystemSetInfoToState(ColomnSet) : null;
                Mode = BalanceModeHelper.GetBalanceModeobj();

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
            if (BalanceModeHelper.GetBalanceModeobj().EveryDayBalance)
            {
                DepartmentBalanceList = new ObservableCollection<DepartmentBalance>(WSDepartmentBalanceService.Instance.Select(SearchDepartmentBalanceoModel));
            }
            else
            {
                DepartmentBalanceList = new ObservableCollection<DepartmentBalance>(WSDepartmentBalanceService.Instance.CallTimeSpanProc(SearchDepartmentBalanceoModel));

            }
        }
        #endregion
        #region 内部方法

        #endregion
    }
}
