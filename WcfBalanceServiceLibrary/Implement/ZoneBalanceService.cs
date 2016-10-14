using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using BalanceModel;
using BalanceBLL;
using Common;

namespace WcfBalanceServiceLibrary
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的类名“WebsiteInfoService”。
    /// <summary>
    /// 网点管理服务
    /// </summary>
    public class ZoneBalanceService : IZoneBalanceService
    {
        ZoneBalanceBLL bll = new ZoneBalanceBLL();
        public bool Add(ZoneBalance info)
        {
            return bll.Add(info);
        }

        public List<ZoneBalance> CallTimeSpanProc(ZoneBalance t)
        {
            return bll.CallTimeSpanProc(t);
        }

        public bool Delete(ZoneBalance info)
        {
            return bll.Delete(info);
        }

        public List<ZoneBalance> Select(ZoneBalance info)
        {
            try
            {
                return bll.Select(info);
            }
            catch (Exception ex)
            {

                throw ex;
            }
           
        }
        public int SelectCount(ZoneBalance info)
        {
            return bll.SelectCount(info);
        }
        public bool Update(ZoneBalance info)
        {
            return bll.Update(info);
        }
    }
}
