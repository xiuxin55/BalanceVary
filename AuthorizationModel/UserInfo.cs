using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AuthorizationModel
{
    public class UserInfo//: BaseModel
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
        /// 用户登录名
        /// </summary>
        string _UserName;

        public string UserName
        {
            get { return _UserName; }
            set { _UserName = value; }
        }
        /// <summary>
        /// 密码
        /// </summary>
        string _UserPwd;

        public string UserPwd
        {
            get { return _UserPwd; }
            set { _UserPwd = value; }
        }
        string _RealName;

        public string RealName
        {
            get { return _RealName; }
            set { _RealName = value; }
        }
        int _Sex;
        /// <summary>
        /// 性别
        /// </summary>
        public int Sex
        {
            get { return _Sex; }
            set { _Sex = value; }
        }
        string _LinkTel;
        /// <summary>
        /// 联系方式
        /// </summary>
        public string Linktel
        {
            get { return _LinkTel; }
            set { _LinkTel = value; }
        }
        string _Email;
        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }
        int _State;
        /// <summary>
        /// 状态 0正常1删除2锁定
        /// </summary>
        public int State
        {
            get { return _State; }
            set { _State = value; }
        }
        string _Describe;
        /// <summary>
        /// 备注
        /// </summary>
        public string Describe
        {
            get { return _Describe; }
            set { _Describe = value; }
        }
    }
}
