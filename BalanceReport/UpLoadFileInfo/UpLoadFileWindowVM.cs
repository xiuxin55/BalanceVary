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
using UserAuthorization.UserInfoService;

namespace BalanceReport.Salary
{
    public class UpLoadFileWindowVM : BaseVM
    {

        private ServiceFile.ServiceFileClient uploadfileclient = new ServiceFileClient();
        public UpLoadFileWindowVM()
        {

            FlushUpLoadCommand = new DelegateCommand(FlushUpLoadFileExecute);
            LookExceptionCommand = new DelegateCommand(LookExceptionExecute);
            HandleCommand = new DelegateCommand(HandleExecute);
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
        public DelegateCommand HandleCommand { get; set; }
        
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
        private void FlushUpLoadFileExecute()
        {
            UploadFileInfo ui = new UploadFileInfo();
            UserInfo CurrentUser = (UserInfo)AuthorizationContraint.CurrentUser;
            if (CurrentUser==null|| string.IsNullOrWhiteSpace(CurrentUser.UserName))
            {
                return;
            }
            if (!UserAuthorization.Helper.UserLoginHelper.Instance.CheckAuthrization(typeof(UpLoadFileWindow).FullName))
            {
                ui.UpLoadPersonCode = CurrentUser.UserName;
            }
            
            UploadFileList=new ObservableCollection<UploadFileInfo>( uploadfileclient.Select(ui));
        }
        private void HandleExecute()
        {
            try
            {
                if (SelectedUploadFile == null)
                {
                    MessageBox.Show("请选择一条记录");
                }
                else
                {
                    SelectedUploadFile.FileException = "";
                    uploadfileclient.ClientTriggerHandleFile(SelectedUploadFile);
                    MessageBox.Show("正在处理，请稍后点击刷新");
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }
        public override void LoadPageData(int startindex, int endindex)
        {
            ;
        }

        #endregion
        #region 内部方法

        #endregion
    }
}
