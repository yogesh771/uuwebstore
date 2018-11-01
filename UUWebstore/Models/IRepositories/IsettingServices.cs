using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UUWebstore.Models.IRepositories
{
   public interface IsettingServices
    {
        int uploadBanner(banner obanner);
        List<bannersCreaTedBy_sp_Result> bannersCreaTedBy();
        List<getAllbannersCreatedBy_sp_Result> bannersCreaTedByUserId(Int64 userID);
        banner getBannerById(int bannerId);
        List<getAllProductCategories_sp_Result> GetAllProductCategories(int ddl_filter);
        int RemoveProductCategoriesAsFeatured(Int64 productCategoryId);
        int MakeProductCategoriesAsFeatured(int productCategoryId);
    }
}
