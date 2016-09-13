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
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的类名“AccountInfoService”。
    public class AccountInfoService : IAccountInfoService
    {
        AccountInfoBLL bll = new AccountInfoBLL();
        public bool Add(AccountInfo info)
        {
            return bll.Add(info);
        }

        public bool Delete(AccountInfo info)
        {
            return bll.Delete(info);
        }

        public List<AccountInfo> Select(AccountInfo info)
        {
            try
            {
                return bll.Select(info);
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(AccountInfoService), ex);
                return new List<AccountInfo>();
            }
           
        }
        public int SelectCount(AccountInfo info)
        {
            try
            {
                return bll.SelectCount(info);
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(AccountInfoService), ex);
                return 0;
            }

        }
        public bool Update(AccountInfo info)
        {
            return bll.Update(info);
        }
    }
}
