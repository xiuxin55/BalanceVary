﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace BalanceReport.SalaryInfoService {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="BaseModel", Namespace="http://schemas.datacontract.org/2004/07/BalanceModel")]
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(BalanceReport.SalaryInfoService.SalaryInfo))]
    public partial class BaseModel : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int EndIndexField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string OrderbyColomnNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int RowNumberField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int StartIndexField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string SubOrderbyColomnNameField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int EndIndex {
            get {
                return this.EndIndexField;
            }
            set {
                if ((this.EndIndexField.Equals(value) != true)) {
                    this.EndIndexField = value;
                    this.RaisePropertyChanged("EndIndex");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string OrderbyColomnName {
            get {
                return this.OrderbyColomnNameField;
            }
            set {
                if ((object.ReferenceEquals(this.OrderbyColomnNameField, value) != true)) {
                    this.OrderbyColomnNameField = value;
                    this.RaisePropertyChanged("OrderbyColomnName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int RowNumber {
            get {
                return this.RowNumberField;
            }
            set {
                if ((this.RowNumberField.Equals(value) != true)) {
                    this.RowNumberField = value;
                    this.RaisePropertyChanged("RowNumber");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int StartIndex {
            get {
                return this.StartIndexField;
            }
            set {
                if ((this.StartIndexField.Equals(value) != true)) {
                    this.StartIndexField = value;
                    this.RaisePropertyChanged("StartIndex");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string SubOrderbyColomnName {
            get {
                return this.SubOrderbyColomnNameField;
            }
            set {
                if ((object.ReferenceEquals(this.SubOrderbyColomnNameField, value) != true)) {
                    this.SubOrderbyColomnNameField = value;
                    this.RaisePropertyChanged("SubOrderbyColomnName");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="SalaryInfo", Namespace="http://schemas.datacontract.org/2004/07/BalanceModel")]
    [System.SerializableAttribute()]
    public partial class SalaryInfo : BalanceReport.SalaryInfoService.BaseModel {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string AppraisalsField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string BigDiseaseInsuranceMoneyField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string BucklupLastMonthField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ChargebacksAmountField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ExpiredAllowanceField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string HealthInsuranceMoneyField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string HouseAllowanceField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string HouseFundField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string IDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool IsSelectedField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string JobSalaryField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string LossJobMoneyField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PensionMoneyField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ProfessionAllowanceField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string RealAmountField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string RealPerformanceField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string RealSalaryField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string RemarkField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string RetainsSalaryField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string RewardField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string RiskMoneyField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<System.DateTime> SalaryTimeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ShouldPerformanceField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ShouldSalaryField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string StaffCodeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string StaffNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string SynthesizeAllowanceField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TaxField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TaxDeductableField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string UnionMoneyField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string YearCreditAllowanceField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string YearMoneyField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Appraisals {
            get {
                return this.AppraisalsField;
            }
            set {
                if ((object.ReferenceEquals(this.AppraisalsField, value) != true)) {
                    this.AppraisalsField = value;
                    this.RaisePropertyChanged("Appraisals");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string BigDiseaseInsuranceMoney {
            get {
                return this.BigDiseaseInsuranceMoneyField;
            }
            set {
                if ((object.ReferenceEquals(this.BigDiseaseInsuranceMoneyField, value) != true)) {
                    this.BigDiseaseInsuranceMoneyField = value;
                    this.RaisePropertyChanged("BigDiseaseInsuranceMoney");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string BucklupLastMonth {
            get {
                return this.BucklupLastMonthField;
            }
            set {
                if ((object.ReferenceEquals(this.BucklupLastMonthField, value) != true)) {
                    this.BucklupLastMonthField = value;
                    this.RaisePropertyChanged("BucklupLastMonth");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ChargebacksAmount {
            get {
                return this.ChargebacksAmountField;
            }
            set {
                if ((object.ReferenceEquals(this.ChargebacksAmountField, value) != true)) {
                    this.ChargebacksAmountField = value;
                    this.RaisePropertyChanged("ChargebacksAmount");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ExpiredAllowance {
            get {
                return this.ExpiredAllowanceField;
            }
            set {
                if ((object.ReferenceEquals(this.ExpiredAllowanceField, value) != true)) {
                    this.ExpiredAllowanceField = value;
                    this.RaisePropertyChanged("ExpiredAllowance");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string HealthInsuranceMoney {
            get {
                return this.HealthInsuranceMoneyField;
            }
            set {
                if ((object.ReferenceEquals(this.HealthInsuranceMoneyField, value) != true)) {
                    this.HealthInsuranceMoneyField = value;
                    this.RaisePropertyChanged("HealthInsuranceMoney");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string HouseAllowance {
            get {
                return this.HouseAllowanceField;
            }
            set {
                if ((object.ReferenceEquals(this.HouseAllowanceField, value) != true)) {
                    this.HouseAllowanceField = value;
                    this.RaisePropertyChanged("HouseAllowance");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string HouseFund {
            get {
                return this.HouseFundField;
            }
            set {
                if ((object.ReferenceEquals(this.HouseFundField, value) != true)) {
                    this.HouseFundField = value;
                    this.RaisePropertyChanged("HouseFund");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ID {
            get {
                return this.IDField;
            }
            set {
                if ((object.ReferenceEquals(this.IDField, value) != true)) {
                    this.IDField = value;
                    this.RaisePropertyChanged("ID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool IsSelected {
            get {
                return this.IsSelectedField;
            }
            set {
                if ((this.IsSelectedField.Equals(value) != true)) {
                    this.IsSelectedField = value;
                    this.RaisePropertyChanged("IsSelected");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string JobSalary {
            get {
                return this.JobSalaryField;
            }
            set {
                if ((object.ReferenceEquals(this.JobSalaryField, value) != true)) {
                    this.JobSalaryField = value;
                    this.RaisePropertyChanged("JobSalary");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string LossJobMoney {
            get {
                return this.LossJobMoneyField;
            }
            set {
                if ((object.ReferenceEquals(this.LossJobMoneyField, value) != true)) {
                    this.LossJobMoneyField = value;
                    this.RaisePropertyChanged("LossJobMoney");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string PensionMoney {
            get {
                return this.PensionMoneyField;
            }
            set {
                if ((object.ReferenceEquals(this.PensionMoneyField, value) != true)) {
                    this.PensionMoneyField = value;
                    this.RaisePropertyChanged("PensionMoney");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ProfessionAllowance {
            get {
                return this.ProfessionAllowanceField;
            }
            set {
                if ((object.ReferenceEquals(this.ProfessionAllowanceField, value) != true)) {
                    this.ProfessionAllowanceField = value;
                    this.RaisePropertyChanged("ProfessionAllowance");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string RealAmount {
            get {
                return this.RealAmountField;
            }
            set {
                if ((object.ReferenceEquals(this.RealAmountField, value) != true)) {
                    this.RealAmountField = value;
                    this.RaisePropertyChanged("RealAmount");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string RealPerformance {
            get {
                return this.RealPerformanceField;
            }
            set {
                if ((object.ReferenceEquals(this.RealPerformanceField, value) != true)) {
                    this.RealPerformanceField = value;
                    this.RaisePropertyChanged("RealPerformance");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string RealSalary {
            get {
                return this.RealSalaryField;
            }
            set {
                if ((object.ReferenceEquals(this.RealSalaryField, value) != true)) {
                    this.RealSalaryField = value;
                    this.RaisePropertyChanged("RealSalary");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Remark {
            get {
                return this.RemarkField;
            }
            set {
                if ((object.ReferenceEquals(this.RemarkField, value) != true)) {
                    this.RemarkField = value;
                    this.RaisePropertyChanged("Remark");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string RetainsSalary {
            get {
                return this.RetainsSalaryField;
            }
            set {
                if ((object.ReferenceEquals(this.RetainsSalaryField, value) != true)) {
                    this.RetainsSalaryField = value;
                    this.RaisePropertyChanged("RetainsSalary");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Reward {
            get {
                return this.RewardField;
            }
            set {
                if ((object.ReferenceEquals(this.RewardField, value) != true)) {
                    this.RewardField = value;
                    this.RaisePropertyChanged("Reward");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string RiskMoney {
            get {
                return this.RiskMoneyField;
            }
            set {
                if ((object.ReferenceEquals(this.RiskMoneyField, value) != true)) {
                    this.RiskMoneyField = value;
                    this.RaisePropertyChanged("RiskMoney");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<System.DateTime> SalaryTime {
            get {
                return this.SalaryTimeField;
            }
            set {
                if ((this.SalaryTimeField.Equals(value) != true)) {
                    this.SalaryTimeField = value;
                    this.RaisePropertyChanged("SalaryTime");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ShouldPerformance {
            get {
                return this.ShouldPerformanceField;
            }
            set {
                if ((object.ReferenceEquals(this.ShouldPerformanceField, value) != true)) {
                    this.ShouldPerformanceField = value;
                    this.RaisePropertyChanged("ShouldPerformance");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ShouldSalary {
            get {
                return this.ShouldSalaryField;
            }
            set {
                if ((object.ReferenceEquals(this.ShouldSalaryField, value) != true)) {
                    this.ShouldSalaryField = value;
                    this.RaisePropertyChanged("ShouldSalary");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string StaffCode {
            get {
                return this.StaffCodeField;
            }
            set {
                if ((object.ReferenceEquals(this.StaffCodeField, value) != true)) {
                    this.StaffCodeField = value;
                    this.RaisePropertyChanged("StaffCode");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string StaffName {
            get {
                return this.StaffNameField;
            }
            set {
                if ((object.ReferenceEquals(this.StaffNameField, value) != true)) {
                    this.StaffNameField = value;
                    this.RaisePropertyChanged("StaffName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string SynthesizeAllowance {
            get {
                return this.SynthesizeAllowanceField;
            }
            set {
                if ((object.ReferenceEquals(this.SynthesizeAllowanceField, value) != true)) {
                    this.SynthesizeAllowanceField = value;
                    this.RaisePropertyChanged("SynthesizeAllowance");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Tax {
            get {
                return this.TaxField;
            }
            set {
                if ((object.ReferenceEquals(this.TaxField, value) != true)) {
                    this.TaxField = value;
                    this.RaisePropertyChanged("Tax");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string TaxDeductable {
            get {
                return this.TaxDeductableField;
            }
            set {
                if ((object.ReferenceEquals(this.TaxDeductableField, value) != true)) {
                    this.TaxDeductableField = value;
                    this.RaisePropertyChanged("TaxDeductable");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string UnionMoney {
            get {
                return this.UnionMoneyField;
            }
            set {
                if ((object.ReferenceEquals(this.UnionMoneyField, value) != true)) {
                    this.UnionMoneyField = value;
                    this.RaisePropertyChanged("UnionMoney");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string YearCreditAllowance {
            get {
                return this.YearCreditAllowanceField;
            }
            set {
                if ((object.ReferenceEquals(this.YearCreditAllowanceField, value) != true)) {
                    this.YearCreditAllowanceField = value;
                    this.RaisePropertyChanged("YearCreditAllowance");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string YearMoney {
            get {
                return this.YearMoneyField;
            }
            set {
                if ((object.ReferenceEquals(this.YearMoneyField, value) != true)) {
                    this.YearMoneyField = value;
                    this.RaisePropertyChanged("YearMoney");
                }
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="SalaryInfoService.ISalaryInfoService")]
    public interface ISalaryInfoService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISalaryInfoService/Add", ReplyAction="http://tempuri.org/ISalaryInfoService/AddResponse")]
        bool Add(BalanceReport.SalaryInfoService.SalaryInfo info);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISalaryInfoService/Update", ReplyAction="http://tempuri.org/ISalaryInfoService/UpdateResponse")]
        bool Update(BalanceReport.SalaryInfoService.SalaryInfo info);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISalaryInfoService/Delete", ReplyAction="http://tempuri.org/ISalaryInfoService/DeleteResponse")]
        bool Delete(BalanceReport.SalaryInfoService.SalaryInfo info);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISalaryInfoService/Select", ReplyAction="http://tempuri.org/ISalaryInfoService/SelectResponse")]
        BalanceReport.SalaryInfoService.SalaryInfo[] Select(BalanceReport.SalaryInfoService.SalaryInfo info);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISalaryInfoService/SelectCount", ReplyAction="http://tempuri.org/ISalaryInfoService/SelectCountResponse")]
        int SelectCount(BalanceReport.SalaryInfoService.SalaryInfo info);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISalaryInfoService/CallTimeSpanProc", ReplyAction="http://tempuri.org/ISalaryInfoService/CallTimeSpanProcResponse")]
        BalanceReport.SalaryInfoService.SalaryInfo[] CallTimeSpanProc(BalanceReport.SalaryInfoService.SalaryInfo t);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ISalaryInfoServiceChannel : BalanceReport.SalaryInfoService.ISalaryInfoService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class SalaryInfoServiceClient : System.ServiceModel.ClientBase<BalanceReport.SalaryInfoService.ISalaryInfoService>, BalanceReport.SalaryInfoService.ISalaryInfoService {
        
        public SalaryInfoServiceClient() {
        }
        
        public SalaryInfoServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public SalaryInfoServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SalaryInfoServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SalaryInfoServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public bool Add(BalanceReport.SalaryInfoService.SalaryInfo info) {
            return base.Channel.Add(info);
        }
        
        public bool Update(BalanceReport.SalaryInfoService.SalaryInfo info) {
            return base.Channel.Update(info);
        }
        
        public bool Delete(BalanceReport.SalaryInfoService.SalaryInfo info) {
            return base.Channel.Delete(info);
        }
        
        public BalanceReport.SalaryInfoService.SalaryInfo[] Select(BalanceReport.SalaryInfoService.SalaryInfo info) {
            return base.Channel.Select(info);
        }
        
        public int SelectCount(BalanceReport.SalaryInfoService.SalaryInfo info) {
            return base.Channel.SelectCount(info);
        }
        
        public BalanceReport.SalaryInfoService.SalaryInfo[] CallTimeSpanProc(BalanceReport.SalaryInfoService.SalaryInfo t) {
            return base.Channel.CallTimeSpanProc(t);
        }
    }
}
