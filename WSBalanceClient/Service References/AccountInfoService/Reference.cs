﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace WSBalanceClient.AccountInfoService {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="BaseModel", Namespace="http://schemas.datacontract.org/2004/07/BalanceModel")]
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(WSBalanceClient.AccountInfoService.CustomerManagerInfo))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(WSBalanceClient.AccountInfoService.WebsiteInfo))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(WSBalanceClient.AccountInfoService.AccountInfo))]
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
    [System.Runtime.Serialization.DataContractAttribute(Name="CustomerManagerInfo", Namespace="http://schemas.datacontract.org/2004/07/BalanceModel")]
    [System.SerializableAttribute()]
    public partial class CustomerManagerInfo : WSBalanceClient.AccountInfoService.BaseModel {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DepartmentIDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DepartmentNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string IDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string InstitutionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ManagerEmailField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ManagerIDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ManagerNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ManagerTelphoneField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string WebsiteIDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string WebsiteNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string WebsiteTelField;
        
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
        public string Institution {
            get {
                return this.InstitutionField;
            }
            set {
                if ((object.ReferenceEquals(this.InstitutionField, value) != true)) {
                    this.InstitutionField = value;
                    this.RaisePropertyChanged("Institution");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ManagerEmail {
            get {
                return this.ManagerEmailField;
            }
            set {
                if ((object.ReferenceEquals(this.ManagerEmailField, value) != true)) {
                    this.ManagerEmailField = value;
                    this.RaisePropertyChanged("ManagerEmail");
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
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ManagerTelphone {
            get {
                return this.ManagerTelphoneField;
            }
            set {
                if ((object.ReferenceEquals(this.ManagerTelphoneField, value) != true)) {
                    this.ManagerTelphoneField = value;
                    this.RaisePropertyChanged("ManagerTelphone");
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
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string WebsiteName {
            get {
                return this.WebsiteNameField;
            }
            set {
                if ((object.ReferenceEquals(this.WebsiteNameField, value) != true)) {
                    this.WebsiteNameField = value;
                    this.RaisePropertyChanged("WebsiteName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string WebsiteTel {
            get {
                return this.WebsiteTelField;
            }
            set {
                if ((object.ReferenceEquals(this.WebsiteTelField, value) != true)) {
                    this.WebsiteTelField = value;
                    this.RaisePropertyChanged("WebsiteTel");
                }
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="WebsiteInfo", Namespace="http://schemas.datacontract.org/2004/07/BalanceModel")]
    [System.SerializableAttribute()]
    public partial class WebsiteInfo : WSBalanceClient.AccountInfoService.BaseModel {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string IDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string InstitutionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ManagerTelphoneField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string WebsiteAddressField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string WebsiteIDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string WebsiteManagerField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string WebsiteNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string WebsiteTelField;
        
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
        public string Institution {
            get {
                return this.InstitutionField;
            }
            set {
                if ((object.ReferenceEquals(this.InstitutionField, value) != true)) {
                    this.InstitutionField = value;
                    this.RaisePropertyChanged("Institution");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ManagerTelphone {
            get {
                return this.ManagerTelphoneField;
            }
            set {
                if ((object.ReferenceEquals(this.ManagerTelphoneField, value) != true)) {
                    this.ManagerTelphoneField = value;
                    this.RaisePropertyChanged("ManagerTelphone");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string WebsiteAddress {
            get {
                return this.WebsiteAddressField;
            }
            set {
                if ((object.ReferenceEquals(this.WebsiteAddressField, value) != true)) {
                    this.WebsiteAddressField = value;
                    this.RaisePropertyChanged("WebsiteAddress");
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
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string WebsiteManager {
            get {
                return this.WebsiteManagerField;
            }
            set {
                if ((object.ReferenceEquals(this.WebsiteManagerField, value) != true)) {
                    this.WebsiteManagerField = value;
                    this.RaisePropertyChanged("WebsiteManager");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string WebsiteName {
            get {
                return this.WebsiteNameField;
            }
            set {
                if ((object.ReferenceEquals(this.WebsiteNameField, value) != true)) {
                    this.WebsiteNameField = value;
                    this.RaisePropertyChanged("WebsiteName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string WebsiteTel {
            get {
                return this.WebsiteTelField;
            }
            set {
                if ((object.ReferenceEquals(this.WebsiteTelField, value) != true)) {
                    this.WebsiteTelField = value;
                    this.RaisePropertyChanged("WebsiteTel");
                }
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="AccountInfo", Namespace="http://schemas.datacontract.org/2004/07/BalanceModel")]
    [System.SerializableAttribute()]
    public partial class AccountInfo : WSBalanceClient.AccountInfoService.BaseModel {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string AccountIDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string AccountNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string AccountTypeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CorrelationStateField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string IDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ManagerIDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private WSBalanceClient.AccountInfoService.CustomerManagerInfo ManagersInfoObjField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string SubAccountNumberField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string WebsiteIDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private WSBalanceClient.AccountInfoService.WebsiteInfo WebsiteInfoObjField;
        
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
        public string AccountType {
            get {
                return this.AccountTypeField;
            }
            set {
                if ((object.ReferenceEquals(this.AccountTypeField, value) != true)) {
                    this.AccountTypeField = value;
                    this.RaisePropertyChanged("AccountType");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string CorrelationState {
            get {
                return this.CorrelationStateField;
            }
            set {
                if ((object.ReferenceEquals(this.CorrelationStateField, value) != true)) {
                    this.CorrelationStateField = value;
                    this.RaisePropertyChanged("CorrelationState");
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
        public WSBalanceClient.AccountInfoService.CustomerManagerInfo ManagersInfoObj {
            get {
                return this.ManagersInfoObjField;
            }
            set {
                if ((object.ReferenceEquals(this.ManagersInfoObjField, value) != true)) {
                    this.ManagersInfoObjField = value;
                    this.RaisePropertyChanged("ManagersInfoObj");
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
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public WSBalanceClient.AccountInfoService.WebsiteInfo WebsiteInfoObj {
            get {
                return this.WebsiteInfoObjField;
            }
            set {
                if ((object.ReferenceEquals(this.WebsiteInfoObjField, value) != true)) {
                    this.WebsiteInfoObjField = value;
                    this.RaisePropertyChanged("WebsiteInfoObj");
                }
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="AccountInfoService.IAccountInfoService")]
    public interface IAccountInfoService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAccountInfoService/Add", ReplyAction="http://tempuri.org/IAccountInfoService/AddResponse")]
        bool Add(WSBalanceClient.AccountInfoService.AccountInfo info);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAccountInfoService/Update", ReplyAction="http://tempuri.org/IAccountInfoService/UpdateResponse")]
        bool Update(WSBalanceClient.AccountInfoService.AccountInfo info);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAccountInfoService/Delete", ReplyAction="http://tempuri.org/IAccountInfoService/DeleteResponse")]
        bool Delete(WSBalanceClient.AccountInfoService.AccountInfo info);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAccountInfoService/Select", ReplyAction="http://tempuri.org/IAccountInfoService/SelectResponse")]
        WSBalanceClient.AccountInfoService.AccountInfo[] Select(WSBalanceClient.AccountInfoService.AccountInfo info);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAccountInfoService/SelectCount", ReplyAction="http://tempuri.org/IAccountInfoService/SelectCountResponse")]
        int SelectCount(WSBalanceClient.AccountInfoService.AccountInfo info);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IAccountInfoServiceChannel : WSBalanceClient.AccountInfoService.IAccountInfoService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class AccountInfoServiceClient : System.ServiceModel.ClientBase<WSBalanceClient.AccountInfoService.IAccountInfoService>, WSBalanceClient.AccountInfoService.IAccountInfoService {
        
        public AccountInfoServiceClient() {
        }
        
        public AccountInfoServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public AccountInfoServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public AccountInfoServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public AccountInfoServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public bool Add(WSBalanceClient.AccountInfoService.AccountInfo info) {
            return base.Channel.Add(info);
        }
        
        public bool Update(WSBalanceClient.AccountInfoService.AccountInfo info) {
            return base.Channel.Update(info);
        }
        
        public bool Delete(WSBalanceClient.AccountInfoService.AccountInfo info) {
            return base.Channel.Delete(info);
        }
        
        public WSBalanceClient.AccountInfoService.AccountInfo[] Select(WSBalanceClient.AccountInfoService.AccountInfo info) {
            return base.Channel.Select(info);
        }
        
        public int SelectCount(WSBalanceClient.AccountInfoService.AccountInfo info) {
            return base.Channel.SelectCount(info);
        }
    }
}
