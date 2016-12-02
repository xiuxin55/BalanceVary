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
    public interface IPGPersonAllocateInfoService
    {
        [OperationContract]
        bool Add(PGPersonAllocateInfo info);
        [OperationContract]
        bool BatchAdd(List<PGPersonAllocateInfo> list);
        [OperationContract]
        bool Update(PGPersonAllocateInfo info);
        [OperationContract]
        bool Delete(PGPersonAllocateInfo info);
        [OperationContract]
        List<PGPersonAllocateInfo> Select(PGPersonAllocateInfo info);
        [OperationContract]
        int SelectCount(PGPersonAllocateInfo info);
        [OperationContract]
        List<PGPersonAllocateInfo> CallTimeSpanProc(PGPersonAllocateInfo t);
    }
}
