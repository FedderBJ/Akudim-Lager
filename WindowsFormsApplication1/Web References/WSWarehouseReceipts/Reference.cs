﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by Microsoft.VSDesigner, Version 4.0.30319.42000.
// 
#pragma warning disable 1591

namespace WindowsFormsApplication1.WSWarehouseReceipts {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.Xml.Serialization;
    using System.ComponentModel;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1038.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="WhseReceiptList_Binding", Namespace="urn:microsoft-dynamics-schemas/page/whsereceiptlist")]
    public partial class WhseReceiptList_Service : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback ReadOperationCompleted;
        
        private System.Threading.SendOrPostCallback ReadByRecIdOperationCompleted;
        
        private System.Threading.SendOrPostCallback ReadMultipleOperationCompleted;
        
        private System.Threading.SendOrPostCallback IsUpdatedOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetRecIdFromKeyOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public WhseReceiptList_Service() {
            this.Url = global::WindowsFormsApplication1.Properties.Settings.Default.WindowsFormsApplication1_WSWarehouseReceipts_WhseReceiptList_Service;
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event ReadCompletedEventHandler ReadCompleted;
        
        /// <remarks/>
        public event ReadByRecIdCompletedEventHandler ReadByRecIdCompleted;
        
        /// <remarks/>
        public event ReadMultipleCompletedEventHandler ReadMultipleCompleted;
        
        /// <remarks/>
        public event IsUpdatedCompletedEventHandler IsUpdatedCompleted;
        
        /// <remarks/>
        public event GetRecIdFromKeyCompletedEventHandler GetRecIdFromKeyCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("urn:microsoft-dynamics-schemas/page/whsereceiptlist:Read", RequestNamespace="urn:microsoft-dynamics-schemas/page/whsereceiptlist", ResponseElementName="Read_Result", ResponseNamespace="urn:microsoft-dynamics-schemas/page/whsereceiptlist", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute("WhseReceiptList")]
        public WhseReceiptList Read(string No) {
            object[] results = this.Invoke("Read", new object[] {
                        No});
            return ((WhseReceiptList)(results[0]));
        }
        
        /// <remarks/>
        public void ReadAsync(string No) {
            this.ReadAsync(No, null);
        }
        
        /// <remarks/>
        public void ReadAsync(string No, object userState) {
            if ((this.ReadOperationCompleted == null)) {
                this.ReadOperationCompleted = new System.Threading.SendOrPostCallback(this.OnReadOperationCompleted);
            }
            this.InvokeAsync("Read", new object[] {
                        No}, this.ReadOperationCompleted, userState);
        }
        
        private void OnReadOperationCompleted(object arg) {
            if ((this.ReadCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.ReadCompleted(this, new ReadCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("urn:microsoft-dynamics-schemas/page/whsereceiptlist:ReadByRecId", RequestNamespace="urn:microsoft-dynamics-schemas/page/whsereceiptlist", ResponseElementName="ReadByRecId_Result", ResponseNamespace="urn:microsoft-dynamics-schemas/page/whsereceiptlist", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute("WhseReceiptList")]
        public WhseReceiptList ReadByRecId(string recId) {
            object[] results = this.Invoke("ReadByRecId", new object[] {
                        recId});
            return ((WhseReceiptList)(results[0]));
        }
        
        /// <remarks/>
        public void ReadByRecIdAsync(string recId) {
            this.ReadByRecIdAsync(recId, null);
        }
        
        /// <remarks/>
        public void ReadByRecIdAsync(string recId, object userState) {
            if ((this.ReadByRecIdOperationCompleted == null)) {
                this.ReadByRecIdOperationCompleted = new System.Threading.SendOrPostCallback(this.OnReadByRecIdOperationCompleted);
            }
            this.InvokeAsync("ReadByRecId", new object[] {
                        recId}, this.ReadByRecIdOperationCompleted, userState);
        }
        
        private void OnReadByRecIdOperationCompleted(object arg) {
            if ((this.ReadByRecIdCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.ReadByRecIdCompleted(this, new ReadByRecIdCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("urn:microsoft-dynamics-schemas/page/whsereceiptlist:ReadMultiple", RequestNamespace="urn:microsoft-dynamics-schemas/page/whsereceiptlist", ResponseElementName="ReadMultiple_Result", ResponseNamespace="urn:microsoft-dynamics-schemas/page/whsereceiptlist", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlArrayAttribute("ReadMultiple_Result")]
        [return: System.Xml.Serialization.XmlArrayItemAttribute(IsNullable=false)]
        public WhseReceiptList[] ReadMultiple([System.Xml.Serialization.XmlElementAttribute("filter")] WhseReceiptList_Filter[] filter, string bookmarkKey, int setSize) {
            object[] results = this.Invoke("ReadMultiple", new object[] {
                        filter,
                        bookmarkKey,
                        setSize});
            return ((WhseReceiptList[])(results[0]));
        }
        
        /// <remarks/>
        public void ReadMultipleAsync(WhseReceiptList_Filter[] filter, string bookmarkKey, int setSize) {
            this.ReadMultipleAsync(filter, bookmarkKey, setSize, null);
        }
        
        /// <remarks/>
        public void ReadMultipleAsync(WhseReceiptList_Filter[] filter, string bookmarkKey, int setSize, object userState) {
            if ((this.ReadMultipleOperationCompleted == null)) {
                this.ReadMultipleOperationCompleted = new System.Threading.SendOrPostCallback(this.OnReadMultipleOperationCompleted);
            }
            this.InvokeAsync("ReadMultiple", new object[] {
                        filter,
                        bookmarkKey,
                        setSize}, this.ReadMultipleOperationCompleted, userState);
        }
        
        private void OnReadMultipleOperationCompleted(object arg) {
            if ((this.ReadMultipleCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.ReadMultipleCompleted(this, new ReadMultipleCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("urn:microsoft-dynamics-schemas/page/whsereceiptlist:IsUpdated", RequestNamespace="urn:microsoft-dynamics-schemas/page/whsereceiptlist", ResponseElementName="IsUpdated_Result", ResponseNamespace="urn:microsoft-dynamics-schemas/page/whsereceiptlist", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute("IsUpdated_Result")]
        public bool IsUpdated(string Key) {
            object[] results = this.Invoke("IsUpdated", new object[] {
                        Key});
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        public void IsUpdatedAsync(string Key) {
            this.IsUpdatedAsync(Key, null);
        }
        
        /// <remarks/>
        public void IsUpdatedAsync(string Key, object userState) {
            if ((this.IsUpdatedOperationCompleted == null)) {
                this.IsUpdatedOperationCompleted = new System.Threading.SendOrPostCallback(this.OnIsUpdatedOperationCompleted);
            }
            this.InvokeAsync("IsUpdated", new object[] {
                        Key}, this.IsUpdatedOperationCompleted, userState);
        }
        
        private void OnIsUpdatedOperationCompleted(object arg) {
            if ((this.IsUpdatedCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.IsUpdatedCompleted(this, new IsUpdatedCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("urn:microsoft-dynamics-schemas/page/whsereceiptlist:GetRecIdFromKey", RequestNamespace="urn:microsoft-dynamics-schemas/page/whsereceiptlist", ResponseElementName="GetRecIdFromKey_Result", ResponseNamespace="urn:microsoft-dynamics-schemas/page/whsereceiptlist", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute("GetRecIdFromKey_Result")]
        public string GetRecIdFromKey(string Key) {
            object[] results = this.Invoke("GetRecIdFromKey", new object[] {
                        Key});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void GetRecIdFromKeyAsync(string Key) {
            this.GetRecIdFromKeyAsync(Key, null);
        }
        
        /// <remarks/>
        public void GetRecIdFromKeyAsync(string Key, object userState) {
            if ((this.GetRecIdFromKeyOperationCompleted == null)) {
                this.GetRecIdFromKeyOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetRecIdFromKeyOperationCompleted);
            }
            this.InvokeAsync("GetRecIdFromKey", new object[] {
                        Key}, this.GetRecIdFromKeyOperationCompleted, userState);
        }
        
        private void OnGetRecIdFromKeyOperationCompleted(object arg) {
            if ((this.GetRecIdFromKeyCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetRecIdFromKeyCompleted(this, new GetRecIdFromKeyCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024) 
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="urn:microsoft-dynamics-schemas/page/whsereceiptlist")]
    public partial class WhseReceiptList {
        
        private string keyField;
        
        private string noField;
        
        private string location_CodeField;
        
        private string assigned_User_IDField;
        
        private Sorting_Method sorting_MethodField;
        
        private bool sorting_MethodFieldSpecified;
        
        private string zone_CodeField;
        
        private string bin_CodeField;
        
        private Document_Status document_StatusField;
        
        private bool document_StatusFieldSpecified;
        
        private System.DateTime posting_DateField;
        
        private bool posting_DateFieldSpecified;
        
        private System.DateTime assignment_DateField;
        
        private bool assignment_DateFieldSpecified;
        
        private string buy_from_Vendor_NameField;
        
        private string vendor_Order_NoField;
        
        private Order_Type order_TypeField;
        
        private bool order_TypeFieldSpecified;
        
        private string order_NoField;
        
        /// <remarks/>
        public string Key {
            get {
                return this.keyField;
            }
            set {
                this.keyField = value;
            }
        }
        
        /// <remarks/>
        public string No {
            get {
                return this.noField;
            }
            set {
                this.noField = value;
            }
        }
        
        /// <remarks/>
        public string Location_Code {
            get {
                return this.location_CodeField;
            }
            set {
                this.location_CodeField = value;
            }
        }
        
        /// <remarks/>
        public string Assigned_User_ID {
            get {
                return this.assigned_User_IDField;
            }
            set {
                this.assigned_User_IDField = value;
            }
        }
        
        /// <remarks/>
        public Sorting_Method Sorting_Method {
            get {
                return this.sorting_MethodField;
            }
            set {
                this.sorting_MethodField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool Sorting_MethodSpecified {
            get {
                return this.sorting_MethodFieldSpecified;
            }
            set {
                this.sorting_MethodFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        public string Zone_Code {
            get {
                return this.zone_CodeField;
            }
            set {
                this.zone_CodeField = value;
            }
        }
        
        /// <remarks/>
        public string Bin_Code {
            get {
                return this.bin_CodeField;
            }
            set {
                this.bin_CodeField = value;
            }
        }
        
        /// <remarks/>
        public Document_Status Document_Status {
            get {
                return this.document_StatusField;
            }
            set {
                this.document_StatusField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool Document_StatusSpecified {
            get {
                return this.document_StatusFieldSpecified;
            }
            set {
                this.document_StatusFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="date")]
        public System.DateTime Posting_Date {
            get {
                return this.posting_DateField;
            }
            set {
                this.posting_DateField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool Posting_DateSpecified {
            get {
                return this.posting_DateFieldSpecified;
            }
            set {
                this.posting_DateFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="date")]
        public System.DateTime Assignment_Date {
            get {
                return this.assignment_DateField;
            }
            set {
                this.assignment_DateField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool Assignment_DateSpecified {
            get {
                return this.assignment_DateFieldSpecified;
            }
            set {
                this.assignment_DateFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        public string Buy_from_Vendor_Name {
            get {
                return this.buy_from_Vendor_NameField;
            }
            set {
                this.buy_from_Vendor_NameField = value;
            }
        }
        
        /// <remarks/>
        public string Vendor_Order_No {
            get {
                return this.vendor_Order_NoField;
            }
            set {
                this.vendor_Order_NoField = value;
            }
        }
        
        /// <remarks/>
        public Order_Type Order_Type {
            get {
                return this.order_TypeField;
            }
            set {
                this.order_TypeField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool Order_TypeSpecified {
            get {
                return this.order_TypeFieldSpecified;
            }
            set {
                this.order_TypeFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        public string Order_No {
            get {
                return this.order_NoField;
            }
            set {
                this.order_NoField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="urn:microsoft-dynamics-schemas/page/whsereceiptlist")]
    public enum Sorting_Method {
        
        /// <remarks/>
        _blank_,
        
        /// <remarks/>
        Item,
        
        /// <remarks/>
        Document,
        
        /// <remarks/>
        Shelf_or_Bin,
        
        /// <remarks/>
        Due_Date,
        
        /// <remarks/>
        Ship_To,
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="urn:microsoft-dynamics-schemas/page/whsereceiptlist")]
    public enum Document_Status {
        
        /// <remarks/>
        _blank_,
        
        /// <remarks/>
        Partially_Received,
        
        /// <remarks/>
        Completely_Received,
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="urn:microsoft-dynamics-schemas/page/whsereceiptlist")]
    public enum Order_Type {
        
        /// <remarks/>
        Sales_Order,
        
        /// <remarks/>
        Sales_Return_Order,
        
        /// <remarks/>
        Purchase_Order,
        
        /// <remarks/>
        Purchase_Return_Order,
        
        /// <remarks/>
        Inbound_Transfer,
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="urn:microsoft-dynamics-schemas/page/whsereceiptlist")]
    public partial class WhseReceiptList_Filter {
        
        private WhseReceiptList_Fields fieldField;
        
        private string criteriaField;
        
        /// <remarks/>
        public WhseReceiptList_Fields Field {
            get {
                return this.fieldField;
            }
            set {
                this.fieldField = value;
            }
        }
        
        /// <remarks/>
        public string Criteria {
            get {
                return this.criteriaField;
            }
            set {
                this.criteriaField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="urn:microsoft-dynamics-schemas/page/whsereceiptlist")]
    public enum WhseReceiptList_Fields {
        
        /// <remarks/>
        No,
        
        /// <remarks/>
        Location_Code,
        
        /// <remarks/>
        Assigned_User_ID,
        
        /// <remarks/>
        Sorting_Method,
        
        /// <remarks/>
        Zone_Code,
        
        /// <remarks/>
        Bin_Code,
        
        /// <remarks/>
        Document_Status,
        
        /// <remarks/>
        Posting_Date,
        
        /// <remarks/>
        Assignment_Date,
        
        /// <remarks/>
        Buy_from_Vendor_Name,
        
        /// <remarks/>
        Vendor_Order_No,
        
        /// <remarks/>
        Order_Type,
        
        /// <remarks/>
        Order_No,
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1038.0")]
    public delegate void ReadCompletedEventHandler(object sender, ReadCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1038.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class ReadCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal ReadCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public WhseReceiptList Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((WhseReceiptList)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1038.0")]
    public delegate void ReadByRecIdCompletedEventHandler(object sender, ReadByRecIdCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1038.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class ReadByRecIdCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal ReadByRecIdCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public WhseReceiptList Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((WhseReceiptList)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1038.0")]
    public delegate void ReadMultipleCompletedEventHandler(object sender, ReadMultipleCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1038.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class ReadMultipleCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal ReadMultipleCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public WhseReceiptList[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((WhseReceiptList[])(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1038.0")]
    public delegate void IsUpdatedCompletedEventHandler(object sender, IsUpdatedCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1038.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class IsUpdatedCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal IsUpdatedCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public bool Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((bool)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1038.0")]
    public delegate void GetRecIdFromKeyCompletedEventHandler(object sender, GetRecIdFromKeyCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1038.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetRecIdFromKeyCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetRecIdFromKeyCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591