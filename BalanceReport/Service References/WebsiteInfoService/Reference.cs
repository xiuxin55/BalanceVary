﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace BalanceReport.WebsiteInfoService {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="BaseModel", Namespace="http://schemas.datacontract.org/2004/07/BalanceModel")]
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(BalanceReport.WebsiteInfoService.WebsiteInfo))]
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
    public partial class WebsiteInfo : BalanceReport.WebsiteInfoService.BaseModel {
        
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
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="WebsiteInfoService.IWebsiteInfoService")]
    public interface IWebsiteInfoService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWebsiteInfoService/Add", ReplyAction="http://tempuri.org/IWebsiteInfoService/AddResponse")]
        bool Add(BalanceReport.WebsiteInfoService.WebsiteInfo info);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWebsiteInfoService/Update", ReplyAction="http://tempuri.org/IWebsiteInfoService/UpdateResponse")]
        bool Update(BalanceReport.WebsiteInfoService.WebsiteInfo info);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWebsiteInfoService/Delete", ReplyAction="http://tempuri.org/IWebsiteInfoService/DeleteResponse")]
        bool Delete(BalanceReport.WebsiteInfoService.WebsiteInfo info);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWebsiteInfoService/Select", ReplyAction="http://tempuri.org/IWebsiteInfoService/SelectResponse")]
        BalanceReport.WebsiteInfoService.WebsiteInfo[] Select(BalanceReport.WebsiteInfoService.WebsiteInfo info);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IWebsiteInfoServiceChannel : BalanceReport.WebsiteInfoService.IWebsiteInfoService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class WebsiteInfoServiceClient : System.ServiceModel.ClientBase<BalanceReport.WebsiteInfoService.IWebsiteInfoService>, BalanceReport.WebsiteInfoService.IWebsiteInfoService {
        
        public WebsiteInfoServiceClient() {
        }
        
        public WebsiteInfoServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public WebsiteInfoServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WebsiteInfoServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WebsiteInfoServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public bool Add(BalanceReport.WebsiteInfoService.WebsiteInfo info) {
            return base.Channel.Add(info);
        }
        
        public bool Update(BalanceReport.WebsiteInfoService.WebsiteInfo info) {
            return base.Channel.Update(info);
        }
        
        public bool Delete(BalanceReport.WebsiteInfoService.WebsiteInfo info) {
            return base.Channel.Delete(info);
        }
        
        public BalanceReport.WebsiteInfoService.WebsiteInfo[] Select(BalanceReport.WebsiteInfoService.WebsiteInfo info) {
            return base.Channel.Select(info);
        }
    }
}
