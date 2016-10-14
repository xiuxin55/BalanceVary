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
    public interface IAccountBalanceService
    {
        [OperationContract]
        bool Add(AccountBalance info);
        [OperationContract]
        bool Update(AccountBalance info);
        [OperationContract]
        bool Delete(AccountBalance info);
        [OperationContract]
        List<AccountBalance> Select(AccountBalance info);
        [OperationContract]
        int SelectCount(AccountBalance info);
        [OperationContract]
        List<AccountBalance> SelectByDepartment(DepartmentBalance model);
        [OperationContract]
        int SelectByDepartmentCount(DepartmentBalance model);
        [OperationContract]
        List<AccountBalance> CallTimeSpanProc(AccountBalance t);

    }
}
