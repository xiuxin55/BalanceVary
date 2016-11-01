using AuthorizationModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfAuthorizationServiceLibrary
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IFunctionInfoService”。
    [ServiceContract]
    public interface IFunctionInfoService
    {
        [OperationContract]
        bool Add(FunctionInfo info);
        [OperationContract]
        bool Update(FunctionInfo info);
        [OperationContract]
        bool Delete(FunctionInfo info);
        [OperationContract]
        List<FunctionInfo> Select(FunctionInfo info);


    }
}
