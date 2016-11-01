using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utility;

namespace AuthorizationModel
{
    public class UserFuncInfo : BaseModel
    {
        string _ID;
        /// <summary>
        /// id
        /// </summary>
        public string ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        /// <summary>
        /// 用户Id
        /// </summary>
        string _UserId;

        public string UserId
        {
            get { return _UserId; }
            set { _UserId = value; }
        }
        /// <summary>
        /// 功能id
        /// </summary>
        string _FunId;

        public string FunId
        {
            get { return _FunId; }
            set { _FunId = value; }
        }
       
    }
    
}
