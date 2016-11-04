
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
using MahApps.Metro.Controls;

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

           
            bool isHasUpdate;
            AutoUpdateModel[] arraray=Client.CheckAutoUpdate(out isHasUpdate, GetUpdateList().ToArray());
            DownFileList = new ObservableCollection<AutoUpdateService.AutoUpdateModel>(arraray);
            TotalAmount = DownFileList.Count;
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
        public MetroWindow WinOwner;
        #endregion 变量属性
        #region 命令定义
        public Microsoft.Practices.Prism.Commands.DelegateCommand DownLoadCommand { get; set; }
        public Microsoft.Practices.Prism.Commands.DelegateCommand CancelDownLoadCommand { get; set; }
        #endregion 命令定义

        #region 命令方法
        private  void DownLoadExecute()
        {
            CurrentAmount = 0;FileStream fs = null;
            try
            {
                foreach (var item in DownFileList)
                {
                    item.State = "正在下载";
                    DownFileResult down = Client.DownLoadFile(item);
                    fs = File.Create(CommonDataClient.AutoUpdatePath + down.Filename);
                    fs.Write(down.SendBytes, 0, down.SendBytes.Length);
                    CurrentAmount++;
                    item.State = "下载完成";
                }
            }
            catch (Exception ex)
            {
                throw ex ;
            }
            finally
            {
                if (fs != null)
                {
                    fs.Close();
                }

            }
           
        }
        private void CancelDownLoadExecute()
        {
            if (WinOwner!=null)
            {
                WinOwner.Close();
            }
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