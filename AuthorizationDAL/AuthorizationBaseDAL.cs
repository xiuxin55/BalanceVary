using SqlMaps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utility;

namespace AuthorizationDAL
{
    public class AuthorizationBaseDAL<T> : BaseDAL<T> where T : new()
    {
        static AuthorizationBaseDAL()
        {
            SqlMap = BalanceBatis.Batis;
        }

    }
}
