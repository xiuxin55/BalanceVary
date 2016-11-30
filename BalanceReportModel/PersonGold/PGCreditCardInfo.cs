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
        /// 本期发生
        /// </summary>
        public decimal? CurrentDayBalance { get; set; }
        /// <summary>
        /// 与昨天的差值
        /// </summary>
        public decimal? DifferenceValue { get; set; }
        /// <summary>
        /// 累计发生
        /// </summary>
        public decimal? WholeBalance { get; set; }
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
