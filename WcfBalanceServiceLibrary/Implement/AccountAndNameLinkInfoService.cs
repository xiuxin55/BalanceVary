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
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的类名“AccountAndNameLinkInfoService”。
    /// <summary>
    /// 账户和账户名关联管理服务
    /// </summary>
    public class AccountAndNameLinkInfoService : IAccountAndNameLinkInfoService
    {
        AccountAndNameLinkInfoBLL bll = new AccountAndNameLinkInfoBLL();
        public bool Add(AccountAndNameLinkInfo info)
        {
            return bll.Add(info);
        }

        public bool Delete(AccountAndNameLinkInfo info)
        {
            return bll.Delete(info);
        }

        public List<AccountAndNameLinkInfo> Select(AccountAndNameLinkInfo info)
        {
            try
            {
                return bll.Select(info);
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(AccountAndNameLinkInfoService), ex);
                return new List<AccountAndNameLinkInfo>();
            }
           
        }
        public int SelectCount(AccountAndNameLinkInfo info)
        {
            try
            {
                return bll.SelectCount(info);
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(AccountAndNameLinkInfoService), ex);
                return 0;
            }

        }
        public bool Update(AccountAndNameLinkInfo info)
        {
            return bll.Update(info);
        }
    }
}
