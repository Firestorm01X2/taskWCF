﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ConsoleClient1DAskieva.ServiceReference1 {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="InputForTempBase", Namespace="http://schemas.datacontract.org/2004/07/WcfMathLibrary")]
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(ConsoleClient1DAskieva.ServiceReference1.InputForTemp3D))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(ConsoleClient1DAskieva.ServiceReference1.InputForTemp1D))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(ConsoleClient1DAskieva.ServiceReference1.InputForTemp))]
    public partial class InputForTempBase : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double CField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double HField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string InputMessageField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double TauField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int TimeStepsField;
        
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
        public double C {
            get {
                return this.CField;
            }
            set {
                if ((this.CField.Equals(value) != true)) {
                    this.CField = value;
                    this.RaisePropertyChanged("C");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double H {
            get {
                return this.HField;
            }
            set {
                if ((this.HField.Equals(value) != true)) {
                    this.HField = value;
                    this.RaisePropertyChanged("H");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string InputMessage {
            get {
                return this.InputMessageField;
            }
            set {
                if ((object.ReferenceEquals(this.InputMessageField, value) != true)) {
                    this.InputMessageField = value;
                    this.RaisePropertyChanged("InputMessage");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double Tau {
            get {
                return this.TauField;
            }
            set {
                if ((this.TauField.Equals(value) != true)) {
                    this.TauField = value;
                    this.RaisePropertyChanged("Tau");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int TimeSteps {
            get {
                return this.TimeStepsField;
            }
            set {
                if ((this.TimeStepsField.Equals(value) != true)) {
                    this.TimeStepsField = value;
                    this.RaisePropertyChanged("TimeSteps");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="InputForTemp3D", Namespace="http://schemas.datacontract.org/2004/07/WcfMathLibrary")]
    [System.SerializableAttribute()]
    public partial class InputForTemp3D : ConsoleClient1DAskieva.ServiceReference1.InputForTempBase {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private ConsoleClient1DAskieva.ServiceReference1.Array3DOfdouble UField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public ConsoleClient1DAskieva.ServiceReference1.Array3DOfdouble U {
            get {
                return this.UField;
            }
            set {
                if ((object.ReferenceEquals(this.UField, value) != true)) {
                    this.UField = value;
                    this.RaisePropertyChanged("U");
                }
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="InputForTemp1D", Namespace="http://schemas.datacontract.org/2004/07/WcfMathLibrary")]
    [System.SerializableAttribute()]
    public partial class InputForTemp1D : ConsoleClient1DAskieva.ServiceReference1.InputForTempBase {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double[] UField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double[] U {
            get {
                return this.UField;
            }
            set {
                if ((object.ReferenceEquals(this.UField, value) != true)) {
                    this.UField = value;
                    this.RaisePropertyChanged("U");
                }
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="InputForTemp", Namespace="http://schemas.datacontract.org/2004/07/WcfMathLibrary")]
    [System.SerializableAttribute()]
    public partial class InputForTemp : ConsoleClient1DAskieva.ServiceReference1.InputForTempBase {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double[][] UField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double[][] U {
            get {
                return this.UField;
            }
            set {
                if ((object.ReferenceEquals(this.UField, value) != true)) {
                    this.UField = value;
                    this.RaisePropertyChanged("U");
                }
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Array3DOfdouble", Namespace="http://schemas.datacontract.org/2004/07/Array3DLibrary")]
    [System.SerializableAttribute()]
    public partial class Array3DOfdouble : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private double[] ItemsField;
        
        private int MaxItemNumberField;
        
        private int xLengthField;
        
        private int yLengthField;
        
        private int zLengthField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public double[] Items {
            get {
                return this.ItemsField;
            }
            set {
                if ((object.ReferenceEquals(this.ItemsField, value) != true)) {
                    this.ItemsField = value;
                    this.RaisePropertyChanged("Items");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public int MaxItemNumber {
            get {
                return this.MaxItemNumberField;
            }
            set {
                if ((this.MaxItemNumberField.Equals(value) != true)) {
                    this.MaxItemNumberField = value;
                    this.RaisePropertyChanged("MaxItemNumber");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public int xLength {
            get {
                return this.xLengthField;
            }
            set {
                if ((this.xLengthField.Equals(value) != true)) {
                    this.xLengthField = value;
                    this.RaisePropertyChanged("xLength");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public int yLength {
            get {
                return this.yLengthField;
            }
            set {
                if ((this.yLengthField.Equals(value) != true)) {
                    this.yLengthField = value;
                    this.RaisePropertyChanged("yLength");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public int zLength {
            get {
                return this.zLengthField;
            }
            set {
                if ((this.zLengthField.Equals(value) != true)) {
                    this.zLengthField = value;
                    this.RaisePropertyChanged("zLength");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="OutputForTempBase", Namespace="http://schemas.datacontract.org/2004/07/WcfMathLibrary")]
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(ConsoleClient1DAskieva.ServiceReference1.OutputForTemp3D))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(ConsoleClient1DAskieva.ServiceReference1.OutputForTemp1D))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(ConsoleClient1DAskieva.ServiceReference1.OutputForTemp))]
    public partial class OutputForTempBase : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string OutputMessageField;
        
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
        public string OutputMessage {
            get {
                return this.OutputMessageField;
            }
            set {
                if ((object.ReferenceEquals(this.OutputMessageField, value) != true)) {
                    this.OutputMessageField = value;
                    this.RaisePropertyChanged("OutputMessage");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="OutputForTemp3D", Namespace="http://schemas.datacontract.org/2004/07/WcfMathLibrary")]
    [System.SerializableAttribute()]
    public partial class OutputForTemp3D : ConsoleClient1DAskieva.ServiceReference1.OutputForTempBase {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private ConsoleClient1DAskieva.ServiceReference1.Array3DOfdouble UField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public ConsoleClient1DAskieva.ServiceReference1.Array3DOfdouble U {
            get {
                return this.UField;
            }
            set {
                if ((object.ReferenceEquals(this.UField, value) != true)) {
                    this.UField = value;
                    this.RaisePropertyChanged("U");
                }
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="OutputForTemp1D", Namespace="http://schemas.datacontract.org/2004/07/WcfMathLibrary")]
    [System.SerializableAttribute()]
    public partial class OutputForTemp1D : ConsoleClient1DAskieva.ServiceReference1.OutputForTempBase {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double[] UField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double[] U {
            get {
                return this.UField;
            }
            set {
                if ((object.ReferenceEquals(this.UField, value) != true)) {
                    this.UField = value;
                    this.RaisePropertyChanged("U");
                }
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="OutputForTemp", Namespace="http://schemas.datacontract.org/2004/07/WcfMathLibrary")]
    [System.SerializableAttribute()]
    public partial class OutputForTemp : ConsoleClient1DAskieva.ServiceReference1.OutputForTempBase {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double[][] UField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double[][] U {
            get {
                return this.UField;
            }
            set {
                if ((object.ReferenceEquals(this.UField, value) != true)) {
                    this.UField = value;
                    this.RaisePropertyChanged("U");
                }
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.IService1")]
    public interface IService1 {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/CalculateTemp", ReplyAction="http://tempuri.org/IService1/CalculateTempResponse")]
        ConsoleClient1DAskieva.ServiceReference1.OutputForTemp CalculateTemp(ConsoleClient1DAskieva.ServiceReference1.InputForTemp input);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/CalculateTemp", ReplyAction="http://tempuri.org/IService1/CalculateTempResponse")]
        System.Threading.Tasks.Task<ConsoleClient1DAskieva.ServiceReference1.OutputForTemp> CalculateTempAsync(ConsoleClient1DAskieva.ServiceReference1.InputForTemp input);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/CalculateTemp3D", ReplyAction="http://tempuri.org/IService1/CalculateTemp3DResponse")]
        ConsoleClient1DAskieva.ServiceReference1.OutputForTemp3D CalculateTemp3D(ConsoleClient1DAskieva.ServiceReference1.InputForTemp3D input3D);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/CalculateTemp3D", ReplyAction="http://tempuri.org/IService1/CalculateTemp3DResponse")]
        System.Threading.Tasks.Task<ConsoleClient1DAskieva.ServiceReference1.OutputForTemp3D> CalculateTemp3DAsync(ConsoleClient1DAskieva.ServiceReference1.InputForTemp3D input3D);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/CalculateTemp1D", ReplyAction="http://tempuri.org/IService1/CalculateTemp1DResponse")]
        ConsoleClient1DAskieva.ServiceReference1.OutputForTemp1D CalculateTemp1D(ConsoleClient1DAskieva.ServiceReference1.InputForTemp1D input1D);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/CalculateTemp1D", ReplyAction="http://tempuri.org/IService1/CalculateTemp1DResponse")]
        System.Threading.Tasks.Task<ConsoleClient1DAskieva.ServiceReference1.OutputForTemp1D> CalculateTemp1DAsync(ConsoleClient1DAskieva.ServiceReference1.InputForTemp1D input1D);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IService1Channel : ConsoleClient1DAskieva.ServiceReference1.IService1, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class Service1Client : System.ServiceModel.ClientBase<ConsoleClient1DAskieva.ServiceReference1.IService1>, ConsoleClient1DAskieva.ServiceReference1.IService1 {
        
        public Service1Client() {
        }
        
        public Service1Client(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public Service1Client(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public ConsoleClient1DAskieva.ServiceReference1.OutputForTemp CalculateTemp(ConsoleClient1DAskieva.ServiceReference1.InputForTemp input) {
            return base.Channel.CalculateTemp(input);
        }
        
        public System.Threading.Tasks.Task<ConsoleClient1DAskieva.ServiceReference1.OutputForTemp> CalculateTempAsync(ConsoleClient1DAskieva.ServiceReference1.InputForTemp input) {
            return base.Channel.CalculateTempAsync(input);
        }
        
        public ConsoleClient1DAskieva.ServiceReference1.OutputForTemp3D CalculateTemp3D(ConsoleClient1DAskieva.ServiceReference1.InputForTemp3D input3D) {
            return base.Channel.CalculateTemp3D(input3D);
        }
        
        public System.Threading.Tasks.Task<ConsoleClient1DAskieva.ServiceReference1.OutputForTemp3D> CalculateTemp3DAsync(ConsoleClient1DAskieva.ServiceReference1.InputForTemp3D input3D) {
            return base.Channel.CalculateTemp3DAsync(input3D);
        }
        
        public ConsoleClient1DAskieva.ServiceReference1.OutputForTemp1D CalculateTemp1D(ConsoleClient1DAskieva.ServiceReference1.InputForTemp1D input1D) {
            return base.Channel.CalculateTemp1D(input1D);
        }
        
        public System.Threading.Tasks.Task<ConsoleClient1DAskieva.ServiceReference1.OutputForTemp1D> CalculateTemp1DAsync(ConsoleClient1DAskieva.ServiceReference1.InputForTemp1D input1D) {
            return base.Channel.CalculateTemp1DAsync(input1D);
        }
    }
}