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
    /// 人员分配信息服务
    /// </summary>
    public class PGPersonAllocateInfoService : IPGPersonAllocateInfoService
    {
        PGPersonAllocateInfoBLL bll = new PGPersonAllocateInfoBLL();
        public bool Add(PGPersonAllocateInfo info)
        {
            return bll.Add(info);
        }

        public bool Delete(PGPersonAllocateInfo info)
        {
            return bll.Delete(info);
        }

        public List<PGPersonAllocateInfo> Select(PGPersonAllocateInfo info)
        {
            try
            {
                return bll.Select(info);
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(PGPersonAllocateInfoService), ex);
                return null;
                //throw ex;
            }
           
        }

        public bool Update(PGPersonAllocateInfo info)
        {
            return bll.Update(info);
        }
        public int SelectCount(PGPersonAllocateInfo info)
        {
            //if (info.SalaryTime != null)
            //{
            //    info.SalaryTime = DateTime.Parse(info.SalaryTime.Value.ToString("yyyy-MM") + "-01");

            //}
            return bll.SelectCount(info);
        }

        public List<PGPersonAllocateInfo> CallTimeSpanProc(PGPersonAllocateInfo t)
        {
            return bll.CallTimeSpanProc(t);
        }
    }
}
