using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace BalanceModel
{
    /// <summary>
    /// 个金储蓄卡信息
    /// </summary>
    public class PGDebitCardInfo: PersonGoldBaseModel
    {
        /// <summary>
        /// 当前余额
        /// </summary>
        public decimal? CurrentDayBalance { get; set; }
        /// <summary>
        /// 与昨天的差值
        /// </summary>
        public decimal? DifferenceValue { get; set; }
        /// <summary>
        /// 当月余额均值
        /// </summary>
        public decimal? CurrentMonthAverageBalance { get; set; }
        /// <summary>
        /// 当年余额均值
        /// </summary>
        public decimal? CurrentYearAverageBalance { get; set; }
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
