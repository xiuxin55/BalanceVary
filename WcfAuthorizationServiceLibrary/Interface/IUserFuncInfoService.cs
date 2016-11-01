using AuthorizationModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfAuthorizationServiceLibrary
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IUserFuncInfoService”。
    [ServiceContract]
    public interface IUserFuncInfoService
    {
        [OperationContract]
        bool Add(UserFuncInfo info);
        [OperationContract]
        bool Update(UserFuncInfo info);
        [OperationContract]
        bool Delete(UserFuncInfo info);
        [OperationContract]
        List<UserFuncInfo> Select(UserFuncInfo info);


    }
}
