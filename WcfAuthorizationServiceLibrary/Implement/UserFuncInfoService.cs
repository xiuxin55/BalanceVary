using AuthorizationBLL;
using AuthorizationModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;


namespace WcfAuthorizationServiceLibrary
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的类名“UserFuncInfoService”。
    /// <summary>
    ///用户功能关联服务
    /// </summary>
    public class UserFuncInfoService : IUserFuncInfoService
    {
        UserFuncInfoBLL bll = new UserFuncInfoBLL();
        public bool Add(UserFuncInfo info)
        {
            return bll.Add(info);
        }

        public bool Delete(UserFuncInfo info)
        {
            return bll.Delete(info);
        }

        public List<UserFuncInfo> Select(UserFuncInfo info)
        {
            try
            {
                return bll.Select(info);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

        public bool Update(UserFuncInfo info)
        {
            return bll.Update(info);
        }
    }
}
