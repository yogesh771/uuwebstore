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
    
    public partial class ContactU
    {
        public long ContactID { get; set; }
        public string ContactPerson { get; set; }
        public string ContactNumber { get; set; }
        public string ContactEmail { get; set; }
        public string Message { get; set; }
        public Nullable<long> userId { get; set; }
        public Nullable<System.DateTime> createdate { get; set; }
        public string CompanyName { get; set; }
        public string Title { get; set; }
        public string CompanyUrl { get; set; }
        public bool isRead { get; set; }
    }
}
