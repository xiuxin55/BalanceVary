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
    /// 人员信息服务
    /// </summary>
    public class PGPersonInfoService : IPGPersonInfoService
    {
        PGPersonInfoBLL bll = new PGPersonInfoBLL();
        public bool Add(PGPersonInfo info)
        {
            return bll.Add(info);
        }

        public bool Delete(PGPersonInfo info)
        {
            return bll.Delete(info);
        }

        public List<PGPersonInfo> Select(PGPersonInfo info)
        {
            try
            {
                return bll.Select(info);
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(SalaryInfoService), ex);
                throw ex;
            }
           
        }

        public bool Update(PGPersonInfo info)
        {
            return bll.Update(info);
        }
        public int SelectCount(PGPersonInfo info)
        {
            //if (info.SalaryTime != null)
            //{
            //    info.SalaryTime = DateTime.Parse(info.SalaryTime.Value.ToString("yyyy-MM") + "-01");

            //}
            return bll.SelectCount(info);
        }

        public List<PGPersonInfo> CallTimeSpanProc(PGPersonInfo t)
        {
            return bll.CallTimeSpanProc(t);
        }
    }
}
