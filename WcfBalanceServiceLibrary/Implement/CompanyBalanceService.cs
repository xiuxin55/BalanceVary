using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using BalanceModel;
using BalanceBLL;

namespace WcfBalanceServiceLibrary
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的类名“WebsiteInfoService”。
    /// <summary>
    /// 网点管理服务
    /// </summary>
    public class CompanyBalanceService : ICompanyBalanceService
    {
        CompanyBalanceBLL bll = new CompanyBalanceBLL();
        public bool Add(CompanyBalance info)
        {
            return bll.Add(info);
        }

        public bool Delete(CompanyBalance info)
        {
            return bll.Delete(info);
        }

        public List<CompanyBalance> Select(CompanyBalance info)
        {
            return bll.Select(info);
        }

        public bool Update(CompanyBalance info)
        {
            return bll.Update(info);
        }
        public int SelectCount(CompanyBalance info)
        {
            return bll.SelectCount(info);
        }

        public List<CompanyBalance> CallTimeSpanProc(CompanyBalance t)
        {
            return bll.CallTimeSpanProc(t);
        }
    }
}
