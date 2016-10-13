using BalanceBLL;
using BalanceModel;
using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfBalanceServiceLibrary
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的类名“SystemSetInfoService”。
    /// <summary>
    /// 系统设置服务
    /// </summary>
    public class SystemSetInfoService : ISystemSetInfoService
    {
        SystemSetInfoBLL bll = new SystemSetInfoBLL();
        public bool Add(SystemSetInfo info)
        {
            return bll.Add(info);
        }

        public bool Delete(SystemSetInfo info)
        {
            return bll.Delete(info);
        }

        public List<SystemSetInfo> Select(SystemSetInfo info)
        {
            try
            {
                return bll.Select(info);
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(SystemSetInfoService), ex);
                return new List<SystemSetInfo>();
            }
           
        }
        public int SelectCount(SystemSetInfo info)
        {
            try
            {
                return bll.SelectCount(info);
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(SystemSetInfoService), ex);
                return 0;
            }

        }
        public bool Update(SystemSetInfo info)
        {
            return bll.Update(info);
        }
    }
}
