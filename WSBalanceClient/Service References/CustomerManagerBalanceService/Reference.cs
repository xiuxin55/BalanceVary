﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace WSBalanceClient.CustomerManagerBalanceService {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="BaseModel", Namespace="http://schemas.datacontract.org/2004/07/BalanceModel")]
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(WSBalanceClient.CustomerManagerBalanceService.BalanceBaseModel))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(WSBalanceClient.CustomerManagerBalanceService.CustomerManagerBalance))]
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
    [System.Runtime.Serialization.DataContractAttribute(Name="BalanceBaseModel", Namespace="http://schemas.datacontract.org/2004/07/BalanceModel")]
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(WSBalanceClient.CustomerManagerBalanceService.CustomerManagerBalance))]
    public partial class BalanceBaseModel : WSBalanceClient.CustomerManagerBalanceService.BaseModel {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private decimal AmountMoneyField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private decimal AmountMoneyVaryField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<System.DateTime> BalanceTimeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<System.DateTime> EndBalanceTimeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string IDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string RateField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private decimal RegularMoneyField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private decimal RegularMoneyVaryField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<System.DateTime> StartBalanceTimeField;
        
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
        public System.Nullable<System.DateTime> EndBalanceTime {
            get {
                return this.EndBalanceTimeField;
            }
            set {
                if ((this.EndBalanceTimeField.Equals(value) != true)) {
                    this.EndBalanceTimeField = value;
                    this.RaisePropertyChanged("EndBalanceTime");
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
        public System.Nullable<System.DateTime> StartBalanceTime {
            get {
                return this.StartBalanceTimeField;
            }
            set {
                if ((this.StartBalanceTimeField.Equals(value) != true)) {
                    this.StartBalanceTimeField = value;
                    this.RaisePropertyChanged("StartBalanceTime");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="CustomerManagerBalance", Namespace="http://schemas.datacontract.org/2004/07/BalanceModel")]
    [System.SerializableAttribute()]
    public partial class CustomerManagerBalance : WSBalanceClient.CustomerManagerBalanceService.BalanceBaseModel {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DepartmentIDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DepartmentNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ManagerIDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ManagerNameField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string DepartmentID {
            get {
                return this.DepartmentIDField;
            }
            set {
                if ((object.ReferenceEquals(this.DepartmentIDField, value) != true)) {
                    this.DepartmentIDField = value;
                    this.RaisePropertyChanged("DepartmentID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string DepartmentName {
            get {
                return this.DepartmentNameField;
            }
            set {
                if ((object.ReferenceEquals(this.DepartmentNameField, value) != true)) {
                    this.DepartmentNameField = value;
                    this.RaisePropertyChanged("DepartmentName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ManagerID {
            get {
                return this.ManagerIDField;
            }
            set {
                if ((object.ReferenceEquals(this.ManagerIDField, value) != true)) {
                    this.ManagerIDField = value;
                    this.RaisePropertyChanged("ManagerID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ManagerName {
            get {
                return this.ManagerNameField;
            }
            set {
                if ((object.ReferenceEquals(this.ManagerNameField, value) != true)) {
                    this.ManagerNameField = value;
                    this.RaisePropertyChanged("ManagerName");
                }
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="CustomerManagerBalanceService.ICustomerManagerBalanceService")]
    public interface ICustomerManagerBalanceService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICustomerManagerBalanceService/Add", ReplyAction="http://tempuri.org/ICustomerManagerBalanceService/AddResponse")]
        bool Add(WSBalanceClient.CustomerManagerBalanceService.CustomerManagerBalance info);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICustomerManagerBalanceService/Update", ReplyAction="http://tempuri.org/ICustomerManagerBalanceService/UpdateResponse")]
        bool Update(WSBalanceClient.CustomerManagerBalanceService.CustomerManagerBalance info);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICustomerManagerBalanceService/Delete", ReplyAction="http://tempuri.org/ICustomerManagerBalanceService/DeleteResponse")]
        bool Delete(WSBalanceClient.CustomerManagerBalanceService.CustomerManagerBalance info);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICustomerManagerBalanceService/Select", ReplyAction="http://tempuri.org/ICustomerManagerBalanceService/SelectResponse")]
        WSBalanceClient.CustomerManagerBalanceService.CustomerManagerBalance[] Select(WSBalanceClient.CustomerManagerBalanceService.CustomerManagerBalance info);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICustomerManagerBalanceService/SelectCount", ReplyAction="http://tempuri.org/ICustomerManagerBalanceService/SelectCountResponse")]
        int SelectCount(WSBalanceClient.CustomerManagerBalanceService.CustomerManagerBalance info);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICustomerManagerBalanceService/CallTimeSpanProc", ReplyAction="http://tempuri.org/ICustomerManagerBalanceService/CallTimeSpanProcResponse")]
        WSBalanceClient.CustomerManagerBalanceService.CustomerManagerBalance[] CallTimeSpanProc(WSBalanceClient.CustomerManagerBalanceService.CustomerManagerBalance t);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ICustomerManagerBalanceServiceChannel : WSBalanceClient.CustomerManagerBalanceService.ICustomerManagerBalanceService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class CustomerManagerBalanceServiceClient : System.ServiceModel.ClientBase<WSBalanceClient.CustomerManagerBalanceService.ICustomerManagerBalanceService>, WSBalanceClient.CustomerManagerBalanceService.ICustomerManagerBalanceService {
        
        public CustomerManagerBalanceServiceClient() {
        }
        
        public CustomerManagerBalanceServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public CustomerManagerBalanceServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CustomerManagerBalanceServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CustomerManagerBalanceServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public bool Add(WSBalanceClient.CustomerManagerBalanceService.CustomerManagerBalance info) {
            return base.Channel.Add(info);
        }
        
        public bool Update(WSBalanceClient.CustomerManagerBalanceService.CustomerManagerBalance info) {
            return base.Channel.Update(info);
        }
        
        public bool Delete(WSBalanceClient.CustomerManagerBalanceService.CustomerManagerBalance info) {
            return base.Channel.Delete(info);
        }
        
        public WSBalanceClient.CustomerManagerBalanceService.CustomerManagerBalance[] Select(WSBalanceClient.CustomerManagerBalanceService.CustomerManagerBalance info) {
            return base.Channel.Select(info);
        }
        
        public int SelectCount(WSBalanceClient.CustomerManagerBalanceService.CustomerManagerBalance info) {
            return base.Channel.SelectCount(info);
        }
        
        public WSBalanceClient.CustomerManagerBalanceService.CustomerManagerBalance[] CallTimeSpanProc(WSBalanceClient.CustomerManagerBalanceService.CustomerManagerBalance t) {
            return base.Channel.CallTimeSpanProc(t);
        }
    }
}