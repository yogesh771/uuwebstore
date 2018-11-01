using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using UUWebstore.Models.IRepositories;

namespace UUWebstore.Models.Repositories
{
    public class settingServices : BaseClass.BaseClass, IsettingServices
    {

        private readonly UnitOfWork uow;

        public settingServices()
        {
            uow = new UnitOfWork();
        }
        public int uploadBanner(banner obanner)
        {
            obanner.modifiedBy = Convert.ToInt64(BaseUtil.GetSessionValue(AdminInfo.LoginID.ToString()).ToString());
            obanner.modifiedDate = BaseUtil.GetCurrentDateTime();
            obanner.userId = Convert.ToInt64(BaseUtil.GetSessionValue(AdminInfo.LoginID.ToString()).ToString());
            if (obanner.bannerId == 0)
            {
                obanner.createdBy = Convert.ToInt64(BaseUtil.GetSessionValue(AdminInfo.LoginID.ToString()).ToString());
                obanner.createdDate = BaseUtil.GetCurrentDateTime();
                obanner.isDelete = false;
                uow.banner_.Add(obanner);
                return 1;
            }
            else {              
                uow.banner_.Update(obanner);
                return 1;
            }
        }
        public List<bannersCreaTedBy_sp_Result> bannersCreaTedBy()
        {
          return  uow.sp_LoginUser_Result_.SQLQuery<bannersCreaTedBy_sp_Result>("bannersCreaTedBy_sp").ToList();
        }
        public List<getAllbannersCreatedBy_sp_Result> bannersCreaTedByUserId(Int64 userID)
        {
             var param_userID = new SqlParameter("@userID", userID);
             return uow.sp_LoginUser_Result_.SQLQuery<getAllbannersCreatedBy_sp_Result>("getAllbannersCreatedBy_sp @userId", param_userID).ToList();
        }
        public banner getBannerById(int bannerId)
        {
            return uow.banner_.GetByID(bannerId);
        }
        public List<getAllProductCategories_sp_Result> GetAllProductCategories(int ddl_filter)
        {
            var param_userid = new SqlParameter("@userid", SqlString.Null);
            var param_featuredOption = new SqlParameter("@featuredOption", ddl_filter);
            var res = uow.sp_LoginUser_Result_.SQLQuery<getAllProductCategories_sp_Result>("getAllProductCategories_sp @userid, @featuredOption", param_userid,param_featuredOption).ToList();
            return res;           
        }
        public int MakeProductCategoriesAsFeatured(int productCategoryId)
        {
            productCategoryClient obj = new productCategoryClient();
            obj.createdBy = Convert.ToInt64(BaseUtil.GetSessionValue(AdminInfo.LoginID.ToString()));
            obj.createdDate = BaseUtil.GetCurrentDateTime();
            obj.modifiedBy = Convert.ToInt64(BaseUtil.GetSessionValue(AdminInfo.LoginID.ToString()));
            obj.modifiedDate = BaseUtil.GetCurrentDateTime();
            obj.isFeaturedCategory = true;
            obj.proCategoryId = productCategoryId;
            obj.isActive = true;
            obj.isDelete = false;            
            uow.productCategoryClient_.Add(obj);
            return 1;
        }
        public int RemoveProductCategoriesAsFeatured(Int64 productCategoryId)
        {
            var userId = Convert.ToInt64(BaseUtil.GetSessionValue(AdminInfo.LoginID.ToString()));
            var productCategory=  uow.productCategoryClient_.Find(e=>e.proCategoryId==productCategoryId && e.createdBy== userId).FirstOrDefault();
            if(productCategory!=null)
            uow.productCategoryClient_.Remove(productCategory);
            return 1;
        }
    }
}