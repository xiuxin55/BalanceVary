using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utility;

namespace AuthorizationModel
{
    public class FunctionInfo : BaseModel
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
        /// 功能编码
        /// </summary>
        string _Code;

        public string Code
        {
            get { return _Code; }
            set { _Code = value; }
        }
        /// <summary>
        /// 名字
        /// </summary>
        string _Name;

        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
        /// <summary>
        /// 文件路径
        /// </summary>
        string _Path;

        public string Path
        {
            get { return _Path; }
            set { _Path = value; }
        }
        string _Parent;

        public string Parent
        {
            get { return _Parent; }
            set { _Parent = value; }
        }
        int _InvokingConfig;

        public int InvokingConfig
        {
            get { return _InvokingConfig; }
            set { _InvokingConfig = value; }
        }
        string _Icon;

        public string Icon
        {
            get { return _Icon; }
            set { _Icon = value; }
        }
        string _AssemblyName;

        public string AssemblyName
        {
            get { return _AssemblyName; }
            set { _AssemblyName = value; }
        }
    }
    
}
