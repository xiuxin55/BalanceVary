﻿using BalanceBLL;
using BalanceModel;
using Common;
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
    
            SearchCommand = new DelegateCommand(SearchExecute);
            SearchExecute();
        }
        //#region 属性
        // private WebsiteInfoModel _selectedWebsiteInfoModel;
        ///// <summary>
        /////被选中的行 
        ///// </summary>
        //public WebsiteInfoModel SelectedWebsiteInfoModel
        //{
        //    get { return _selectedWebsiteInfoModel; }
        //    set { _selectedWebsiteInfoModel = value;
        //    this.RaisePropertyChanged("SelectedWebsiteInfoModel");
        //    }
        //}


        //private WebsiteInfoModel _searchWebsiteInfoModel;
        ///// <summary>
        ///// 查询
        ///// </summary>
        //public WebsiteInfoModel SearchWebsiteInfoModel
        //{
        //    get { return _searchWebsiteInfoModel; }
        //    set
        //    {
        //        _searchWebsiteInfoModel = value;
        //        this.RaisePropertyChanged("SearchWebsiteInfoModel");
        //    }
        //}
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

        //#endregion
        #region 命令
        public DelegateCommand HandleFileCommand { get; set; }
        public DelegateCommand DeleteFileCommand { get; set; }

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
                SyncDataHandler syn = new SyncDataHandler(UploadFileList.Where(e => e.IsSelected).ToList());
                MultiTask.TaskDispatcherWithUI(new Action(syn.ImportMonthData), this.SynComplete, UploadFileList, Application.Current.MainWindow.Dispatcher);
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(UCUploadFileVM), ex);
            }

        }
        /// <summary>
        /// 删除文件
        /// </summary>
        private void DeleteFileExecute()
        {
            try
            {
                foreach (var item in UploadFileList)
                {
                    if (item.IsSelected)
                    {
                        if (bll.Delete(item))
                        {
                            if(File.Exists(item.FilePath+item.FileName))
                            {
                                File.Delete(item.FilePath + item.FileName);
                            }
                            MessageBox.Show("删除成功");
                        }
                    }
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
        private void CheckBoxClickExecute(bool  obj)
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
            }
        }
        //#endregion
        //#region 内部方法

        //#endregion
        /// <summary>
        /// 同步数据完成
        /// </summary>
        public void SynComplete(object obj)
        {
            ObservableCollection<UploadFileInfo> ufiList = obj as ObservableCollection<UploadFileInfo>;
            bll.BatchUpdate(ufiList.ToList());
        }
    }
}