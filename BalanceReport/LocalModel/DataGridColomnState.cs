
using Microsoft.Practices.Prism.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WSBalanceClient.SystemSetInfoService;

namespace BalanceReport.LocalModel
{
    public class DataGridColomnState: NotificationObject
    {
        private bool _RegularColomnState;
        public bool RegularColomnState
        {
            get { return _RegularColomnState; }
            set { _RegularColomnState = value;
                RaisePropertyChanged("RegularColomnState");
            }
        }


        private bool _RegularVaryColomnState;
        public bool RegularVaryColomnState
        {
            get { return _RegularVaryColomnState; }
            set
            {
                _RegularVaryColomnState = value;
                RaisePropertyChanged("RegularVaryColomnState");
            }
        }

        private bool _UnRegularColomnState;
        public bool UnRegularColomnState
        {
            get { return _UnRegularColomnState; }
            set
            {
                _UnRegularColomnState = value;
                RaisePropertyChanged("UnRegularColomnState");
            }
        }

        private bool _UnRegularVaryColomnState;
        public bool UnRegularVaryColomnState
        {
            get { return _UnRegularVaryColomnState; }
            set
            {
                _UnRegularVaryColomnState = value;
                RaisePropertyChanged("UnRegularVaryColomnState");
            }
        }

        private bool _AmountColomnState;
        public bool AmountColomnState
        {
            get { return _AmountColomnState; }
            set
            {
                _AmountColomnState = value;
                RaisePropertyChanged("AmountColomnState");
            }
        }


        private bool _AmountVaryColomnState;
        public bool AmountVaryColomnState
        {
            get { return _AmountVaryColomnState; }
            set
            {
                _AmountVaryColomnState = value;
                RaisePropertyChanged("AmountVaryColomnState");
            }
        }


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
                    state = item.Split(':')[1].ToLower() == "true" ? true : false;
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

        public override string ToString()
        {
            return string.Format("RegularColomnState:{0}|RegularVaryColomnState:{1}|UnRegularColomnState:{2}|UnRegularVaryColomnState:{3}|AmountColomnState:{4}|AmountVaryColomnState:{5}",
                this.RegularColomnState, this.RegularVaryColomnState, this.UnRegularColomnState, this.UnRegularVaryColomnState, this.AmountColomnState, this.AmountVaryColomnState);
        }
        public static string GetSetName()
        {
            return "DataGridColomnState";
        }
    }
    
}
