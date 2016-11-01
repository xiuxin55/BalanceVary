using Common.Client;
using Encryption4Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UserAuthorization.UserInfoService;

namespace UserAuthorization.Helper
{
    public class UserLoginHelper
    {
        UserInfoServiceClient UserManageClient=new UserInfoServiceClient();
        Encryption ep = new Encryption();
        private static UserLoginHelper _instance;
        public static UserLoginHelper Instance
        {
            get
            {
                if (_instance ==null)
                {
                    _instance = new UserLoginHelper();
                }
                return _instance;
            }
        }

        public bool CheckLogin(string username, string password)
        {
            UserInfo temp = new UserInfoService.UserInfo();
            temp.UserName = username;
            temp.UserPwd = ep.EnCode(password);
            UserInfo[] UserInfoArray = UserManageClient.Select(temp);
            if (UserInfoArray != null && UserInfoArray.Length == 1)
            {
                AuthorizationContraint.CurrentUser = UserInfoArray[0];
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
