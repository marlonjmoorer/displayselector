﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DisplaySelector.ServiceDisplayMode {
    using System.Runtime.Serialization;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="RotationStates", Namespace="http://schemas.datacontract.org/2004/07/SixModeDetectorService")]
    public enum RotationStates : int {
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        MODE_LAPTOP = 0,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        MODE_WEDGE = 1,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        MODE_MOBILE = 2,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        MODE_LAYFLAT = 3,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        MODE_TENT = 4,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        MODE_BOOK = 5,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        MODE_UNKNOWN = 6,
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceDisplayMode.ISixModeService", CallbackContract=typeof(DisplaySelector.ServiceDisplayMode.ISixModeServiceCallback), SessionMode=System.ServiceModel.SessionMode.Required)]
    public interface ISixModeService {
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/ISixModeService/Register")]
        void Register();
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/ISixModeService/Register")]
        System.Threading.Tasks.Task RegisterAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISixModeService/GetRotationState", ReplyAction="http://tempuri.org/ISixModeService/GetRotationStateResponse")]
        DisplaySelector.ServiceDisplayMode.RotationStates GetRotationState();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISixModeService/GetRotationState", ReplyAction="http://tempuri.org/ISixModeService/GetRotationStateResponse")]
        System.Threading.Tasks.Task<DisplaySelector.ServiceDisplayMode.RotationStates> GetRotationStateAsync();
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/ISixModeService/SetRotationMode")]
        void SetRotationMode(int mode);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/ISixModeService/SetRotationMode")]
        System.Threading.Tasks.Task SetRotationModeAsync(int mode);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ISixModeServiceCallback {
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/ISixModeService/NotifySensorSixModeStates")]
        void NotifySensorSixModeStates(int rotationState);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ISixModeServiceChannel : DisplaySelector.ServiceDisplayMode.ISixModeService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class SixModeServiceClient : System.ServiceModel.DuplexClientBase<DisplaySelector.ServiceDisplayMode.ISixModeService>, DisplaySelector.ServiceDisplayMode.ISixModeService {
        
        public SixModeServiceClient(System.ServiceModel.InstanceContext callbackInstance) : 
                base(callbackInstance) {
        }
        
        public SixModeServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName) : 
                base(callbackInstance, endpointConfigurationName) {
        }
        
        public SixModeServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, string remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public SixModeServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public SixModeServiceClient(System.ServiceModel.InstanceContext callbackInstance, System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, binding, remoteAddress) {
        }
        
        public void Register() {
            base.Channel.Register();
        }
        
        public System.Threading.Tasks.Task RegisterAsync() {
            return base.Channel.RegisterAsync();
        }
        
        public DisplaySelector.ServiceDisplayMode.RotationStates GetRotationState() {
            return base.Channel.GetRotationState();
        }
        
        public System.Threading.Tasks.Task<DisplaySelector.ServiceDisplayMode.RotationStates> GetRotationStateAsync() {
            return base.Channel.GetRotationStateAsync();
        }
        
        public void SetRotationMode(int mode) {
            base.Channel.SetRotationMode(mode);
        }
        
        public System.Threading.Tasks.Task SetRotationModeAsync(int mode) {
            return base.Channel.SetRotationModeAsync(mode);
        }
    }
}
