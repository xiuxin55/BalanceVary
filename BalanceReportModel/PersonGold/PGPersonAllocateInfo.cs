using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace BalanceModel
{
    /// <summary>
    /// 个金人员分配信息
    /// </summary>
    public class PGPersonAllocateInfo : PersonGoldBaseModel
    {
        /// <summary>
        /// 人员编码
        /// </summary>
        public string  StaffCode { get; set; }
        /// <summary>
        /// 人员姓名
        /// </summary>
        public string StaffName { get; set; }
        /// <summary>
        /// 储蓄卡--日新增
        /// </summary>
        public decimal  CardDayGrowth  { get; set; }
        /// <summary>
        /// 储蓄卡--月新增
        /// </summary>
        public decimal CardMonthGrowth { get; set; }
        /// <summary>
        /// 储蓄卡--年累计
        /// </summary>
        public decimal CardYearGrowth { get; set; }
        /// <summary>
        /// 保险--日新增
        /// </summary>
        public decimal InsuranceDayGrowth { get; set; }
        /// <summary>
        /// 保险--月新增
        /// </summary>
        public decimal InsuranceMonthGrowth { get; set; }
        /// <summary>
        /// 保险--年累计
        /// </summary>
        public decimal InsuranceYearGrowth { get; set; }
        /// <summary>
        /// 信用卡--日新增
        /// </summary>
        public decimal CreditCardDayGrowth { get; set; }
        /// <summary>
        /// 信用卡--月新增
        /// </summary>
        public decimal CreditCardMonthGrowth { get; set; }
        /// <summary>
        /// 信用卡--年累计
        /// </summary>
        public decimal CreditCardYearGrowth { get; set; }
        /// <summary>
        /// 贡献度
        /// </summary>
        public decimal DayContributionDegree { get; set; }
        /// <summary>
        /// 月贡献度
        /// </summary>
        public decimal MonthContributionDegree { get; set; }
        /// <summary>
        /// 年贡献度
        /// </summary>
        public decimal YearContributionDegree { get; set; }
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
