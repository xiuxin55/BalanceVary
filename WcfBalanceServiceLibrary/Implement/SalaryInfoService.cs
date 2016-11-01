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
    /// 薪资服务
    /// </summary>
    public class SalaryInfoService : ISalaryInfoService
    {
        SalaryInfoBLL bll = new SalaryInfoBLL();
        public bool Add(SalaryInfo info)
        {
            return bll.Add(info);
        }

        public bool Delete(SalaryInfo info)
        {
            return bll.Delete(info);
        }

        public List<SalaryInfo> Select(SalaryInfo info)
        {
            try
            {
                if (info==null)
                {
                    info = new BalanceModel.SalaryInfo();
                }
                if (info.SalaryTime != null)
                {
                    info.SalaryTime = DateTime.Parse(info.SalaryTime.Value.ToString("yyyy-MM") + "-01");
                    
                }
                if (string.IsNullOrWhiteSpace(info.OrderbyColomnName))
                {
                    info.OrderbyColomnName = info.SubOrderbyColomnName = "SalaryTime";
                }
                return bll.Select(info);
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(SalaryInfoService), ex);
                throw ex;
            }
           
        }

        public bool Update(SalaryInfo info)
        {
            return bll.Update(info);
        }
        public int SelectCount(SalaryInfo info)
        {
            return bll.SelectCount(info);
        }

        public List<SalaryInfo> CallTimeSpanProc(SalaryInfo t)
        {
            return bll.CallTimeSpanProc(t);
        }
    }
}
