﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace BalanceReport.DepartmentInfoService {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="BaseModel", Namespace="http://schemas.datacontract.org/2004/07/BalanceModel")]
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(BalanceReport.DepartmentInfoService.DepartmentInfo))]
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
    [System.Runtime.Serialization.DataContractAttribute(Name="DepartmentInfo", Namespace="http://schemas.datacontract.org/2004/07/BalanceModel")]
    [System.SerializableAttribute()]
    public partial class DepartmentInfo : BalanceReport.DepartmentInfoService.BaseModel {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DepartmentManagerField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DepartmentNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string IDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ManagerTelphoneField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string DepartmentManager {
            get {
                return this.DepartmentManagerField;
            }
            set {
                if ((object.ReferenceEquals(this.DepartmentManagerField, value) != true)) {
                    this.DepartmentManagerField = value;
                    this.RaisePropertyChanged("DepartmentManager");
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
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="DepartmentInfoService.IDepartmentInfoService")]
    public interface IDepartmentInfoService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDepartmentInfoService/Add", ReplyAction="http://tempuri.org/IDepartmentInfoService/AddResponse")]
        bool Add(BalanceReport.DepartmentInfoService.DepartmentInfo info);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDepartmentInfoService/Update", ReplyAction="http://tempuri.org/IDepartmentInfoService/UpdateResponse")]
        bool Update(BalanceReport.DepartmentInfoService.DepartmentInfo info);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDepartmentInfoService/Delete", ReplyAction="http://tempuri.org/IDepartmentInfoService/DeleteResponse")]
        bool Delete(BalanceReport.DepartmentInfoService.DepartmentInfo info);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDepartmentInfoService/Select", ReplyAction="http://tempuri.org/IDepartmentInfoService/SelectResponse")]
        BalanceReport.DepartmentInfoService.DepartmentInfo[] Select(BalanceReport.DepartmentInfoService.DepartmentInfo info);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IDepartmentInfoServiceChannel : BalanceReport.DepartmentInfoService.IDepartmentInfoService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class DepartmentInfoServiceClient : System.ServiceModel.ClientBase<BalanceReport.DepartmentInfoService.IDepartmentInfoService>, BalanceReport.DepartmentInfoService.IDepartmentInfoService {
        
        public DepartmentInfoServiceClient() {
        }
        
        public DepartmentInfoServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public DepartmentInfoServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public DepartmentInfoServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public DepartmentInfoServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public bool Add(BalanceReport.DepartmentInfoService.DepartmentInfo info) {
            return base.Channel.Add(info);
        }
        
        public bool Update(BalanceReport.DepartmentInfoService.DepartmentInfo info) {
            return base.Channel.Update(info);
        }
        
        public bool Delete(BalanceReport.DepartmentInfoService.DepartmentInfo info) {
            return base.Channel.Delete(info);
        }
        
        public BalanceReport.DepartmentInfoService.DepartmentInfo[] Select(BalanceReport.DepartmentInfoService.DepartmentInfo info) {
            return base.Channel.Select(info);
        }
    }
}
