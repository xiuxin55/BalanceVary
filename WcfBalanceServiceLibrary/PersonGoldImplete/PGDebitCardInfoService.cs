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
    /// 储蓄卡信息服务
    /// </summary>
    public class PGDebitCardInfoService : IPGDebitCardInfoService
    {
        PGDebitCardInfoBLL bll = new PGDebitCardInfoBLL();
        public bool Add(PGDebitCardInfo info)
        {
            return bll.Add(info);
        }

        public bool Delete(PGDebitCardInfo info)
        {
            return bll.Delete(info);
        }

        public List<PGDebitCardInfo> Select(PGDebitCardInfo info)
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
                LogHelper.WriteLog(typeof(SalaryInfoService), ex);
                throw ex;
            }
           
        }

        public bool Update(PGDebitCardInfo info)
        {
            return bll.Update(info);
        }
        public int SelectCount(PGDebitCardInfo info)
        {
            if (info.DataTime != null)
            {
                info.DataTime = DateTime.Parse(info.DataTime.Value.ToString("yyyy-MM-dd"));

            }
            return bll.SelectCount(info);
        }

        public List<PGDebitCardInfo> CallTimeSpanProc(PGDebitCardInfo t)
        {
            return bll.CallTimeSpanProc(t);
        }
    }
}
