using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using Microsoft.Practices.Prism.ViewModel;
using Microsoft.Practices.Prism.Commands;
using System.Windows;
using Common;
using WSBalanceClient;
using WSBalanceClient.PGPersonAllocateInfoService;
using PersonGold.Views;
using PersonGold.LocalModel;

namespace PersonGold.ViewModels
{
    public class PGPersonAllocateInfoManageVM : NotificationObject
    {
        
        public PGPersonAllocateInfoManageVM()
        {
            AddCommand = new DelegateCommand(AddExecute);
            UpdateCommand = new DelegateCommand(UpdateExecute);
            DeleteCommand = new DelegateCommand(DeleteExecute);
            SearchCommand = new DelegateCommand(SearchExecute);
            SearchInfoModel = new PGPersonAllocateInfo();
            SearchInfoModel.DataTime = DateTime.Now;
            InitialOrderbyRule();
            //SearchExecute();
        }
        #region 属性
        private  PGPersonAllocateInfo _selectedInfoModel;
        /// <summary>
        ///被选中的行 
        /// </summary>
        public PGPersonAllocateInfo SelectedInfoModel
        {
            get { return _selectedInfoModel; }
            set
            {
                _selectedInfoModel = value;
                this.RaisePropertyChanged("SelectedInfoModel");
            }
        }


        private PGPersonAllocateInfo _searchInfoModel;
        /// <summary>
        /// 查询
        /// </summary>
        public PGPersonAllocateInfo SearchInfoModel
        {
            get { return _searchInfoModel; }
            set
            {
                _searchInfoModel = value;
                this.RaisePropertyChanged("SearchInfoModel");
            }
        }
        private ObservableCollection<OrderRule> _OrderRuleList;
        /// <summary>
        /// 集合
        /// </summary>
        public ObservableCollection<OrderRule> OrderRuleList
        {
            get { return _OrderRuleList; }
            set
            {
                _OrderRuleList = value;
                this.RaisePropertyChanged("OrderRuleList");
            }
        }
        private ObservableCollection<PGPersonAllocateInfo> _InfoList;
        /// <summary>
        /// 集合
        /// </summary>
        public ObservableCollection<PGPersonAllocateInfo> PGPersonAllocateInfoList
        {
            get { return _InfoList; }
            set
            {
                _InfoList = value;
                this.RaisePropertyChanged("PGPersonAllocateInfoList");
            }
        }


        private string _Orderbystr;
        /// <summary>
        /// 排序
        /// </summary>
        public string OrderbyStr
        {
            get { return _Orderbystr; }
            set
            {
                _Orderbystr = value;
                this.RaisePropertyChanged("OrderbyStr");
            }
        }
        #endregion
        #region 命令
        public DelegateCommand AddCommand { get; set; }
        public DelegateCommand UpdateCommand { get; set; }
        public DelegateCommand DeleteCommand { get; set; }
        public DelegateCommand SearchCommand { get; set; }
        #endregion
        #region 命令执行方法
        private void AddExecute()
        {
            //PGPersonAllocateInfoAdd ui = new PGPersonAllocateInfoAdd(true, null);
            //ui.ShowDialog();
            //SearchExecute();
        }
        private void UpdateExecute()
        {
            //if (SelectedInfoModel != null)
            //{
            //    PGPersonAllocateInfoAdd ui = new PGPersonAllocateInfoAdd(false, SelectedInfoModel);
            //    ui.ShowDialog();
            //    SearchExecute();
            //}
        }
        private void DeleteExecute()
        {
            if (SelectedInfoModel != null && SelectedInfoModel.ID != null)
            {
                if (MessageBox.Show("是否删除", "消息提示", MessageBoxButton.YesNo) == MessageBoxResult.Yes && WSPGPersonAllocateInfoService.Instance.Delete(SelectedInfoModel))
                {
                    MessageBox.Show("删除成功");
                    SearchExecute();
                }
            }
        }
        private void SearchExecute()
        {
            if (SearchInfoModel == null)
            {
                SearchInfoModel = new PGPersonAllocateInfo();
            }
            if (SearchInfoModel.DataTime ==null)
            {
                MessageBox.Show("日期不能为空");
                return;
            }
            if (string.IsNullOrWhiteSpace(SearchInfoModel.OrderbyColomnName))
            {
                MessageBox.Show("排名规则不能为空");
                return;
            }
            try
            {
                PGPersonAllocateInfoList = new ObservableCollection<PGPersonAllocateInfo>(WSPGPersonAllocateInfoService.Instance.Select(SearchInfoModel));
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(PGPersonAllocateInfoManageVM), ex);
                //throw ex;
            }
            
        }
        #endregion
        #region 内部方法
        private void InitialOrderbyRule()
        {
            OrderRuleList = new ObservableCollection<LocalModel.OrderRule>();
            OrderRuleList.Add(new LocalModel.OrderRule() { OrderbyName = "储蓄日净增排名", Orderbystr = "CardDayGrowth" });
            OrderRuleList.Add(new LocalModel.OrderRule() { OrderbyName = "储蓄月净增排名", Orderbystr = "CardMonthGrowth" });
            OrderRuleList.Add(new LocalModel.OrderRule() { OrderbyName = "储蓄年累计排名", Orderbystr = "CardYearGrowth" });
            OrderRuleList.Add(new LocalModel.OrderRule() { OrderbyName = "保险日净增排名", Orderbystr = "InsuranceDayGrowth" });
            OrderRuleList.Add(new LocalModel.OrderRule() { OrderbyName = "保险月净增排名", Orderbystr = "InsuranceMonthGrowth" });
            OrderRuleList.Add(new LocalModel.OrderRule() { OrderbyName = "保险年累计排名", Orderbystr = "InsuranceYearGrowth" });
            OrderRuleList.Add(new LocalModel.OrderRule() { OrderbyName = "贡献度排名", Orderbystr = "DayContributionDegree" });
            
        }
        #endregion
    }
}
