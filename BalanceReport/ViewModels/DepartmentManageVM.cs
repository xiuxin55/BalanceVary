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
using WSBalanceClient;
namespace BalanceReport.ViewModels
{
    public class DepartmentManageVM : NotificationObject
    {
        
        public DepartmentManageVM()
        {
            AddDepartmentCommand = new DelegateCommand(AddDepartmentExecute);
            UpdateDepartmentCommand = new DelegateCommand(UpdateDepartmentExecute);
            DeleteDepartmentCommand = new DelegateCommand(DeleteDepartmentExecute);
            SearchDepartmentCommand = new DelegateCommand(SearchDepartmentExecute);
            SearchDepartmentExecute();
        }
        #region 属性
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
                this.RaisePropertyChanged("SelectedDepartmentInfoModel");
            }
        }


        private DepartmentInfo _searchDepartmentInfoModel;
        /// <summary>
        /// 查询
        /// </summary>
        public DepartmentInfo SearchDepartmentInfoModel
        {
            get { return _searchDepartmentInfoModel; }
            set
            {
                _searchDepartmentInfoModel = value;
                this.RaisePropertyChanged("SearchDepartmentInfoModel");
            }
        }
        private ObservableCollection<DepartmentInfo> _DepartmentInfoList;
        /// <summary>
        /// 集合
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

        #endregion
        #region 命令
        public DelegateCommand AddDepartmentCommand { get; set; }
        public DelegateCommand UpdateDepartmentCommand { get; set; }
        public DelegateCommand DeleteDepartmentCommand { get; set; }
        public DelegateCommand SearchDepartmentCommand { get; set; }
        #endregion
        #region 命令执行方法
        private void AddDepartmentExecute()
        {
            DepartmentAdd waui = new DepartmentAdd(true, null);
            waui.ShowDialog();
            SearchDepartmentExecute();
        }
        private void UpdateDepartmentExecute()
        {
            if (SelectedDepartmentInfoModel != null)
            {
                DepartmentAdd waui = new DepartmentAdd(false, SelectedDepartmentInfoModel);
                waui.ShowDialog();
                SearchDepartmentExecute();
            }
        }
        private void DeleteDepartmentExecute()
        {
            if (SelectedDepartmentInfoModel != null && SelectedDepartmentInfoModel.ID != null)
            {
                if (MessageBox.Show("是否删除", "消息提示", MessageBoxButton.YesNo) == MessageBoxResult.Yes && WSDepartmentInfoService.Instance.Delete(SelectedDepartmentInfoModel))
                {
                    MessageBox.Show("删除成功");
                    SearchDepartmentExecute();
                }
            }
        }
        private void SearchDepartmentExecute()
        {
            if (SearchDepartmentInfoModel == null)
            {
                SearchDepartmentInfoModel = new DepartmentInfo();
            }
            try
            {
                DepartmentInfoList = new ObservableCollection<DepartmentInfo>(WSDepartmentInfoService.Instance.Select(SearchDepartmentInfoModel));
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(DepartmentManageVM), ex);
                throw ex;
            }
            
        }
        #endregion
        #region 内部方法

        #endregion
    }
}
