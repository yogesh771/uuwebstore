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
    
    public partial class clientWebInformation
    {
        public int ClientWebsiteInformationid { get; set; }
        public long userId { get; set; }
        public int themeId { get; set; }
        public Nullable<int> fontFamilyId { get; set; }
        public string logoName { get; set; }
        public string logoWebAddress { get; set; }
        public string FaviconName { get; set; }
        public string FaviconURL { get; set; }
        public string bussinessName { get; set; }
        public string businessContact { get; set; }
        public string homePageContent { get; set; }
        public string contactUsPageContent { get; set; }
        public string aboutUsPageContent { get; set; }
        public Nullable<long> visits { get; set; }
        public Nullable<long> clicks { get; set; }
        public Nullable<long> search { get; set; }
        public long createdBy { get; set; }
        public System.DateTime createdDate { get; set; }
        public long modifiedBy { get; set; }
        public System.DateTime modifiedDate { get; set; }
        public bool isActive { get; set; }
        public bool isDelete { get; set; }
        public string Facebook { get; set; }
        public string GPlus { get; set; }
        public string Twiter { get; set; }
        public string YouTube { get; set; }
        public string Instagram { get; set; }
        public string pinterest { get; set; }
        public string LinkedIn { get; set; }
        public string youTubePramotionAdmin { get; set; }
        public string BlockPramotionAdmin { get; set; }
    }
}
