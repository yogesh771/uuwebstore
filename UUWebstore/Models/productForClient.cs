//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace UUWebstore.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class productForClient
    {
        public long productForWebClientId { get; set; }
        public long productId { get; set; }
        public string name { get; set; }
        public string sku { get; set; }
        public System.DateTime addedDate { get; set; }
        public string productTitle { get; set; }
        public string slugURL { get; set; }
        public int proCategoryId { get; set; }
        public int brandId { get; set; }
        public string descriptionHtml { get; set; }
        public string materialHtml { get; set; }
        public string productInformationHtml { get; set; }
        public string imprintInformationHtml { get; set; }
        public string ProductionHtml { get; set; }
        public string SpecificationsHtml { get; set; }
        public string ContentsHtml { get; set; }
        public string ShippingHtml { get; set; }
        public string pricingHtml { get; set; }
        public string PoductionHtml { get; set; }
        public string safetyAndCompliance { get; set; }
        public string unit { get; set; }
        public Nullable<long> userId { get; set; }
        public Nullable<bool> isShowPrice { get; set; }
        public long createdBy { get; set; }
        public System.DateTime createdDate { get; set; }
        public long modifiedBy { get; set; }
        public System.DateTime modifiedDate { get; set; }
        public bool isActive { get; set; }
        public bool isDelete { get; set; }
    }
}
