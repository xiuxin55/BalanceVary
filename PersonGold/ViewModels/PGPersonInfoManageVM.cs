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
using WSBalanceClient.PGPersonInfoService;

namespace PersonGold.ViewModels
{
    public class PGPersonInfoManageVM : NotificationObject
    {
        
        public PGPersonInfoManageVM()
        {
            AddCommand = new DelegateCommand(AddExecute);
            UpdateCommand = new DelegateCommand(UpdateExecute);
            DeleteCommand = new DelegateCommand(DeleteExecute);
            SearchCommand = new DelegateCommand(SearchExecute);
            SearchExecute();
        }
        #region 属性
        private  PGPersonInfo _selectedInfoModel;
        /// <summary>
        ///被选中的行 
        /// </summary>
        public PGPersonInfo SelectedInfoModel
        {
            get { return _selectedInfoModel; }
            set
            {
                _selectedInfoModel = value;
                this.RaisePropertyChanged("SelectedInfoModel");
            }
        }


        private PGPersonInfo _searchInfoModel;
        /// <summary>
        /// 查询
        /// </summary>
        public PGPersonInfo SearchInfoModel
        {
            get { return _searchInfoModel; }
            set
            {
                _searchInfoModel = value;
                this.RaisePropertyChanged("SearchInfoModel");
            }
        }
        private ObservableCollection<PGPersonInfo> _InfoList;
        /// <summary>
        /// 集合
        /// </summary>
        public ObservableCollection<PGPersonInfo> PGPersonInfoList
        {
            get { return _InfoList; }
            set
            {
                _InfoList = value;
                this.RaisePropertyChanged("PGPersonInfoList");
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
            //Add waui = new Add(true, null);
            //waui.ShowDialog();
            SearchExecute();
        }
        private void UpdateExecute()
        {
            if (SelectedInfoModel != null)
            {
                //Add waui = new Add(false, SelectedInfoModel);
                //waui.ShowDialog();
                SearchExecute();
            }
        }
        private void DeleteExecute()
        {
            if (SelectedInfoModel != null && SelectedInfoModel.ID != null)
            {
                if (MessageBox.Show("是否删除", "消息提示", MessageBoxButton.YesNo) == MessageBoxResult.Yes && WSPGPersonInfoService.Instance.Delete(SelectedInfoModel))
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
                SearchInfoModel = new PGPersonInfo();
            }
            try
            {
                PGPersonInfoList = new ObservableCollection<PGPersonInfo>(WSPGPersonInfoService.Instance.Select(SearchInfoModel));
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(PGPersonInfoManageVM), ex);
                //throw ex;
            }
            
        }
        #endregion
        #region 内部方法

        #endregion
    }
}
