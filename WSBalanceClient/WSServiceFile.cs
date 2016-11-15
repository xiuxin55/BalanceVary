using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WSBalanceClient.ServiceFile;

namespace WSBalanceClient
{
    public class WSServiceFile
    {
       
        private static WSServiceFile _instance;
        public static WSServiceFile Instance
        {
            get
            {
                if (_instance ==null)
                {
                    _instance = new WSServiceFile();
                }
                return _instance;
            }
        }
        public WSBalanceClient.ServiceFile.CustomFileInfo UpLoadFileInfo(WSBalanceClient.ServiceFile.CustomFileInfo fileInfo)
        {
            return ServiceInvokeHelper<ServiceFileClient>.Invoke<CustomFileInfo>(
              client => client.UpLoadFileInfo(fileInfo)
              );
        }

        public WSBalanceClient.ServiceFile.UploadFileInfo GetFileInfo(WSBalanceClient.ServiceFile.UploadFileInfo uploadfileinfo)
        {
            return ServiceInvokeHelper<ServiceFileClient>.Invoke<UploadFileInfo>(
              client => client.GetFileInfo(uploadfileinfo)
              );
        }

        public bool StoreUpLoadResult(WSBalanceClient.ServiceFile.UploadFileInfo uploadfileinfo)
        {
            return ServiceInvokeHelper<ServiceFileClient>.Invoke<bool>(
             client => client.StoreUpLoadResult(uploadfileinfo)
             );
        }

        public bool ClientTriggerHandleFile(WSBalanceClient.ServiceFile.UploadFileInfo uploadfileinfo)
        {
            return ServiceInvokeHelper<ServiceFileClient>.Invoke<bool>(
            client => client.ClientTriggerHandleFile(uploadfileinfo)
            );
        }

        public byte[] DownLoadTemplateFile(string filename)
        {
            return ServiceInvokeHelper<ServiceFileClient>.Invoke<byte[]>(
            client => client.DownLoadTemplateFile(filename)
            );
        }

        public WSBalanceClient.ServiceFile.UploadFileInfo[] Select(WSBalanceClient.ServiceFile.UploadFileInfo uploadfileinfo)
        {
            return ServiceInvokeHelper<ServiceFileClient>.Invoke<UploadFileInfo[]>(
             client => client.Select(uploadfileinfo)
             );
        }
    }
}
