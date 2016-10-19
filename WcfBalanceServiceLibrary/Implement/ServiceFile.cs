using BalanceBLL;

using BalanceModel;
using Common;
using Common.Server;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Utility;

namespace WcfBalanceServiceLibrary
{
   // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“ServiceFile”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 ServiceFile.svc 或 ServiceFile.svc.cs，然后开始调试。
    /// <summary>
    /// 文件上传服务
    /// </summary>
    public class ServiceFile : IServiceFile
    {
        UploadFileInfoBLL bll = new UploadFileInfoBLL();
        public CustomFileInfo UpLoadFileInfo(CustomFileInfo fileInfo)
        {
            try
            {
                // 获取服务器文件上传路径
                string fileUpLoadPath = CommonDataServer.UploadFileServerPath;
                string filename = fileUpLoadPath + fileInfo.Name ;
                
                // 如需指定新的文件夹，需要进行创建操作。
                // 创建FileStream对象
                if (!Directory.Exists(fileUpLoadPath))
                {
                    Directory.CreateDirectory(fileUpLoadPath);
                }
                FileStream fs = new FileStream(filename, FileMode.OpenOrCreate);

                long offSet = fileInfo.OffSet;
                // 使用提供的流创建BinaryWriter对象
                var binaryWriter = new BinaryWriter(fs, Encoding.UTF8);
                binaryWriter.Seek((int)offSet, SeekOrigin.Begin);
                binaryWriter.Write(fileInfo.SendByte);
                fileInfo.OffSet = fs.Length;
                fileInfo.SendByte = null;
                binaryWriter.Close();
                fs.Close();
                
                return fileInfo;
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(ServiceFile), ex);
                return null;
            }
        }
      
        public bool  StoreUpLoadResult(UploadFileInfo uploadfileinfo)
        {
            try
            {
                uploadfileinfo.FilePath =  CommonDataServer.UploadFileServerPath;
                uploadfileinfo.FileUploadTime = DateTime.Now;
                bool result = uploadfileinfo.IsOverride ? bll.Update(uploadfileinfo) : bll.Add(uploadfileinfo);
                if (CommonEvent.FileUploadedCalculateEvent != null)
                {
                    CommonEvent.FileUploadedCalculateEvent(uploadfileinfo);
                }
                if (CommonEvent.FileUploadedCalculateDayEvent != null)
                {
                    CommonEvent.FileUploadedCalculateDayEvent(uploadfileinfo);
                }
                if (CommonEvent.FileUploadedCustomerLinkEvent != null)
                {
                    CommonEvent.FileUploadedCustomerLinkEvent(uploadfileinfo);
                }
                
                return true;
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(ServiceFile), ex);
                return false;
            }
        }

        public UploadFileInfo GetFileInfo(UploadFileInfo uploadfileinfo)
        {
            try
            {
                List<UploadFileInfo> list = bll.Select(uploadfileinfo);
                return list.Count > 0 ? list[0] : null;
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(ServiceFile), ex);
                return null;
            }
        }
    }
}
