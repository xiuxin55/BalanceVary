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
    public interface ICustomerManagerBalanceService
    {
        [OperationContract]
        bool Add(CustomerManagerBalance info);
        [OperationContract]
        bool Update(CustomerManagerBalance info);
        [OperationContract]
        bool Delete(CustomerManagerBalance info);
        [OperationContract]
        List<CustomerManagerBalance> Select(CustomerManagerBalance info);
        [OperationContract]
        int SelectCount(CustomerManagerBalance info);
        [OperationContract]
        List<CustomerManagerBalance> CallTimeSpanProc(CustomerManagerBalance t);
    }
}
