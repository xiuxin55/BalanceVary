using BalanceModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfBalanceServiceLibrary
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IAccountAndNameLinkInfoService”。
    [ServiceContract]
    public interface IAccountAndNameLinkInfoService
    {
        [OperationContract]
        bool Add(AccountAndNameLinkInfo info);
        [OperationContract]
        bool Update(AccountAndNameLinkInfo info);
        [OperationContract]
        bool Delete(AccountAndNameLinkInfo info);
        [OperationContract]
        List<AccountAndNameLinkInfo> Select(AccountAndNameLinkInfo info);
        [OperationContract]
        int SelectCount(AccountAndNameLinkInfo info);
    }
}
