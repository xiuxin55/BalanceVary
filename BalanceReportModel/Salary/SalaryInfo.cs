using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace BalanceModel
{
    /// <summary>
    /// 薪资信息
    /// </summary>
    public class SalaryInfo : BaseModel
    {
        public string  ID { get; set; }
        /// <summary>
        /// 人员编码
        /// </summary>
        public string  StaffCode { get; set; }
        /// <summary>
        /// 人员姓名
        /// </summary>
        public string StaffName { get; set; }
        /// <summary>
        /// 岗位工资
        /// </summary>
        public string  JobSalary { get; set; }
        /// <summary>
        /// 专业技术职务津贴
        /// </summary>
        public string ProfessionAllowance { get; set; }
        /// <summary>
        /// 保留年功津贴
        /// </summary>
        public string YearCreditAllowance { get; set; }
        /// <summary>
        /// 保留工资
        /// </summary>
        public string  RetainsSalary { get; set; }
        /// <summary>
        /// 综合补贴
        /// </summary>
        public string SynthesizeAllowance { get; set; }
        /// <summary>
        /// 过渡期补贴
        /// </summary>
        public string ExpiredAllowance { get; set; }
        /// <summary>
        /// 住房补贴
        /// </summary>
        public string HouseAllowance { get; set; }
        /// <summary>
        /// 应发工资
        /// </summary>
        public string ShouldSalary { get; set; }
        /// <summary>
        /// 住房公积金实缴额(个人合计)
        /// </summary>
        public string HouseFund { get; set; }
        /// <summary>
        /// 养老保险实缴额(个人)
        /// </summary>
        public string PensionMoney { get; set; }
        /// <summary>
        /// 工会费
        /// </summary>
        public string UnionMoney { get; set; }
        /// <summary>
        /// 医疗保险实缴额(个人)
        /// </summary>
        public string HealthInsuranceMoney { get; set; }
        /// <summary>
        /// 失业保险实缴额(个人)
        /// </summary>
        public string LossJobMoney { get; set; }
        /// <summary>
        /// 大病医疗保险实缴额(个人)
        /// </summary>
        public string BigDiseaseInsuranceMoney { get; set; }
        /// <summary>
        /// 年金
        /// </summary>
        public string YearMoney { get; set; }
        /// <summary>
        /// 扣款自定义项1(抵税)
        /// </summary>
        public string TaxDeductable { get; set; }
        /// <summary>
        /// 扣款合计
        /// </summary>
        public string ChargebacksAmount { get; set; }
        /// <summary>
        /// 实发工资
        /// </summary>
        public string RealSalary { get; set; }
        /// <summary>
        /// 应发绩效
        /// </summary>
        public string ShouldPerformance { get; set; }
        /// <summary>
        /// 奖励
        /// </summary>
        public string Reward { get; set; }
        /// <summary>
        /// 考核
        /// </summary>
        public string Appraisals { get; set; }
        /// <summary>
        /// 补扣上月
        /// </summary>
        public string BucklupLastMonth { get; set; }
        /// <summary>
        /// 税收
        /// </summary>
        public string Tax { get; set; }
        /// <summary>
        /// 风险金
        /// </summary>
        public string RiskMoney { get; set; }
        /// <summary>
        /// 实发绩效
        /// </summary>
        public string RealPerformance { get; set; }
        /// <summary>
        /// 实发合计
        /// </summary>
        public string RealAmount { get; set; }
        /// <summary>
        /// 备注说明
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 薪资时间
        /// </summary>
        public DateTime? SalaryTime { get; set; }

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
