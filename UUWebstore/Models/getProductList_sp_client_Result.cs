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
    
    public partial class getProductList_sp_client_Result
    {
        public long productId { get; set; }
        public string name { get; set; }
        public string sku { get; set; }
        public string productTitle { get; set; }
        public string slugURL { get; set; }
        public int proCategoryId { get; set; }
        public Nullable<int> brandId { get; set; }
        public bool isActive { get; set; }
        public bool isDelete { get; set; }
        public string imgWebAddress { get; set; }
        public int productColorId { get; set; }
        public string colorName { get; set; }
        public Nullable<bool> isFeaturedProduct { get; set; }
        public int isMySelected { get; set; }
    }
}
