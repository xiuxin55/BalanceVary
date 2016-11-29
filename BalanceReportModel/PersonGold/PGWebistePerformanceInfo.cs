using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace BalanceModel
{
    /// <summary>
    /// 网点业绩信息
    /// </summary>
    public class PGWebistePerformanceInfo : PersonGoldBaseModel
    {
        /// <summary>
        /// 储蓄卡
        /// </summary>
        public PGDebitCardInfo PGDebitCardInfoObj { get; set; }
        /// <summary>
        /// 保险
        /// </summary>
        public PGInsuranceInfo PGInsuranceInfoObj { get; set; }
        ///// <summary>
        ///// 信用卡
        ///// </summary>
        //public decimal? WholeBalance { get; set; }
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
