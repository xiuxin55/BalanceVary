using BalanceReport.LocalModel;
using WSBalanceClient.SystemSetInfoService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BalanceReport.Helper
{
    public  class OrderByColomnHelper
    {
        public static string SubOrderByColomnobj = string.Empty;
        public static string OrderByColomnobj = string.Empty;
        public static string GetOrderByColomn()
        {
            if (!string.IsNullOrEmpty(OrderByColomnobj))
            {
                return OrderByColomnobj;
            }
          
            List<SystemSetInfo> setList = new List<SystemSetInfo>(WSBalanceClient.WSSystemSetInfoService.Instance.Select(null));
            SystemSetInfo ColomnSet = setList != null ? setList.Find(e => e.SetName.ToLower() == ResultOrderBy.GetSetName().ToLower()) : null;
            OrderByColomnobj = ColomnSet != null ? ColomnSet.SetContent : "BalanceTime";
            return OrderByColomnobj;
        }

        public static void  SetOrderByColomn(string param)
        {
            OrderByColomnobj = param;
        }

        /// <summary>
        /// 子排序
        /// </summary>
        /// <returns></returns>
        public static string GetSubOrderByColomn()
        {
            if (!string.IsNullOrEmpty(SubOrderByColomnobj))
            {
                return SubOrderByColomnobj;
            }
            List<SystemSetInfo> setList = new List<SystemSetInfo>(WSBalanceClient.WSSystemSetInfoService.Instance.Select(null));
            SystemSetInfo ColomnSet = setList != null ? setList.Find(e => e.SetName.ToLower() ==("Sub"+ ResultOrderBy.GetSetName()).ToLower()) : null;
            SubOrderByColomnobj = ColomnSet != null ? ColomnSet.SetContent : "BalanceTime";
            return SubOrderByColomnobj;
        }

        public static void SetSubOrderByColomn(string param)
        {
            SubOrderByColomnobj = param;
        }
    }
}
