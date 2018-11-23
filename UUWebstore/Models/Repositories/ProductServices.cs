using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using UUWebstore.Models.IRepositories;

namespace UUWebstore.Models.Repositories
{
    public class ProductServices : BaseClass.BaseClass, IProductServices
    {
        private readonly UnitOfWork uow;

        public ProductServices()
        {
            uow = new UnitOfWork();
        }
        public List<productSubCategory> getProductSubcategoriesByProductCategoryId(int productCategoryId)
        {
            return uow.ProductSubCategory.Find(e => e.productCategoryId == productCategoryId).ToList();
        }
        public List<getProductList_sp_Result>SearchProductsReult(int productOptions_All_featured, int productCategoryId, int productSubCategoryId, int UserId)
        {
            var productOptions_All_featured_ = new SqlParameter("@productOptions_All_featured", productOptions_All_featured );
          
            var productCategoryId_ = new SqlParameter("@productCategoryId", SqlString.Null);
            if (productCategoryId!=0)
                productCategoryId_ = new SqlParameter("@productCategoryId", productCategoryId);


            var productSubCategoryId_ = new SqlParameter("@productSubCategoryId", SqlString.Null);
            if (productSubCategoryId != 0)
                productSubCategoryId_ = new SqlParameter("@productSubCategoryId", productCategoryId);


            var UserId_ = new SqlParameter("@UserId", SqlString.Null);
            if (UserId != 0)
                UserId_ = new SqlParameter("@UserId", UserId);


            var result = uow.sp_LoginUser_Result_.SQLQuery<getProductList_sp_Result>("getProductList_sp @productOptions_All_featured,@productCategoryId,@productSubCategoryId,@UserId",
                                                                                   productOptions_All_featured_, productCategoryId_, productSubCategoryId_, UserId_).ToList();
            return result;
        }

        public bool MakeProductAsFeatured(Int64 productId, bool chk)
        {

            var product = uow.ProductsCRA_.GetByID(productId);
            product.modifiedBy= Convert.ToInt64(BaseUtil.GetSessionValue(AdminInfo.LoginID.ToString()));
            product.modifiedDate = BaseUtil.GetCurrentDateTime();
            product.isFeaturedProduct = chk;
            uow.ProductsCRA_.Update(product);
            return true;
        }
    }
}