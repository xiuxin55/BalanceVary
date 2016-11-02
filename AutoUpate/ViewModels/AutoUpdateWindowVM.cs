
using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Data;
using System.Windows;
using AutoUpdate.AutoUpdateService;
using Utility;
using System.IO;
using System.Collections;
using System.Xml;
using Common.Client;
using Common;

namespace AutoUpdate
{
    /// <summary>
    ///用户管理
    /// </summary>
    public class AutoUpdateWindowVM : BaseVM
    {
        AutoUpdateServiceClient Client ;
        #region 构造加载
        public AutoUpdateWindowVM()
        {
            try
            {
                Client = new AutoUpdateServiceClient();
                LoadCommand();
                
            }
            catch (Exception ex)
            {

                throw ex;
            }
           
        }
        /// <summary>
        /// 加载命令
        /// </summary>
        public  void LoadCommand()
        {
            DownLoadCommand = new Microsoft.Practices.Prism.Commands.DelegateCommand(DownLoadExecute);
            CancelDownLoadCommand = new Microsoft.Practices.Prism.Commands.DelegateCommand(CancelDownLoadExecute);
            DownFileList = new ObservableCollection<AutoUpdateModel>();
        }

        ObservableCollection<AutoUpdateModel> _DownFileList;
        public ObservableCollection<AutoUpdateModel> DownFileList
        {
            get
            {
                return _DownFileList;
            }
            set
            {
                _DownFileList = value;
                RaisePropertyChanged("DownFileList");
            }

        }
        int _CurrentAmount;
        public int CurrentAmount
        {
            get
            {
                return _CurrentAmount;
            }
            set
            {
                _CurrentAmount = value;
                RaisePropertyChanged("CurrentAmount");
            }

        }

        int _TotalAmount;
        public int TotalAmount
        {
            get
            {
                return _TotalAmount;
            }
            set
            {
                _TotalAmount = value;
                RaisePropertyChanged("TotalAmount");
            }

        }

        public  bool CheckAutoUpdate()
        {

            DownFileList =new ObservableCollection<AutoUpdateService.AutoUpdateModel>(GetUpdateList());
            bool isHasUpdate;
            Client.CheckAutoUpdate(out isHasUpdate, DownFileList.ToArray());
            if (isHasUpdate)
            {
                
                return true;
            }
            else
            {
                return false;
            }
          
        }
        
        #endregion 构造加载

        #region 变量属性

        #endregion 变量属性
        #region 命令定义
        private Microsoft.Practices.Prism.Commands.DelegateCommand DownLoadCommand;
        private Microsoft.Practices.Prism.Commands.DelegateCommand CancelDownLoadCommand;
        #endregion 命令定义

        #region 命令方法
        private  void DownLoadExecute()
        {
            CurrentAmount = 0;
            foreach (var item in DownFileList)
            {
                Client.DownLoadFile(item);
                CurrentAmount++;
            }
           
        }
        private void CancelDownLoadExecute()
        {
            
        }

        public override void LoadPageData(int startindex, int endindex)
        {
            throw new NotImplementedException();
        }
        #endregion 命令方法
        private List<AutoUpdateModel> GetUpdateList()
        {
            string fullfile = CommonDataClient.AutoUpdateDLLPath + "UpdateFileList.xml";
            if (!File.Exists(fullfile))
            {
                return new List<AutoUpdateModel>();
            }
            ArrayList contentarray = ConfigReader.GetAutoUpdateString(fullfile, "UpdateFileList/File");
            List<AutoUpdateModel> list = new List<AutoUpdateModel>();
            foreach (var item in contentarray)
            {
                if (string.IsNullOrWhiteSpace(item.ToString()))
                    continue;
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(item.ToString());
                AutoUpdateModel sm = new AutoUpdateModel();
                sm.FileName = xmlDoc.FirstChild.Attributes["FileName"].Value.ToString();
                sm.Version = xmlDoc.FirstChild.Attributes["Version"].Value.ToString();
                list.Add(sm);
            }
            return list;
        }

    }

   
}