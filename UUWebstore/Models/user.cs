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
    
    public partial class user
    {
        public long userId { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        public string fullName { get; set; }
        public string phone { get; set; }
        public string mobile { get; set; }
        public string emailAddress { get; set; }
        public string website { get; set; }
        public string address { get; set; }
        public string location { get; set; }
        public string city { get; set; }
        public int stateId { get; set; }
        public int countryId { get; set; }
        public string zipcode { get; set; }
        public int roleID { get; set; }
        public string otp { get; set; }
        public long createdBy { get; set; }
        public System.DateTime createdDate { get; set; }
        public long modifiedBy { get; set; }
        public System.DateTime modifiedDate { get; set; }
        public bool isActive { get; set; }
        public bool isDelete { get; set; }
        public Nullable<bool> isBlocked { get; set; }
        public Nullable<System.DateTime> lastLogin { get; set; }
        public Nullable<System.DateTime> LastbadAttempt { get; set; }
        public Nullable<int> fakeAttemptCount { get; set; }
    }
}