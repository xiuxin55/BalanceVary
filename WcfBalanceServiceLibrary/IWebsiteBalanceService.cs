using BalanceModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfBalanceServiceLibrary
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IWebsiteInfoService”。
    [ServiceContract]
    public interface IWebsiteBalanceService
    {
        [OperationContract]
        bool Add(WebsiteBalance info);
        [OperationContract]
        bool Update(WebsiteBalance info);
        [OperationContract]
        bool Delete(WebsiteBalance info);
        [OperationContract]
        List<WebsiteBalance> Select(WebsiteBalance info);
        [OperationContract]
        int SelectCount(WebsiteBalance info);

    }
}
