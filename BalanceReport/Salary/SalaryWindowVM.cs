using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using Microsoft.Practices.Prism.ViewModel;
using Microsoft.Practices.Prism.Commands;
using System.Windows;
using BalanceReport.Views;
using Common;
using Utility;
using BalanceReport.LocalModel;

using BalanceReport.Helper;
using BalanceReport.SalaryInfoService;
using BalanceReport.ServiceFile;
using Common.Client;

namespace BalanceReport.Salary
{
    public class SalaryWindowVM : BaseVM
    {

        private SalaryInfoService.SalaryInfoServiceClient client = new SalaryInfoServiceClient();
        private ServiceFile.ServiceFileClient uploadfileclient = new ServiceFileClient();
        public SalaryWindowVM()
        {
            SearchCommand = new DelegateCommand(SearchExecute);
            DeleteCommand = new DelegateCommand(DeleteExecute);
            FlushUpLoadCommand = new DelegateCommand(FlushUpLoadFileExecute);
            LookExceptionCommand = new DelegateCommand(LookExceptionExecute);
            SearchSalaryInfoModel = new SalaryInfo();
            SearchExecute();
            FlushUpLoadFileExecute();
            PageSize = 50;
           
        }
        #region 属性
        private bool _IsSelectAll;
        public bool IsSelectAll
        {
            get
            {
                return _IsSelectAll;
            }
            set
            {
                _IsSelectAll = value;
                foreach (var item in SalaryInfoList)
                {
                    item.IsSelected = value;
                }
            }
        }
        private UploadFileInfo _SelectedUploadFile;
        /// <summary>
        ///被选中的行 
        /// </summary>
        public UploadFileInfo SelectedUploadFile
        {
            get { return _SelectedUploadFile; }
            set
            {
                _SelectedUploadFile = value;
                this.RaisePropertyChanged("SelectedUploadFile");
            }
        }
        private SalaryInfo _SelectSalaryInfoModel;
        /// <summary>
        /// 被选中的行
        /// </summary>
        public SalaryInfo SelectSalaryInfoModel
        {
            get { return _SelectSalaryInfoModel; }
            set
            {
                _SelectSalaryInfoModel = value;
                this.RaisePropertyChanged("SelectSalaryInfoModel");
            }
        }
        private SalaryInfo _searchSalaryInfoModel;
        /// <summary>
        /// 查询
        /// </summary>
        public SalaryInfo SearchSalaryInfoModel
        {
            get { return _searchSalaryInfoModel; }
            set
            {
                _searchSalaryInfoModel = value;
                this.RaisePropertyChanged("SearchSalaryInfoModel");
            }
        }
        private ObservableCollection<SalaryInfo> _SalaryInfoList;
        /// <summary>
        /// 集合
        /// </summary>
        public ObservableCollection<SalaryInfo> SalaryInfoList
        {
            get { return _SalaryInfoList; }
            set
            {
                _SalaryInfoList = value;
                this.RaisePropertyChanged("SalaryInfoList");
            }
        }

        private ObservableCollection<UploadFileInfo> _UploadFileList;
        /// <summary>
        /// 集合
        /// </summary>
        public ObservableCollection<UploadFileInfo> UploadFileList
        {
            get { return _UploadFileList; }
            set
            {
                _UploadFileList = value;
                this.RaisePropertyChanged("UploadFileList");
            }
        }
        

        #endregion
        #region 命令
        public DelegateCommand SearchCommand { get; set; }
        public DelegateCommand FlushUpLoadCommand { get; set; }
        public DelegateCommand LookExceptionCommand { get; set; }
        public DelegateCommand DeleteCommand { get; set; }
        #endregion
        #region 命令执行方法
        private void LookExceptionExecute()
        {
            if (SelectedUploadFile == null)
            {
                MessageBox.Show("请选择一条记录");
            }
            else
            {
                if (string.IsNullOrWhiteSpace(SelectedUploadFile.FileException))
                {
                    MessageBox.Show("该记录无异常");
                }
                else
                {
                    MessageBox.Show(SelectedUploadFile.FileException);
                }
            }
        }
        private void SearchExecute()
        {
            try
            {
                Total = 0;
           
                SearchSalaryInfoModel.OrderbyColomnName = "SalaryTime";
                SearchSalaryInfoModel.SubOrderbyColomnName = "SalaryTime";
                SearchSalaryInfoModel.StartIndex = 1;
                SearchSalaryInfoModel.EndIndex = PageSize;
                SalaryInfoList = new ObservableCollection<SalaryInfo>(client.Select(SearchSalaryInfoModel));
                Total = client.SelectCount(SearchSalaryInfoModel);
                
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(SalaryWindowVM), ex);
            }
            
        }
        private void FlushUpLoadFileExecute()
        {
            UploadFileInfo ui = new UploadFileInfo();
            ui.FileType = FileType.SalaryInfo.ToString();
            UploadFileList=new ObservableCollection<UploadFileInfo>( uploadfileclient.Select(ui));
        }
        public override void LoadPageData(int startindex, int endindex)
        {
            SearchSalaryInfoModel.StartIndex = startindex;
            SearchSalaryInfoModel.EndIndex = endindex;
            SalaryInfoList = new ObservableCollection<SalaryInfo>(client.Select(SearchSalaryInfoModel));
          
        }
        private void DeleteExecute()
        {

            if (MessageBox.Show("是否删除", "消息提示", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                foreach (var item in SalaryInfoList)
                {
                    if (item.IsSelected)
                    {
                        client.Delete(item);
                    }
                }
                MessageBox.Show("删除成功");
                SearchExecute();
            }
        }
        #endregion
        #region 内部方法

        #endregion
    }
}
