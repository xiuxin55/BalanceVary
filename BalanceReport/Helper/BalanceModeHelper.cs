using BalanceReport.LocalModel;
using BalanceReport.SystemSetInfoService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BalanceReport.Helper
{
    public class BalanceModeHelper
    {
        public static BalanceMode BalanceModeobj =null ;
        /// <summary>
        /// 余额模式
        /// </summary>
        /// <returns></returns>
        public static BalanceMode GetBalanceModeobj()
        {
            if (BalanceModeobj!=null)
            {
                return BalanceModeobj;
            }
            SystemSetInfoService.SystemSetInfoServiceClient clientSystemSetInfo = new SystemSetInfoServiceClient();
            List<SystemSetInfo> setList = new List<SystemSetInfo>(clientSystemSetInfo.Select(null));
            SystemSetInfo ColomnSet = setList != null ? setList.Find(e => e.SetName.ToLower() == BalanceMode.GetSetName().ToLower()) : null;
            if (ColomnSet==null)
            {
                BalanceModeobj = new BalanceMode();
                BalanceModeobj.EveryDayBalance = true; 
            }
            else
            {
                BalanceModeobj = BalanceMode.SystemSetInfoToBalanceMode(ColomnSet);
            }
           
            return BalanceModeobj;
        }

        public static void SetBalanceMode(BalanceMode param)
        {
            BalanceModeobj = param;
        }
    }
}
