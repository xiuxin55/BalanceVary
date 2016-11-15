using WSBalanceClient.SystemSetInfoService;
using Microsoft.Practices.Prism.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BalanceReport.LocalModel
{
    public class BalanceMode : NotificationObject
    {
        private bool _EveryDayBalance;
        public bool EveryDayBalance
        {
            get { return _EveryDayBalance; }
            set
            {
                _EveryDayBalance = value;
                RaisePropertyChanged("EveryDayBalance");
            }
        }


        private bool _BetweenTwoTimeBalance;
        public bool BetweenTwoTimeBalance
        {
            get { return _BetweenTwoTimeBalance; }
            set
            {
                _BetweenTwoTimeBalance = value;
                RaisePropertyChanged("BetweenTwoTimeBalance");
            }
        }



        public static BalanceMode SystemSetInfoToBalanceMode(SystemSetInfo info)
        {
            BalanceMode obj = new BalanceMode();

            switch (info.SetContent)
            {
                case "EveryDayBalance":
                    obj.EveryDayBalance = true;
                    break;
                case "BetweenTwoTimeBalance":
                    obj.BetweenTwoTimeBalance = true;
                    break;
                default:
                    break;
            }
            
            return obj;

        }

        public override string ToString()
        {
            if (this.EveryDayBalance)
            {
                return "EveryDayBalance";
            }
            if (this.BetweenTwoTimeBalance)
            {
                return "BetweenTwoTimeBalance";
            }
            
            return "BalanceTime";
        }
        public static string GetSetName()
        {
            return "BalanceMode";
        }
    }
}
