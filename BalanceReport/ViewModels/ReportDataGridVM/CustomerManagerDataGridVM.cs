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
using WSBalanceClient.AccountBalanceService;
using WSBalanceClient.CustomerManagerBalanceService;
using BalanceReport.LocalModel;
using WSBalanceClient.SystemSetInfoService;
using BalanceReport.Helper;
using WSBalanceClient;
namespace BalanceReport.ViewModels
{
    public class CustomerManagerDataGridVM : BaseVM
    {
      
        public CustomerManagerDataGridVM()
        {
            SearchCustomerManagerCommand = new DelegateCommand(SearchCustomerManagerExecute);
            SearchAccountCommand = new DelegateCommand(SearchAccountExecute);
            SearchAccountBalanceModel = new WSBalanceClient.AccountBalanceService.DepartmentBalance();
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
        private int _SelectedTabItemIndex;
        public int SelectedTabItemIndex
        {
            get { return _SelectedTabItemIndex; }
            set
            {
                _SelectedTabItemIndex = value;
                if (_SelectedTabItemIndex == 0)
                {
                    SearchCustomerManagerExecute();
                }
                else
                {
                    SearchAccountExecute();
                }
                this.RaisePropertyChanged("SelectedTabItemIndex");
            }
        }
        private DepartmentInfo _selectedDepartmentInfoModel;
        /// <summary>
        ///被选中的行 
        /// </summary>
        public DepartmentInfo SelectedDepartmentInfoModel
        {
            get { return _selectedDepartmentInfoModel??new DepartmentInfo(); }
            set
            {
                _selectedDepartmentInfoModel = value;
                if (SelectedTabItemIndex == 0)
                {
                    SearchCustomerManagerExecute();
                }
                if (SelectedTabItemIndex == 1)
                {
                    SearchAccountExecute();
                }
                this.RaisePropertyChanged("SelectedDepartmentInfoModel");
            }
        }


        private CustomerManagerBalance _searchCustomerManagerBalanceModel;
        /// <summary>
        /// 查询
        /// </summary>
        public CustomerManagerBalance SearchCustomerManagerBalanceoModel
        {
            get { return _searchCustomerManagerBalanceModel; }
            set
            {
                _searchCustomerManagerBalanceModel = value;
                
                this.RaisePropertyChanged("SearchCustomerManagerBalanceoModel");
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


        private ObservableCollection<CustomerManagerBalance> _CustomerManagerBalanceList;
        /// <summary>
        /// 集合
        /// </summary>
        public ObservableCollection<CustomerManagerBalance> CustomerManagerBalanceList
        {
            get { return _CustomerManagerBalanceList; }
            set
            {
                _CustomerManagerBalanceList = value;
                this.RaisePropertyChanged("CustomerManagerBalanceList");
            }
        }

        private WSBalanceClient.AccountBalanceService.DepartmentBalance _searchAccountBalanceModel;
        /// <summary>
        /// 查询
        /// </summary>
        public WSBalanceClient.AccountBalanceService.DepartmentBalance SearchAccountBalanceModel
        {
            get { return _searchAccountBalanceModel; }
            set
            {
                _searchAccountBalanceModel = value;

                this.RaisePropertyChanged("SearchAccountBalanceModel");
            }
        }
        private ObservableCollection<AccountBalance> _AccountBalanceList;
        /// <summary>
        /// 集合
        /// </summary>
        public ObservableCollection<AccountBalance> AccountBalanceList
        {
            get { return _AccountBalanceList; }
            set
            {
                _AccountBalanceList = value;
                this.RaisePropertyChanged("AccountBalanceList");
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
        public DelegateCommand SearchCustomerManagerCommand { get; set; }
        public DelegateCommand SearchAccountCommand { get; set; }

        #endregion
        #region 命令执行方法
        private void SearchAccountExecute()
        {
            Total = 0;
            //if (SearchAccountBalanceModel == null)
            //{
            //    SearchAccountBalanceModel = new AccountBalanceService.DepartmentBalance();
            //}
            SearchAccountBalanceModel = new WSBalanceClient.AccountBalanceService.DepartmentBalance();
            SearchAccountBalanceModel.OrderbyColomnName = OrderByColomnHelper.GetOrderByColomn();
            SearchAccountBalanceModel.SubOrderbyColomnName = OrderByColomnHelper.GetSubOrderByColomn();
            SearchAccountBalanceModel.DepartmentID = SelectedDepartmentInfoModel.DepartmentID;
            SearchAccountBalanceModel.DepartmentName = SelectedDepartmentInfoModel.DepartmentName == "全部" ? null : SelectedDepartmentInfoModel.DepartmentName;
            SearchAccountBalanceModel.StartIndex = 1;
            SearchAccountBalanceModel.EndIndex = PageSize;
            if (BalanceModeHelper.GetBalanceModeobj().EveryDayBalance)
            {
                AccountBalanceList = new ObservableCollection<AccountBalance>(WSAccountBalanceService.Instance.SelectByDepartment(SearchAccountBalanceModel));
            }
            else
            {
                SearchAccountBalanceModel.StartBalanceTime = SearchAccountBalanceModel.StartBalanceTime ?? DateTime.Parse(DateTime.Now.AddDays(-1).ToShortDateString());
                SearchAccountBalanceModel.EndBalanceTime = SearchAccountBalanceModel.EndBalanceTime ?? DateTime.Parse(DateTime.Now.ToShortDateString());

               // AccountBalanceList = new ObservableCollection<AccountBalance>(WSAccountBalanceService.Instance.SelectByDepartment(SearchAccountBalanceModel));
            }
          
            Total = WSAccountBalanceService.Instance.SelectByDepartmentCount(SearchAccountBalanceModel);
        }
        private void SearchCustomerManagerExecute()
        {
            Total = 0;
            if (SearchCustomerManagerBalanceoModel == null)
            {
                SearchCustomerManagerBalanceoModel = new CustomerManagerBalance();
            }
        
            SearchCustomerManagerBalanceoModel.OrderbyColomnName = OrderByColomnHelper.GetOrderByColomn();
            SearchCustomerManagerBalanceoModel.SubOrderbyColomnName = OrderByColomnHelper.GetSubOrderByColomn();
            SearchCustomerManagerBalanceoModel.DepartmentID = SelectedDepartmentInfoModel.DepartmentID;
            SearchCustomerManagerBalanceoModel.DepartmentName = SelectedDepartmentInfoModel.DepartmentName=="全部"? null: SelectedDepartmentInfoModel.DepartmentName;
            SearchCustomerManagerBalanceoModel.StartIndex = 1;
            SearchCustomerManagerBalanceoModel.EndIndex = PageSize;
            if (BalanceModeHelper.GetBalanceModeobj().EveryDayBalance)
            {
                CustomerManagerBalanceList = new ObservableCollection<CustomerManagerBalance>(WSCustomerManagerBalanceService.Instance.Select(SearchCustomerManagerBalanceoModel));
            }
            else
            {
                SearchCustomerManagerBalanceoModel.StartBalanceTime = SearchCustomerManagerBalanceoModel.StartBalanceTime ?? DateTime.Parse(DateTime.Now.AddDays(-1).ToShortDateString());
                SearchCustomerManagerBalanceoModel.EndBalanceTime = SearchCustomerManagerBalanceoModel.EndBalanceTime ?? DateTime.Parse(DateTime.Now.ToShortDateString());

                CustomerManagerBalanceList = new ObservableCollection<CustomerManagerBalance>(WSCustomerManagerBalanceService.Instance.CallTimeSpanProc(SearchCustomerManagerBalanceoModel));
                SearchCustomerManagerBalanceoModel.BalanceTime = SearchCustomerManagerBalanceoModel.StartBalanceTime;
            }
            Total = WSCustomerManagerBalanceService.Instance.SelectCount(SearchCustomerManagerBalanceoModel);
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
            if (SelectedTabItemIndex == 0)
            {
                SearchCustomerManagerBalanceoModel.StartIndex = startindex;
                SearchCustomerManagerBalanceoModel.EndIndex = endindex;
                if (BalanceModeHelper.GetBalanceModeobj().EveryDayBalance)
                {
                    CustomerManagerBalanceList = new ObservableCollection<CustomerManagerBalance>(WSCustomerManagerBalanceService.Instance.Select(SearchCustomerManagerBalanceoModel));
                }
                else
                {
                    CustomerManagerBalanceList = new ObservableCollection<CustomerManagerBalance>(WSCustomerManagerBalanceService.Instance.CallTimeSpanProc(SearchCustomerManagerBalanceoModel));

                }
            }
            if (SelectedTabItemIndex == 1)
            {
                SearchAccountBalanceModel.StartIndex = startindex;
                SearchAccountBalanceModel.EndIndex = endindex;
                if (BalanceModeHelper.GetBalanceModeobj().EveryDayBalance)
                {
                    AccountBalanceList = new ObservableCollection<AccountBalance>(WSAccountBalanceService.Instance.SelectByDepartment(SearchAccountBalanceModel));
                }
                else
                {
                    // AccountBalanceList = new ObservableCollection<AccountBalance>(WSAccountBalanceService.Instance.SelectByDepartment(SearchAccountBalanceModel));

                }
            }
        }
        #endregion
        #region 内部方法

        #endregion
    }
}
