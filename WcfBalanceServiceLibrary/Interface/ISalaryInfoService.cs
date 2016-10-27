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
    public interface ISalaryInfoService
    {
        [OperationContract]
        bool Add(SalaryInfo info);
        [OperationContract]
        bool Update(SalaryInfo info);
        [OperationContract]
        bool Delete(SalaryInfo info);
        [OperationContract]
        List<SalaryInfo> Select(SalaryInfo info);
        [OperationContract]
        int SelectCount(SalaryInfo info);
        [OperationContract]
        List<SalaryInfo> CallTimeSpanProc(SalaryInfo t);
    }
}
