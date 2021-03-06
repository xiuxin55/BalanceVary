﻿using AuthorizationBLL;
using AuthorizationModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;


namespace WcfAuthorizationServiceLibrary
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的类名“UserInfoService”。
    /// <summary>
    /// 用户管理服务
    /// </summary>
    public class UserInfoService : IUserInfoService
    {
        UserInfoBLL bll = new UserInfoBLL();
        public bool Add(UserInfo info)
        {
            return bll.Add(info);
        }

        public bool Delete(UserInfo info)
        {
            return bll.Delete(info);
        }

        public List<UserInfo> Select(UserInfo info)
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

        public bool Update(UserInfo info)
        {
            return bll.Update(info);
        }
    }
}
