using BalanceReport.SystemSetInfoService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BalanceReport.LocalModel
{
    public class DataGridColomnState
    {
        public bool RegularColomnState { get; set; }
        public bool RegularVaryColomnState { get; set; }
        public bool UnRegularColomnState { get; set; }
        public bool UnRegularVaryColomnState { get; set; }
        public bool AmountColomnState { get; set; }
        public bool AmountVaryColomnState { get; set; }

        public static DataGridColomnState SystemSetInfoToState(SystemSetInfo info)
        {
            DataGridColomnState obj = new DataGridColomnState();
            string[] results = info.SetContent.Split('|');
            foreach (var item in results)
            {
                string statename = "";
                bool state = true;
                if (item.Split(':').Length==2)
                {
                    statename = item.Split(':')[0];
                    state = item.Split(':')[1] == "true" ? true : false;
                }
                else
                {
                    continue;
                }
                switch (statename)
                {
                    case "RegularColomnState":
                        obj.RegularColomnState = state;
                        break;
                    case "RegularVaryColomnState":
                        obj.RegularVaryColomnState = state;
                        break;
                    case "UnRegularColomnState":
                        obj.UnRegularColomnState = state;
                        break;
                    case "UnRegularVaryColomnState":
                        obj.UnRegularVaryColomnState = state;
                        break;
                    case "AmountColomnState":
                        obj.AmountColomnState = state;
                        break;
                    case "AmountVaryColomnState":
                        obj.AmountVaryColomnState = state;
                        break;
                    default:
                        break;
                }
            }
            return obj;
            
        }
        public static string GetSetName()
        {
            return "DataGridColomnState";
        }
    }
    
}
