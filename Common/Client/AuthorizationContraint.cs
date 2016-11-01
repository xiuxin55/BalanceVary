using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common.Client
{
    /// <summary>
    /// 权限集合
    /// </summary>
    public class AuthorizationContraint
    {
        /// <summary>
        /// 当前登录用户可以使用的功能
        /// </summary>
        public static List<string> AuthorizationList =null;
        /// <summary>
        /// 当前登录用户
        /// </summary>
        public static object CurrentUser = null;
    }
}
