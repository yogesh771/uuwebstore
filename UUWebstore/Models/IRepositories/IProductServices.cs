using System;
using System.Collections.Generic;

namespace UUWebstore.Models.IRepositories
{
   public interface IProductServices
    {
        List<productSubCategory> getProductSubcategoriesByProductCategoryId(int productCategoryId);
        List<getProductList_sp_Result> SearchProductsReult(int productOptions_All_featured, int productCategoryId, int productSubCategoryId, int UserId);
        bool MakeProductAsFeatured(Int64 productId, bool chk);
    }
}
