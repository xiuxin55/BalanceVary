﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace BalanceReport.AccountBalanceService {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="BaseModel", Namespace="http://schemas.datacontract.org/2004/07/BalanceModel")]
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(BalanceReport.AccountBalanceService.BalanceBaseModel))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(BalanceReport.AccountBalanceService.AccountBalance))]
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
    [System.Runtime.Serialization.DataContractAttribute(Name="BalanceBaseModel", Namespace="http://schemas.datacontract.org/2004/07/BalanceModel")]
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(BalanceReport.AccountBalanceService.AccountBalance))]
    public partial class BalanceBaseModel : BalanceReport.AccountBalanceService.BaseModel {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private decimal AmountMoneyField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private decimal AmountMoneyVaryField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<System.DateTime> BalanceTimeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string IDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string RateField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private decimal RegularMoneyField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private decimal RegularMoneyVaryField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private decimal UnRegularMoneyField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private decimal UnRegularMoneyVaryField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public decimal AmountMoney {
            get {
                return this.AmountMoneyField;
            }
            set {
                if ((this.AmountMoneyField.Equals(value) != true)) {
                    this.AmountMoneyField = value;
                    this.RaisePropertyChanged("AmountMoney");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public decimal AmountMoneyVary {
            get {
                return this.AmountMoneyVaryField;
            }
            set {
                if ((this.AmountMoneyVaryField.Equals(value) != true)) {
                    this.AmountMoneyVaryField = value;
                    this.RaisePropertyChanged("AmountMoneyVary");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<System.DateTime> BalanceTime {
            get {
                return this.BalanceTimeField;
            }
            set {
                if ((this.BalanceTimeField.Equals(value) != true)) {
                    this.BalanceTimeField = value;
                    this.RaisePropertyChanged("BalanceTime");
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
        public string Rate {
            get {
                return this.RateField;
            }
            set {
                if ((object.ReferenceEquals(this.RateField, value) != true)) {
                    this.RateField = value;
                    this.RaisePropertyChanged("Rate");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public decimal RegularMoney {
            get {
                return this.RegularMoneyField;
            }
            set {
                if ((this.RegularMoneyField.Equals(value) != true)) {
                    this.RegularMoneyField = value;
                    this.RaisePropertyChanged("RegularMoney");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public decimal RegularMoneyVary {
            get {
                return this.RegularMoneyVaryField;
            }
            set {
                if ((this.RegularMoneyVaryField.Equals(value) != true)) {
                    this.RegularMoneyVaryField = value;
                    this.RaisePropertyChanged("RegularMoneyVary");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public decimal UnRegularMoney {
            get {
                return this.UnRegularMoneyField;
            }
            set {
                if ((this.UnRegularMoneyField.Equals(value) != true)) {
                    this.UnRegularMoneyField = value;
                    this.RaisePropertyChanged("UnRegularMoney");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public decimal UnRegularMoneyVary {
            get {
                return this.UnRegularMoneyVaryField;
            }
            set {
                if ((this.UnRegularMoneyVaryField.Equals(value) != true)) {
                    this.UnRegularMoneyVaryField = value;
                    this.RaisePropertyChanged("UnRegularMoneyVary");
                }
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="AccountBalance", Namespace="http://schemas.datacontract.org/2004/07/BalanceModel")]
    [System.SerializableAttribute()]
    public partial class AccountBalance : BalanceReport.AccountBalanceService.BalanceBaseModel {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string AccountIDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string AccountNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int AccountTypeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string SubAccountNumberField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string WebsiteIDField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string AccountID {
            get {
                return this.AccountIDField;
            }
            set {
                if ((object.ReferenceEquals(this.AccountIDField, value) != true)) {
                    this.AccountIDField = value;
                    this.RaisePropertyChanged("AccountID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string AccountName {
            get {
                return this.AccountNameField;
            }
            set {
                if ((object.ReferenceEquals(this.AccountNameField, value) != true)) {
                    this.AccountNameField = value;
                    this.RaisePropertyChanged("AccountName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int AccountType {
            get {
                return this.AccountTypeField;
            }
            set {
                if ((this.AccountTypeField.Equals(value) != true)) {
                    this.AccountTypeField = value;
                    this.RaisePropertyChanged("AccountType");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string SubAccountNumber {
            get {
                return this.SubAccountNumberField;
            }
            set {
                if ((object.ReferenceEquals(this.SubAccountNumberField, value) != true)) {
                    this.SubAccountNumberField = value;
                    this.RaisePropertyChanged("SubAccountNumber");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string WebsiteID {
            get {
                return this.WebsiteIDField;
            }
            set {
                if ((object.ReferenceEquals(this.WebsiteIDField, value) != true)) {
                    this.WebsiteIDField = value;
                    this.RaisePropertyChanged("WebsiteID");
                }
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="AccountBalanceService.IAccountBalanceService")]
    public interface IAccountBalanceService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAccountBalanceService/Add", ReplyAction="http://tempuri.org/IAccountBalanceService/AddResponse")]
        bool Add(BalanceReport.AccountBalanceService.AccountBalance info);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAccountBalanceService/Update", ReplyAction="http://tempuri.org/IAccountBalanceService/UpdateResponse")]
        bool Update(BalanceReport.AccountBalanceService.AccountBalance info);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAccountBalanceService/Delete", ReplyAction="http://tempuri.org/IAccountBalanceService/DeleteResponse")]
        bool Delete(BalanceReport.AccountBalanceService.AccountBalance info);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAccountBalanceService/Select", ReplyAction="http://tempuri.org/IAccountBalanceService/SelectResponse")]
        BalanceReport.AccountBalanceService.AccountBalance[] Select(BalanceReport.AccountBalanceService.AccountBalance info);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAccountBalanceService/SelectCount", ReplyAction="http://tempuri.org/IAccountBalanceService/SelectCountResponse")]
        int SelectCount(BalanceReport.AccountBalanceService.AccountBalance info);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IAccountBalanceServiceChannel : BalanceReport.AccountBalanceService.IAccountBalanceService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class AccountBalanceServiceClient : System.ServiceModel.ClientBase<BalanceReport.AccountBalanceService.IAccountBalanceService>, BalanceReport.AccountBalanceService.IAccountBalanceService {
        
        public AccountBalanceServiceClient() {
        }
        
        public AccountBalanceServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public AccountBalanceServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public AccountBalanceServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public AccountBalanceServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public bool Add(BalanceReport.AccountBalanceService.AccountBalance info) {
            return base.Channel.Add(info);
        }
        
        public bool Update(BalanceReport.AccountBalanceService.AccountBalance info) {
            return base.Channel.Update(info);
        }
        
        public bool Delete(BalanceReport.AccountBalanceService.AccountBalance info) {
            return base.Channel.Delete(info);
        }
        
        public BalanceReport.AccountBalanceService.AccountBalance[] Select(BalanceReport.AccountBalanceService.AccountBalance info) {
            return base.Channel.Select(info);
        }
        
        public int SelectCount(BalanceReport.AccountBalanceService.AccountBalance info) {
            return base.Channel.SelectCount(info);
        }
    }
}
