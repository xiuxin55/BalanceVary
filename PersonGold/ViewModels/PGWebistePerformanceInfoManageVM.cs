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
using WSBalanceClient.PGWebistePerformanceInfoService;
using PersonGold.Views;
using Utility;

namespace PersonGold.ViewModels
{
    public class PGWebistePerformanceInfoManageVM :  BaseVM
    {
        
        public PGWebistePerformanceInfoManageVM()
        {

            SearchCommand = new DelegateCommand(SearchExecute);
            SearchExecute();
        }
        #region 属性
        private  PGWebistePerformanceInfo _selectedInfoModel;
        /// <summary>
        ///被选中的行 
        /// </summary>
        public PGWebistePerformanceInfo SelectedInfoModel
        {
            get { return _selectedInfoModel; }
            set
            {
                _selectedInfoModel = value;
                this.RaisePropertyChanged("SelectedInfoModel");
            }
        }


        private PGWebistePerformanceInfo _searchInfoModel;
        /// <summary>
        /// 查询
        /// </summary>
        public PGWebistePerformanceInfo SearchInfoModel
        {
            get { return _searchInfoModel; }
            set
            {
                _searchInfoModel = value;
                this.RaisePropertyChanged("SearchInfoModel");
            }
        }
        private ObservableCollection<PGWebistePerformanceInfo> _InfoList;
        /// <summary>
        /// 集合
        /// </summary>
        public ObservableCollection<PGWebistePerformanceInfo> PGWebistePerformanceInfoList
        {
            get { return _InfoList; }
            set
            {
                _InfoList = value;
                this.RaisePropertyChanged("PGWebistePerformanceInfoList");
            }
        }

        #endregion
        #region 命令
  
        public DelegateCommand SearchCommand { get; set; }
        #endregion
        #region 命令执行方法
        
        private void SearchExecute()
        {
            if (SearchInfoModel == null)
            {
                SearchInfoModel = new PGWebistePerformanceInfo();
            }
            try
            {
                Total = 0;
                SearchInfoModel.StartIndex = 1;
                SearchInfoModel.EndIndex = PageSize;
                PGWebistePerformanceInfoList = new ObservableCollection<PGWebistePerformanceInfo>(WSPGWebistePerformanceInfoService.Instance.Select(SearchInfoModel));
                Total = WSPGWebistePerformanceInfoService.Instance.SelectCount(SearchInfoModel);
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(PGWebistePerformanceInfoManageVM), ex);
                //throw ex;
            }
            
        }

        public override void LoadPageData(int startindex, int endindex)
        {
            SearchInfoModel.StartIndex = startindex;
            SearchInfoModel.EndIndex = endindex;
            PGWebistePerformanceInfoList = new ObservableCollection<PGWebistePerformanceInfo>(WSPGWebistePerformanceInfoService.Instance.Select(SearchInfoModel));
        }
        #endregion
        #region 内部方法

        #endregion
    }
}
