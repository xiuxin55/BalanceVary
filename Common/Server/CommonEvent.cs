using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common.Server
{
    public class CommonEvent
    {
        /// <summary>
        /// 上传月报数据后触发计算事件
        /// </summary>
        public static Action<object> FileUploadedCalculateEvent;
        /// <summary>
        /// 上传日报数据后触发计算事件
        /// </summary>
        public static Action<object> FileUploadedCalculateDayEvent;
        /// <summary>
        /// 上传客户经理、部门、帐号数据后触发导入事件
        /// </summary>
        public static Action<object> FileUploadedCustomerLinkEvent; 
        /// <summary>
        /// 上传账户号和账户名称数据后触发导入事件
        /// </summary>
        public static Action<object> FileUploadedAccountAndNameLinkEvent;

        /// <summary>
        /// 上传薪资数据后触发导入事件
        /// </summary>
        public static Action<object> FileUploadedSalaryEvent;

        /// <summary>
        /// 上传人员数据后触发导入事件
        /// </summary>
        public static Action<object> PersonInfoDataEvent;
    }
}
