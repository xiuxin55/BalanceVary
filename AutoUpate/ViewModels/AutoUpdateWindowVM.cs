
using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Data;
using System.Windows;
using AutoUpdate.AutoUpdateService;
using System.IO;
using System.Collections;
using System.Xml;
using Microsoft.Practices.Prism.ViewModel;
using System.Diagnostics;


namespace AutoUpdate
{
    /// <summary>
    ///用户管理
    /// </summary>
    public class AutoUpdateWindowVM : NotificationObject
    {
        AutoUpdateServiceClient Client ;
        string logfile = System.AppDomain.CurrentDomain.BaseDirectory +DateTime.Now.ToString("yyyyMMdd")+ "autoupdatelog.txt";
        #region 构造加载
        public AutoUpdateWindowVM()
        {
            try
            {

                Client = new AutoUpdateServiceClient();
                LoadCommand();
                KillMainHome();
                CheckAutoUpdate();
            }
            catch (Exception ex)
            {
                
                File.AppendAllText(logfile, DateTime.Now.ToString()+"\n"+ex.Message + ":\n" + ex.StackTrace);
                CancelDownLoadExecute();

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
            if (isHasUpdate)
            {
                DownFileList = new ObservableCollection<AutoUpdateService.AutoUpdateModel>(arraray);
                TotalAmount = DownFileList.Count;

                return true;
            }
            else
            {
                return false;
            }
          
        }

        #endregion 构造加载

        #region 变量属性
        public Window WinOwner;
        string fullfile = System.AppDomain.CurrentDomain.BaseDirectory + "UpdateFileList.xml";
        #endregion 变量属性
        #region 命令定义
        public Microsoft.Practices.Prism.Commands.DelegateCommand DownLoadCommand { get; set; }
        public Microsoft.Practices.Prism.Commands.DelegateCommand CancelDownLoadCommand { get; set; }
        #endregion 命令定义

        #region 命令方法
        private  void DownLoadExecute()
        {
           
            CurrentAmount = 0; 
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                if (!File.Exists(fullfile))
                {
                    xmlDoc=CreateXML();
                }
                else
                {
                    xmlDoc.Load(fullfile);//加载xml文件，文件
                }
                foreach (var item in DownFileList)
                {
                    item.State = "正在下载";
                    DownFileResult down = Client.DownLoadFile(item);
                    if (!string.IsNullOrWhiteSpace(down.Filename))
                    {
                        FileStream fs = null;
           
                        try
                        {
                            fs = File.Create(System.AppDomain.CurrentDomain.BaseDirectory + down.Filename);
                            fs.Write(down.SendBytes, 0, down.SendBytes.Length);
                        }
                        catch (Exception ex)
                        {
                            item.State = "下载出错";
                            throw ex;
                        }
                        finally
                        {

                            if (fs != null)
                            {
                                fs.Close();
                            }
                        }

                        item.State = "下载完成";
                        SetUpdateXML(xmlDoc, item);
                    }
                    else
                    {
                        item.State = down.Message;
                    }
                    CurrentAmount++;
                    
                }
                xmlDoc.Save(fullfile);//再一次强调 ，一定要记得保存的该XML文件
            }
            catch (Exception ex)
            {
                throw ex ;
            }
            
           
        }
        private void CancelDownLoadExecute()
        {
            Process.Start(System.AppDomain.CurrentDomain.BaseDirectory + "MainHome.exe","start");
            Environment.Exit(0);
        }

        #endregion 命令方法
        private List<AutoUpdateModel> GetUpdateList()
        {
          
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
        private XmlDocument CreateXML()
        {
           // File.AppendAllText(fullfile,"");
            XmlDocument doc = new XmlDocument();
            XmlDeclaration dec = doc.CreateXmlDeclaration("1.0", "GB2312", null);
            doc.AppendChild(dec);
            //创建一个根节点（一级）
            XmlElement root = doc.CreateElement("UpdateFileList");
            doc.AppendChild(root);
            return doc;
        }
        private void SetUpdateXML(XmlDocument xmlDoc,AutoUpdateModel model)
        {
            
            XmlNode xns = xmlDoc.SelectSingleNode("UpdateFileList");//查找要修改的节点

            XmlNodeList xnl = xns.ChildNodes;//取出所有的子节点
            bool isHasnode = false;
            foreach (XmlNode xn in xnl)
            {
                XmlElement xe = (XmlElement)xn;//将节点转换一下类型
                if (xe.GetAttribute("FileName") == model.FileName)//判断该子节点是否是要查找的节点
                {
                    xe.SetAttribute("Version", model.Version);//设置新值
                    isHasnode = true;
                } 
            }
            if (!isHasnode)
            {
                XmlElement xe1 = xmlDoc.CreateElement("File");
                xe1.SetAttribute("FileName", model.FileName);
                xe1.SetAttribute("Version", model.Version);
                xns.AppendChild(xe1);
            }
          

        }


        private void KillMainHome()
        {
            Process[] pro = Process.GetProcessesByName("MainHome");
            for (int i = 0; i < pro.Length; i++)
            {
                pro[i].Kill();
            }

        }
    }

   
}