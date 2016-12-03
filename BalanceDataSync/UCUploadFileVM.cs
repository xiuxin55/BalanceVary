using BalanceBLL;
using BalanceModel;
using Common;
using Common.Server;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using Utility;


namespace BalanceDataSync
{
    public class UCUploadFileVM : NotificationObject
    {
        UploadFileInfoBLL bll = new UploadFileInfoBLL();
        public UCUploadFileVM()
        {
            HandleFileCommand = new DelegateCommand(HandleFileExecute);
            DeleteFileCommand = new DelegateCommand(DeleteFileExecute);
            LookExceptionCommand = new DelegateCommand(LookExceptionExecute);
            SearchCommand = new DelegateCommand(SearchExecute);
            SearchExecute();
            #region 上传文件后触发
            CommonEvent.FileUploadedCalculateEvent += CalculateEvent;
            CommonEvent.FileUploadedCalculateDayEvent += CalculateDayEvent;
            CommonEvent.FileUploadedCustomerLinkEvent += CustomerLinkEvent;
            CommonEvent.FileUploadedAccountAndNameLinkEvent += AccountAndNameLinkEvent;
            CommonEvent.FileUploadedSalaryEvent += SalaryEvent;
            CommonEvent.PersonInfoDataEvent += PersonInfoEvent;
            CommonEvent.PGDebitCardInfoDataEvent += PGDebitCardInfoData;
            CommonEvent.PGInsuranceInfoDataEvent += PGInsuranceInfoData;
            CommonEvent.PGCreditCardInfoInfoDataEvent += PGCreditCardInfoInfoData;
            CommonEvent.PGCardBaseDataEvent += PGCardBaseData;
            CommonEvent.PGInsuranceBaseDataEvent += PGInsuranceBaseData;
            #endregion

        }
        #region 属性
        private UploadFileInfo  _SelectedUploadFile;
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
        private ObservableCollection<UploadFileInfo> _UploadFileList;
        /// <summary>
        /// 文件信息集合
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

        private string _CurrentCalculateFile;
        /// <summary>
        /// 当前正在计算的文件
        /// </summary>
        public string CurrentCalculateFile
        {
            get { return _CurrentCalculateFile; }
            set
            {
                _CurrentCalculateFile = value;
                this.RaisePropertyChanged("CurrentCalculateFile");
            }
        }
        
        #endregion
        #region 命令
        public DelegateCommand HandleFileCommand { get; set; }
        public DelegateCommand DeleteFileCommand { get; set; }
        public DelegateCommand LookExceptionCommand { get; set; }
        
        public DelegateCommand SearchCommand { get; set; }
        #endregion
       
        //#region 命令执行方法
        /// <summary>
        /// 计算文件中数据
        /// </summary>
        private void HandleFileExecute()
        {
            try
            {
                if (UploadFileList==null || UploadFileList.Count==0)
                {
                    return;
                }
                foreach (var item in UploadFileList)
                {
                    item.FileException = null;
                }
                List<UploadFileInfo> files = UploadFileList.ToList();
                files.Sort(
                    (x, y) =>
                    {
                        if (x.FileDateTime>y.FileDateTime)
                        {
                            return 1;
                        }
                        else
                        {
                            return -1;
                        }
                    });
                SyncDataHandler syn = new SyncDataHandler(files.Where(e => e.IsSelected).ToList());
                syn.NotifyFileStateChange = NotifyCurrentCalculateFile;
                MultiTask.TaskDispatcherWithUI(new Action(syn.ImportMonthData), this.SynComplete, UploadFileList.ToList(), Application.Current.MainWindow.Dispatcher);
                MultiTask.TaskDispatcherWithUI(new Action(syn.ImportCustomerLink), this.SynComplete, UploadFileList.ToList(), Application.Current.MainWindow.Dispatcher);
                MultiTask.TaskDispatcherWithUI(new Action(syn.ImportAccountAndNameLink), this.SynComplete, UploadFileList.ToList(), Application.Current.MainWindow.Dispatcher);
                MultiTask.TaskDispatcherWithUI(new Action(syn.ImportSalaryInfo), this.SynComplete, UploadFileList.ToList(), Application.Current.MainWindow.Dispatcher);
                MultiTask.TaskDispatcherWithUI(new Action(syn.ImportPGPersonInfo), this.SynComplete, UploadFileList.ToList(), Application.Current.MainWindow.Dispatcher);
                MultiTask.TaskDispatcherWithUI(new Action(syn.ImportPGDebitCardInfo), this.SynComplete, UploadFileList.ToList(), Application.Current.MainWindow.Dispatcher);
                MultiTask.TaskDispatcherWithUI(new Action(syn.ImportPGInsuranceInfo), this.SynComplete, UploadFileList.ToList(), Application.Current.MainWindow.Dispatcher);
                MultiTask.TaskDispatcherWithUI(new Action(syn.ImportPGCreditCardInfo), this.SynComplete, UploadFileList.ToList(), Application.Current.MainWindow.Dispatcher);
                MultiTask.TaskDispatcherWithUI(new Action(syn.ImportPGCardBaseData), this.SynComplete, UploadFileList.ToList(), Application.Current.MainWindow.Dispatcher);
            }
            catch (Exception ex)
            {

                LogHelper.WriteLog(typeof(UCUploadFileVM), ex);
                throw ex;
            }

        }

        #region 命令方法
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
        /// <summary>
        /// 删除文件
        /// </summary>
        private void DeleteFileExecute()
        {
            try
            {
                bool ishasseleted = false;
                foreach (var item in UploadFileList)
                {
                    if (item.IsSelected)
                    {
                        ishasseleted = true;
                        if (bll.Delete(item))
                        {
                            if (File.Exists(item.FilePath + item.FileName))
                            {
                                File.Delete(item.FilePath + item.FileName);
                            }

                        }
                    }
                }
                if (ishasseleted)
                {
                    MessageBox.Show("删除成功");
                }

                SearchExecute();
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(UCUploadFileVM), ex);
            }
        }
        private bool _isSelectedAll;
        public bool IsSelectedAll
        {
            get
            {
                return _isSelectedAll;
            }
            set
            {
                _isSelectedAll = value;
                CheckBoxClickExecute(value);
                this.RaisePropertyChanged("IsSelectedAll");
            }
        }
        private void CheckBoxClickExecute(bool obj)
        {

            foreach (var item in UploadFileList)
            {
                item.IsSelected = obj;
            }
        }
        private void SearchExecute()
        {
            try
            {
                UploadFileList = new ObservableCollection<UploadFileInfo>(bll.Select(null));
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(UCUploadFileVM), ex);
                throw ex;
            }
        } 
        #endregion


        public void NotifyCurrentCalculateFile(UploadFileInfo info)
        {
            if (info.FileState == 2)
            {
                this.CurrentCalculateFile = info.FileName + " 处理出现异常";
                bll.Update(info);
                SearchExecute();
            }
            else
            {
                this.CurrentCalculateFile = info.FileName;
            }

        }
        /// <summary>
        /// 同步数据完成
        /// </summary>
        public void SynComplete(object obj)
        {
            List<UploadFileInfo> ufiList = obj as List<UploadFileInfo>;
            if (ufiList == null || ufiList.Count==0)
            {
                CurrentCalculateFile = "所有文件处理结束";
                return;
            }
            bll.BatchUpdate(ufiList);
            SearchExecute();

            CurrentCalculateFile = "所有文件处理结束";
        }


        #region 上传文件触发方法

        private void CalculateEvent(object obj)
        {
            UploadFileInfo info = obj as UploadFileInfo;
            if (info != null)
            {
                List<UploadFileInfo> temp = new List<UploadFileInfo>();
                temp.Add(info);
                SyncDataHandler syn = new SyncDataHandler(temp);
                syn.NotifyFileStateChange = NotifyCurrentCalculateFile;
                MultiTask.TaskDispatcherWithUI(new Action(syn.ImportMonthData), this.SynComplete, temp, Application.Current.MainWindow.Dispatcher);
            }
        }
        private void CalculateDayEvent(object obj)
        {
            UploadFileInfo info = obj as UploadFileInfo;
            if (info != null)
            {
                List<UploadFileInfo> temp = new List<UploadFileInfo>();
                temp.Add(info);
                SyncDataHandler syn = new SyncDataHandler(temp);
                syn.NotifyFileStateChange = NotifyCurrentCalculateFile;
                MultiTask.TaskDispatcherWithUI(new Action(syn.ImportDayData), this.SynComplete, temp, Application.Current.MainWindow.Dispatcher);
            }
        }

        private void CustomerLinkEvent(object obj)
        {
            UploadFileInfo info = obj as UploadFileInfo;
            if (info != null)
            {
                List<UploadFileInfo> temp = new List<UploadFileInfo>();
                temp.Add(info);
                SyncDataHandler syn = new SyncDataHandler(temp);
                syn.NotifyFileStateChange = NotifyCurrentCalculateFile;
                MultiTask.TaskDispatcherWithUI(new Action(syn.ImportCustomerLink), this.SynComplete, temp, Application.Current.MainWindow.Dispatcher);
            }
        }

        private void AccountAndNameLinkEvent(object obj)
        {
            UploadFileInfo info = obj as UploadFileInfo;
            if (info != null)
            {
                List<UploadFileInfo> temp = new List<UploadFileInfo>();
                temp.Add(info);
                SyncDataHandler syn = new SyncDataHandler(temp);
                syn.NotifyFileStateChange = NotifyCurrentCalculateFile;
                MultiTask.TaskDispatcherWithUI(new Action(syn.ImportAccountAndNameLink), this.SynComplete, temp, Application.Current.MainWindow.Dispatcher);
            }
        }
        private object SalaryObj = new object();
        /// <summary>
        /// 薪资导入触发事件
        /// </summary>
        /// <param name="obj"></param>
        private void SalaryEvent(object obj)
        {
            lock (SalaryObj)
            {
                UploadFileInfo info = obj as UploadFileInfo;
                if (info != null)
                {
                    List<UploadFileInfo> temp = new List<UploadFileInfo>();
                    temp.Add(info);
                    SyncDataHandler syn = new SyncDataHandler(temp);
                    syn.NotifyFileStateChange = NotifyCurrentCalculateFile;
                    MultiTask.TaskDispatcherWithUI(new Action(syn.ImportSalaryInfo), this.SynComplete, temp, Application.Current.MainWindow.Dispatcher);
                }
            }
            
        }
        private object PersonInfoObj = new object();
        /// <summary>
        /// 人员导入触发事件
        /// </summary>
        /// <param name="obj"></param>
        private void PersonInfoEvent(object obj)
        {
            lock (PersonInfoObj)
            {
                UploadFileInfo info = obj as UploadFileInfo;
                if (info != null)
                {
                    List<UploadFileInfo> temp = new List<UploadFileInfo>();
                    temp.Add(info);
                    SyncDataHandler syn = new SyncDataHandler(temp);
                    syn.NotifyFileStateChange = NotifyCurrentCalculateFile;
                    MultiTask.TaskDispatcherWithUI(new Action(syn.ImportPGDebitCardInfo), this.SynComplete, temp, Application.Current.MainWindow.Dispatcher);
                }
            }
            
        }
        private object DebitCardObj = new object();
        /// <summary>
        /// 储蓄卡数据导入触发事件
        /// </summary>
        /// <param name="obj"></param>
        private void PGDebitCardInfoData(object obj)
        {
            lock (DebitCardObj)
            {
                UploadFileInfo info = obj as UploadFileInfo;
                if (info != null)
                {
                    List<UploadFileInfo> temp = new List<UploadFileInfo>();
                    temp.Add(info);
                    SyncDataHandler syn = new SyncDataHandler(temp);
                    syn.NotifyFileStateChange = NotifyCurrentCalculateFile;
                    MultiTask.TaskDispatcherWithUI(new Action(syn.ImportPGPersonInfo), this.SynComplete, temp, Application.Current.MainWindow.Dispatcher);
                }

            }
            
        }
        private object InsuranceObj = new object();
        /// <summary>
        /// 保险数据导入触发事件
        /// </summary>
        /// <param name="obj"></param>
        private void PGInsuranceInfoData(object obj)
        {
            lock (InsuranceObj)
            {
                UploadFileInfo info = obj as UploadFileInfo;
                if (info != null)
                {
                    List<UploadFileInfo> temp = new List<UploadFileInfo>();
                    temp.Add(info);
                    SyncDataHandler syn = new SyncDataHandler(temp);
                    syn.NotifyFileStateChange = NotifyCurrentCalculateFile;
                    MultiTask.TaskDispatcherWithUI(new Action(syn.ImportPGInsuranceInfo), this.SynComplete, temp, Application.Current.MainWindow.Dispatcher);
                }
            }
            
        }

        private object CreditCardObj = new object();
        /// <summary>
        /// 保险数据导入触发事件
        /// </summary>
        /// <param name="obj"></param>
        private void PGCreditCardInfoInfoData(object obj)
        {
            lock (CreditCardObj)
            {
                UploadFileInfo info = obj as UploadFileInfo;
                if (info != null)
                {
                    List<UploadFileInfo> temp = new List<UploadFileInfo>();
                    temp.Add(info);
                    SyncDataHandler syn = new SyncDataHandler(temp);
                    syn.NotifyFileStateChange = NotifyCurrentCalculateFile;
                    MultiTask.TaskDispatcherWithUI(new Action(syn.ImportPGCreditCardInfo), this.SynComplete, temp, Application.Current.MainWindow.Dispatcher);
                }
            }

        }
        /// <summary>
        /// 导入个金储蓄类基础数据
        /// </summary>
        /// <param name="obj"></param>
        private void PGCardBaseData(object obj)
        {
            lock (CreditCardObj)
            {
                UploadFileInfo info = obj as UploadFileInfo;
                if (info != null)
                {
                    List<UploadFileInfo> temp = new List<UploadFileInfo>();
                    temp.Add(info);
                    SyncDataHandler syn = new SyncDataHandler(temp);
                    syn.NotifyFileStateChange = NotifyCurrentCalculateFile;
                    MultiTask.TaskDispatcherWithUI(new Action(syn.ImportPGCardBaseData), this.SynComplete, temp, Application.Current.MainWindow.Dispatcher);
                }
            }

        }

        /// <summary>
        /// 导入个金保险类基础数据
        /// </summary>
        /// <param name="obj"></param>
        private void PGInsuranceBaseData(object obj)
        {
            lock (CreditCardObj)
            {
                UploadFileInfo info = obj as UploadFileInfo;
                if (info != null)
                {
                    List<UploadFileInfo> temp = new List<UploadFileInfo>();
                    temp.Add(info);
                    SyncDataHandler syn = new SyncDataHandler(temp);
                    syn.NotifyFileStateChange = NotifyCurrentCalculateFile;
                    MultiTask.TaskDispatcherWithUI(new Action(syn.ImportPGInsuranceBaseData), this.SynComplete, temp, Application.Current.MainWindow.Dispatcher);
                }
            }

        }
        
        

        #endregion
    }
}
