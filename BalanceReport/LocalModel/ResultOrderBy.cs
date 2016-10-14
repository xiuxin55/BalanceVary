using BalanceReport.SystemSetInfoService;
using Microsoft.Practices.Prism.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BalanceReport.LocalModel
{
    public class ResultOrderBy : NotificationObject
    {
        private bool _RegularColomn;
        public bool RegularColomn
        {
            get { return _RegularColomn; }
            set
            {
                _RegularColomn = value;
                RaisePropertyChanged("RegularColomn");
            }
        }


        private bool _RegularVaryColomn;
        public bool RegularVaryColomn
        {
            get { return _RegularVaryColomn; }
            set
            {
                _RegularVaryColomn = value;
                RaisePropertyChanged("RegularVaryColomn");
            }
        }

        private bool _UnRegularColomn;
        public bool UnRegularColomn
        {
            get { return _UnRegularColomn; }
            set
            {
                _UnRegularColomn = value;
                RaisePropertyChanged("UnRegularColomn");
            }
        }

        private bool _UnRegularVaryColomn;
        public bool UnRegularVaryColomn
        {
            get { return _UnRegularVaryColomn; }
            set
            {
                _UnRegularVaryColomn = value;
                RaisePropertyChanged("UnRegularVaryColomn");
            }
        }

        private bool _AmountColomn;
        public bool AmountColomn
        {
            get { return _AmountColomn; }
            set
            {
                _AmountColomn = value;
                RaisePropertyChanged("AmountColomn");
            }
        }


        private bool _AmountVaryColomn;
        public bool AmountVaryColomn
        {
            get { return _AmountVaryColomn; }
            set
            {
                _AmountVaryColomn = value;
                RaisePropertyChanged("AmountVaryColomn");
            }
        }

        private bool _Rate;
        public bool Rate
        {
            get { return _Rate; }
            set
            {
                _Rate = value;
                RaisePropertyChanged("Rate");
            }
        }

        private bool _BalanceTime;
        public bool BalanceTime
        {
            get { return _BalanceTime; }
            set
            {
                _BalanceTime = value;
                RaisePropertyChanged("BalanceTime");
            }
        }


        public static ResultOrderBy SystemSetInfoToOrderBy(SystemSetInfo info)
        {
            ResultOrderBy obj = new ResultOrderBy();

            switch (info.SetContent)
            {
                case "RegularMoney":
                    obj.RegularColomn = true;
                    break;
                case "UnRegularMoney":
                    obj.UnRegularColomn = true;
                    break;
                case "AmountMoney":
                    obj.AmountColomn = true;
                    break;
                case "RegularMoneyVary":
                    obj.RegularVaryColomn = true;
                    break;
                case "UnRegularMoneyVary":
                    obj.UnRegularVaryColomn = true;
                    break;
                case "AmountMoneyVary":
                    obj.AmountVaryColomn = true;
                    break;
                case "Rate":
                    obj.Rate = true;
                    break;
                case "BalanceTime":
                    obj.BalanceTime = true;
                    break;
                default:
                    break;
            }
            
            return obj;

        }

        public override string ToString()
        {
            if (this.RegularColomn)
            {
                return "RegularMoney";
            }
            if (this.UnRegularColomn)
            {
                return "UnRegularMoney";
            }
            if (this.AmountColomn)
            {
                return "AmountMoney";
            }
            if (this.RegularVaryColomn)
            {
                return "RegularMoneyVary";
            }
            if (this.UnRegularVaryColomn)
            {
                return "UnRegularMoneyVary";
            }
            if (this.AmountVaryColomn)
            {
                return "AmountMoneyVary";
            }
            if (this.Rate)
            {
                return "Rate";
            }
            if (this.BalanceTime)
            {
                return "BalanceTime";
            }
            return "BalanceTime";
        }
        public static string GetSetName()
        {
            return "ResultOrderBy";
        }
    }
}
