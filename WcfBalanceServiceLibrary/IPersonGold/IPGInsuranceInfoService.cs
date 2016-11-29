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
    public interface IPGInsuranceInfoService
    {
        [OperationContract]
        bool Add(PGInsuranceInfo info);
        [OperationContract]
        bool Update(PGInsuranceInfo info);
        [OperationContract]
        bool Delete(PGInsuranceInfo info);
        [OperationContract]
        List<PGInsuranceInfo> Select(PGInsuranceInfo info);
        [OperationContract]
        int SelectCount(PGInsuranceInfo info);
        [OperationContract]
        List<PGInsuranceInfo> CallTimeSpanProc(PGInsuranceInfo t);
    }
}
