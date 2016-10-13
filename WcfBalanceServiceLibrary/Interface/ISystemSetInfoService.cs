using BalanceModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfBalanceServiceLibrary
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“ISystemSetInfoService”。
    [ServiceContract]
    public interface ISystemSetInfoService
    {
        [OperationContract]
        bool Add(SystemSetInfo info);
        [OperationContract]
        bool Update(SystemSetInfo info);
        [OperationContract]
        bool Delete(SystemSetInfo info);
        [OperationContract]
        List<SystemSetInfo> Select(SystemSetInfo info);
        [OperationContract]
        int SelectCount(SystemSetInfo info);
    }
}
