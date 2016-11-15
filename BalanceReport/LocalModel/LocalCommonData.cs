using WSBalanceClient.SystemSetInfoService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WSBalanceClient;

namespace BalanceReport.LocalModel
{
    public class LocalCommonData
    {
        public static DataGridColomnState ColomnStateResult;
        public static DataGridColomnState ColomnState
        {
            get
            {
                if (ColomnStateResult==null)
                {
                    List<SystemSetInfo> setList = new List<SystemSetInfo>(WSSystemSetInfoService.Instance.Select(null));
                    SystemSetInfo ColomnSet = setList != null ? setList.Find(e => e.SetName.ToLower() == DataGridColomnState.GetSetName().ToLower()) : null;
                    ColomnStateResult = ColomnSet != null ? DataGridColomnState.SystemSetInfoToState(ColomnSet) : null;
                }
                return ColomnStateResult;

            }
        }
    }
}
