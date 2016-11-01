
using AuthorizationModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utility;

namespace AuthorizationDAL
{
    public class UserFuncInfoDAL: AuthorizationBaseDAL<UserFuncInfo>
    {
        public UserFuncInfoDAL()
        {
            DefaultKey = "UserFuncInfo";
        }
      
    }
}
