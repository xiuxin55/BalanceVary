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
    public class AccountBalanceService : IAccountBalanceService
    {
        AccountBalanceBLL bll = new AccountBalanceBLL();
        public bool Add(AccountBalance info)
        {
            return bll.Add(info);
        }

        public bool Delete(AccountBalance info)
        {
            return bll.Delete(info);
        }

        public List<AccountBalance> Select(AccountBalance info)
        {
            return bll.Select(info);
        }

        public int SelectCount(AccountBalance info)
        {
            return bll.SelectCount(info);
        }

        public bool Update(AccountBalance info)
        {
            return bll.Update(info);
        }
    }
}
