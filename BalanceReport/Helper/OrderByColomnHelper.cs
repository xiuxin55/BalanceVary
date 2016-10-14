using BalanceReport.LocalModel;
using BalanceReport.SystemSetInfoService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BalanceReport.Helper
{
    public class OrderByColomnHelper
    {
        public static string OrderByColomnobj = string.Empty;
        public static string GetOrderByColomn()
        {
            if (!string.IsNullOrEmpty(OrderByColomnobj))
            {
                return OrderByColomnobj;
            }
            SystemSetInfoService.SystemSetInfoServiceClient clientSystemSetInfo = new SystemSetInfoServiceClient();
            List<SystemSetInfo> setList = new List<SystemSetInfo>(clientSystemSetInfo.Select(null));
            SystemSetInfo ColomnSet = setList != null ? setList.Find(e => e.SetName.ToLower() == ResultOrderBy.GetSetName().ToLower()) : null;
            OrderByColomnobj= ColomnSet != null ? ColomnSet.SetContent : "BalanceTime";
            return OrderByColomnobj;
        }

        public static void  SetOrderByColomn(string param)
        {
            OrderByColomnobj = param;
        }
    }
}
