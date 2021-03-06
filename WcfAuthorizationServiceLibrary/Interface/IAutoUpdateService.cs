﻿using AuthorizationModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfAuthorizationServiceLibrary
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IUserInfoService”。
    [ServiceContract]
    public interface IAutoUpdateService
    {
        [OperationContract]
        List<AutoUpdateModel> CheckAutoUpdate(List<AutoUpdateModel> list, out bool IsHasUpdate);
        [OperationContract]
        DownFileResult DownLoadFile(AutoUpdateModel filedata);
         [OperationContract]
        string ReadUpadateXMLString();

    }
}
