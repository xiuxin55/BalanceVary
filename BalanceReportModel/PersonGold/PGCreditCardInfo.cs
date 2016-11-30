using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace BalanceModel
{
    /// <summary>
    /// 个金信用卡信息
    /// </summary>
    public class PGCreditCardInfo : PersonGoldBaseModel
    {
        /// <summary>
        /// 员工名
        /// </summary>
        public string StaffName { get; set; }
        /// <summary>
        /// 信用卡数
        /// </summary>
        public decimal? CreditCardCount { get; set; }
       
        /// <summary>
        /// 关联的网点
        /// </summary>
        public WebsiteInfo WebsiteInfoObj { get; set; }
        private bool _IsSelected;
        public bool IsSelected
        {
            get
            {
                return _IsSelected;
            }
            set
            {
                _IsSelected = value;
                this.RaisePropertyChanged("IsSelected");
            }
        }

    }
}
