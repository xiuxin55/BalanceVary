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
        AccountAndNameLink,//帐号、账户名称关联
        SalaryInfo,//薪资导入
        PGPersonInfo,//个金中的人员信息导入
        PGDebitCardInfo,//个金--储蓄卡数据导入
        PGInsuranceInfo,//个金--保险数据导入
        PGCreditCardInfo,//个金--信用卡数据导入
        PGCardBaseDataInfo,//个金--储蓄基础数据导入
        PGInsuranceBaseDataInfo//个金--保险基础数据导入
    }
}
