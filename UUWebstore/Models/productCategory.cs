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
    
    public partial class productCategory
    {
        public int productCategoryId { get; set; }
        public string name { get; set; }
        public Nullable<int> parentCategoryid { get; set; }
        public long createdBy { get; set; }
        public System.DateTime createdDate { get; set; }
        public long modifiedBy { get; set; }
        public System.DateTime modifiedDate { get; set; }
        public bool isActive { get; set; }
        public bool isDelete { get; set; }
    }
}
