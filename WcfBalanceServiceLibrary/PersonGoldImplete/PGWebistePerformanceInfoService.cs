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
    /// 网点业绩信息服务
    /// </summary>
    public class PGWebistePerformanceInfoService : IPGWebistePerformanceInfoService
    {
        PGWebistePerformanceInfoBLL bll = new PGWebistePerformanceInfoBLL();
        public bool Add(PGWebistePerformanceInfo info)
        {
            return bll.Add(info);
        }

        public bool Delete(PGWebistePerformanceInfo info)
        {
            return bll.Delete(info);
        }

        public List<PGWebistePerformanceInfo> Select(PGWebistePerformanceInfo info)
        {
            try
            {
                if (info.DataTime != null)
                {
                    info.DataTime = DateTime.Parse(info.DataTime.Value.ToString("yyyy-MM-dd"));

                }
                return bll.Select(info);
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(PGWebistePerformanceInfoService), ex);
                return null;
            }
           
        }

        public bool Update(PGWebistePerformanceInfo info)
        {
            return bll.Update(info);
        }
        public int SelectCount(PGWebistePerformanceInfo info)
        {
            if (info.DataTime != null)
            {
                info.DataTime = DateTime.Parse(info.DataTime.Value.ToString("yyyy-MM-dd"));

            }
            return bll.SelectCount(info);
        }

        public List<PGWebistePerformanceInfo> CallTimeSpanProc(PGWebistePerformanceInfo t)
        {
            return bll.CallTimeSpanProc(t);
        }
    }
}
