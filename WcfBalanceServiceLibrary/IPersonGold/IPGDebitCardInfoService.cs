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
    public interface IPGDebitCardInfoService
    {
        [OperationContract]
        bool Add(PGDebitCardInfo info);
        [OperationContract]
        bool Update(PGDebitCardInfo info);
        [OperationContract]
        bool Delete(PGDebitCardInfo info);
        [OperationContract]
        List<PGDebitCardInfo> Select(PGDebitCardInfo info);
        [OperationContract]
        int SelectCount(PGDebitCardInfo info);
        [OperationContract]
        List<PGDebitCardInfo> CallTimeSpanProc(PGDebitCardInfo t);
    }
}
