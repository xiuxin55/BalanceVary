﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace WSBalanceClient.WebsiteBalanceService {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="BaseModel", Namespace="http://schemas.datacontract.org/2004/07/BalanceModel")]
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(WSBalanceClient.WebsiteBalanceService.WebsiteInfo))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(WSBalanceClient.WebsiteBalanceService.BalanceBaseModel))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(WSBalanceClient.WebsiteBalanceService.WebsiteBalance))]
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
    [System.Runtime.Serialization.DataContractAttribute(Name="WebsiteInfo", Namespace="http://schemas.datacontract.org/2004/07/BalanceModel")]
    [System.SerializableAttribute()]
    public partial class WebsiteInfo : WSBalanceClient.WebsiteBalanceService.BaseModel {
        
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
    [System.Runtime.Serialization.DataContractAttribute(Name="BalanceBaseModel", Namespace="http://schemas.datacontract.org/2004/07/BalanceModel")]
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(WSBalanceClient.WebsiteBalanceService.WebsiteBalance))]
    public partial class BalanceBaseModel : WSBalanceClient.WebsiteBalanceService.BaseModel {
        
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
    [System.Runtime.Serialization.DataContractAttribute(Name="WebsiteBalance", Namespace="http://schemas.datacontract.org/2004/07/BalanceModel")]
    [System.SerializableAttribute()]
    public partial class WebsiteBalance : WSBalanceClient.WebsiteBalanceService.BalanceBaseModel {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string WebsiteIDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private WSBalanceClient.WebsiteBalanceService.WebsiteInfo WebsiteInfoObjField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string WebsiteNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ZoneTypeField;
        
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
        public WSBalanceClient.WebsiteBalanceService.WebsiteInfo WebsiteInfoObj {
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
        public string ZoneType {
            get {
                return this.ZoneTypeField;
            }
            set {
                if ((object.ReferenceEquals(this.ZoneTypeField, value) != true)) {
                    this.ZoneTypeField = value;
                    this.RaisePropertyChanged("ZoneType");
                }
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="WebsiteBalanceService.IWebsiteBalanceService")]
    public interface IWebsiteBalanceService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWebsiteBalanceService/Add", ReplyAction="http://tempuri.org/IWebsiteBalanceService/AddResponse")]
        bool Add(WSBalanceClient.WebsiteBalanceService.WebsiteBalance info);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWebsiteBalanceService/Update", ReplyAction="http://tempuri.org/IWebsiteBalanceService/UpdateResponse")]
        bool Update(WSBalanceClient.WebsiteBalanceService.WebsiteBalance info);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWebsiteBalanceService/Delete", ReplyAction="http://tempuri.org/IWebsiteBalanceService/DeleteResponse")]
        bool Delete(WSBalanceClient.WebsiteBalanceService.WebsiteBalance info);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWebsiteBalanceService/Select", ReplyAction="http://tempuri.org/IWebsiteBalanceService/SelectResponse")]
        WSBalanceClient.WebsiteBalanceService.WebsiteBalance[] Select(WSBalanceClient.WebsiteBalanceService.WebsiteBalance info);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWebsiteBalanceService/SelectCount", ReplyAction="http://tempuri.org/IWebsiteBalanceService/SelectCountResponse")]
        int SelectCount(WSBalanceClient.WebsiteBalanceService.WebsiteBalance info);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWebsiteBalanceService/CallTimeSpanProc", ReplyAction="http://tempuri.org/IWebsiteBalanceService/CallTimeSpanProcResponse")]
        WSBalanceClient.WebsiteBalanceService.WebsiteBalance[] CallTimeSpanProc(WSBalanceClient.WebsiteBalanceService.WebsiteBalance t);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IWebsiteBalanceServiceChannel : WSBalanceClient.WebsiteBalanceService.IWebsiteBalanceService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class WebsiteBalanceServiceClient : System.ServiceModel.ClientBase<WSBalanceClient.WebsiteBalanceService.IWebsiteBalanceService>, WSBalanceClient.WebsiteBalanceService.IWebsiteBalanceService {
        
        public WebsiteBalanceServiceClient() {
        }
        
        public WebsiteBalanceServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public WebsiteBalanceServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WebsiteBalanceServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WebsiteBalanceServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public bool Add(WSBalanceClient.WebsiteBalanceService.WebsiteBalance info) {
            return base.Channel.Add(info);
        }
        
        public bool Update(WSBalanceClient.WebsiteBalanceService.WebsiteBalance info) {
            return base.Channel.Update(info);
        }
        
        public bool Delete(WSBalanceClient.WebsiteBalanceService.WebsiteBalance info) {
            return base.Channel.Delete(info);
        }
        
        public WSBalanceClient.WebsiteBalanceService.WebsiteBalance[] Select(WSBalanceClient.WebsiteBalanceService.WebsiteBalance info) {
            return base.Channel.Select(info);
        }
        
        public int SelectCount(WSBalanceClient.WebsiteBalanceService.WebsiteBalance info) {
            return base.Channel.SelectCount(info);
        }
        
        public WSBalanceClient.WebsiteBalanceService.WebsiteBalance[] CallTimeSpanProc(WSBalanceClient.WebsiteBalanceService.WebsiteBalance t) {
            return base.Channel.CallTimeSpanProc(t);
        }
    }
}
