using BalanceModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfBalanceServiceLibrary
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IServiceFile”。
    [ServiceContract]
    public interface IServiceFile
    {
        /// <summary>
        /// 上传操作
        /// </summary>
        /// <param name="fileInfo"></param>
        /// <returns></returns>
        [OperationContract]
        CustomFileInfo UpLoadFileInfo(CustomFileInfo fileInfo);

        /// <summary>
        /// 获取文件操作
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        [OperationContract]
        UploadFileInfo GetFileInfo(UploadFileInfo uploadfileinfo);
        /// <summary>
        /// 存储上传结果
        /// </summary>
        /// <param name="uploadfileinfo"></param>
        /// <returns></returns>
        [OperationContract]
        bool StoreUpLoadResult(UploadFileInfo uploadfileinfo);
        [OperationContract]
        List<UploadFileInfo> Select(UploadFileInfo uploadfileinfo);
    }

   
   
}
