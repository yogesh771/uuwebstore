﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class sbv_uuwebstoreEntities : DbContext
    {
        public sbv_uuwebstoreEntities()
            : base("name=sbv_uuwebstoreEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<ad> ads { get; set; }
        public virtual DbSet<adsSize> adsSizes { get; set; }
        public virtual DbSet<AppErrorLog> AppErrorLogs { get; set; }
        public virtual DbSet<brandClient> brandClients { get; set; }
        public virtual DbSet<brand> brands { get; set; }
        public virtual DbSet<city> cities { get; set; }
        public virtual DbSet<clientWebInformation> clientWebInformations { get; set; }
        public virtual DbSet<ClientWebsiteAdsInfo> ClientWebsiteAdsInfoes { get; set; }
        public virtual DbSet<ClientWebsiteBannerInfo> ClientWebsiteBannerInfoes { get; set; }
        public virtual DbSet<country> countries { get; set; }
        public virtual DbSet<enquiry> enquiries { get; set; }
        public virtual DbSet<fontFamily> fontFamilies { get; set; }
        public virtual DbSet<productAvailableSize> productAvailableSizes { get; set; }
        public virtual DbSet<productCategory> productCategories { get; set; }
        public virtual DbSet<productCategoryClient> productCategoryClients { get; set; }
        public virtual DbSet<productColor> productColors { get; set; }
        public virtual DbSet<productForClient> productForClients { get; set; }
        public virtual DbSet<productImage> productImages { get; set; }
        public virtual DbSet<ProductPrice> ProductPrices { get; set; }
        public virtual DbSet<productsCRA> productsCRAs { get; set; }
        public virtual DbSet<productVedio> productVedios { get; set; }
        public virtual DbSet<roleUser> roleUsers { get; set; }
        public virtual DbSet<state> states { get; set; }
        public virtual DbSet<supplierCategory> supplierCategories { get; set; }
        public virtual DbSet<supplierCategoryOption> supplierCategoryOptions { get; set; }
        public virtual DbSet<theme> themes { get; set; }
        public virtual DbSet<TodayOffer> TodayOffers { get; set; }
        public virtual DbSet<userRight> userRights { get; set; }
        public virtual DbSet<user> users { get; set; }
        public virtual DbSet<WebClientSupplier> WebClientSuppliers { get; set; }
        public virtual DbSet<banner> banners { get; set; }
        public virtual DbSet<sendGridDetail> sendGridDetails { get; set; }
    
        public virtual ObjectResult<sp_LoginUser_Result> sp_LoginUser(string password, string emailAddress)
        {
            var passwordParameter = password != null ?
                new ObjectParameter("password", password) :
                new ObjectParameter("password", typeof(string));
    
            var emailAddressParameter = emailAddress != null ?
                new ObjectParameter("emailAddress", emailAddress) :
                new ObjectParameter("emailAddress", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_LoginUser_Result>("sp_LoginUser", passwordParameter, emailAddressParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> resetPassword_sp(Nullable<long> userId, string oldPassword, string newPassword)
        {
            var userIdParameter = userId.HasValue ?
                new ObjectParameter("userId", userId) :
                new ObjectParameter("userId", typeof(long));
    
            var oldPasswordParameter = oldPassword != null ?
                new ObjectParameter("oldPassword", oldPassword) :
                new ObjectParameter("oldPassword", typeof(string));
    
            var newPasswordParameter = newPassword != null ?
                new ObjectParameter("newPassword", newPassword) :
                new ObjectParameter("newPassword", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("resetPassword_sp", userIdParameter, oldPasswordParameter, newPasswordParameter);
        }
    
        public virtual ObjectResult<getFilteredUsers_Result> getFilteredUsers(Nullable<int> roleID, Nullable<bool> isDeleted, string userName, string fullName, Nullable<int> cityid, Nullable<int> stateid, Nullable<int> countryid, string zipcode)
        {
            var roleIDParameter = roleID.HasValue ?
                new ObjectParameter("RoleID", roleID) :
                new ObjectParameter("RoleID", typeof(int));
    
            var isDeletedParameter = isDeleted.HasValue ?
                new ObjectParameter("isDeleted", isDeleted) :
                new ObjectParameter("isDeleted", typeof(bool));
    
            var userNameParameter = userName != null ?
                new ObjectParameter("userName", userName) :
                new ObjectParameter("userName", typeof(string));
    
            var fullNameParameter = fullName != null ?
                new ObjectParameter("fullName", fullName) :
                new ObjectParameter("fullName", typeof(string));
    
            var cityidParameter = cityid.HasValue ?
                new ObjectParameter("cityid", cityid) :
                new ObjectParameter("cityid", typeof(int));
    
            var stateidParameter = stateid.HasValue ?
                new ObjectParameter("stateid", stateid) :
                new ObjectParameter("stateid", typeof(int));
    
            var countryidParameter = countryid.HasValue ?
                new ObjectParameter("countryid", countryid) :
                new ObjectParameter("countryid", typeof(int));
    
            var zipcodeParameter = zipcode != null ?
                new ObjectParameter("zipcode", zipcode) :
                new ObjectParameter("zipcode", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<getFilteredUsers_Result>("getFilteredUsers", roleIDParameter, isDeletedParameter, userNameParameter, fullNameParameter, cityidParameter, stateidParameter, countryidParameter, zipcodeParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> applyTheme_sp(Nullable<int> themeId, Nullable<long> modifyBy)
        {
            var themeIdParameter = themeId.HasValue ?
                new ObjectParameter("themeId", themeId) :
                new ObjectParameter("themeId", typeof(int));
    
            var modifyByParameter = modifyBy.HasValue ?
                new ObjectParameter("modifyBy", modifyBy) :
                new ObjectParameter("modifyBy", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("applyTheme_sp", themeIdParameter, modifyByParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> updateLogo_sp(Nullable<int> logoUrl, Nullable<long> modifyBy)
        {
            var logoUrlParameter = logoUrl.HasValue ?
                new ObjectParameter("logoUrl", logoUrl) :
                new ObjectParameter("logoUrl", typeof(int));
    
            var modifyByParameter = modifyBy.HasValue ?
                new ObjectParameter("modifyBy", modifyBy) :
                new ObjectParameter("modifyBy", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("updateLogo_sp", logoUrlParameter, modifyByParameter);
        }
    }
}
