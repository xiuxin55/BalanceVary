using BalanceModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfBalanceServiceLibrary
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IAccountInfoService”。
    [ServiceContract]
    public interface ICustomerManagerInfoService
    {
        [OperationContract]
        bool Add(CustomerManagerInfo info);
        [OperationContract]
        bool Update(CustomerManagerInfo info);
        [OperationContract]
        bool Delete(CustomerManagerInfo info);
        [OperationContract]
        List<CustomerManagerInfo> Select(CustomerManagerInfo info);
        [OperationContract]
        int SelectCount(CustomerManagerInfo info);
    }
}
