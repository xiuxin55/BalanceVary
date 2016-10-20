using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common.Client
{
    /// <summary>
    /// 文件类型枚举
    /// </summary>
    public enum FileType
    {
        Day,//日报
        Month,//月报
        Department,
        CustomerManager,
        CustomerManagerLinkAccount,//客户经理、部门、帐号关联
        AccountAndNameLink//帐号、账户名称关联
    }
}
