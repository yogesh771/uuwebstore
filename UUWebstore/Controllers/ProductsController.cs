using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using UUWebstore.Models;
using UUWebstore.Models.BaseClass;
using UUWebstore.Models.IRepositories;
using UUWebstore.Models.Repositories;
using System.Data;
namespace UUWebstore.Controllers
{
    public class ProductsController : BaseClass
    {
        private readonly IsettingServices _IsettingServices;
        private readonly IProductServices _IProductServices;
        private readonly IaccountServices _IaccountServices;
        public ProductsController()
        {
            _IaccountServices = new accountServices();
            _IsettingServices = new settingServices();
            _IProductServices = new ProductServices();

        }
        public ActionResult Index()
        {
            search osearch = new search();
            osearch.roleID = 2;
            osearch.cityId = 0;
            osearch.countryId = 0;
            osearch.stateId = 0;
            ViewBag.userId = new SelectList(_IaccountServices.getFilteredUsers(osearch).Select(e => new { e.userId, e.fullName }), "userId", "fullName");
            ViewBag.productCategoryId = new SelectList(_IsettingServices.GetAllProductCategories(1).Select(e => new { e.productCategoryId, e.name }), "productCategoryId", "name");
            ViewBag.productSubCategoryId = new SelectList(_IProductServices.getProductSubcategoriesByProductCategoryId(1).Select(e => new { e.productSubCategoryId, e.name }), "productSubCategoryId", "name");
            return View();
        }
        public ActionResult fillProductSubcategories(Int32 productCategoryId)
        {
            JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
            var result = javaScriptSerializer.Serialize(_IProductServices.getProductSubcategoriesByProductCategoryId(productCategoryId).Select(e => new { e.productSubCategoryId, e.name }));
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public ActionResult fillProductCategories(Int32 productCategoryId)
        {
            JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
            var result = javaScriptSerializer.Serialize(_IsettingServices.GetAllProductCategories(productCategoryId).Select(e => new { e.productCategoryId, e.name }));
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Partial_SearchProductsReult(int productOptions_All_featured, int productCategoryId, int productSubCategoryId, int UserId)
        {            
            return PartialView("Partial_SearchProductsReult", _IProductServices.SearchProductsReult(productOptions_All_featured, productCategoryId,  productSubCategoryId,  UserId));
        }
        public bool makeFeaturedProduct(Int64 productId, bool chk)
        {
            return _IProductServices.MakeProductAsFeatured(productId, chk);
        }

        public ActionResult uploadProducts()
        {
            return View();
        }
        [ActionName("uploadProducts")]
        [HttpPost]
        public ActionResult uploadProducts1()
        {

            if (Request.Files["FileUpload1"].ContentLength > 0 && Request.Files["FileUpload1"].ContentLength < 10485760)
            {
                string extension = System.IO.Path.GetExtension(Request.Files["FileUpload1"].FileName).ToLower();

                string connString = "";


                string[] validFileTypes = { ".xls", ".xlsx", ".csv" };

                string path1 = string.Format("{0}/{1}", Server.MapPath("~/Content/productUploads"), Request.Files["FileUpload1"].FileName);
                if (!Directory.Exists(path1))
                {
                    Directory.CreateDirectory(Server.MapPath("~/Content/productUploads"));
                }
                if (validFileTypes.Contains(extension))
                {
                    if (System.IO.File.Exists(path1))
                    { System.IO.File.Delete(path1); }
                    Request.Files["FileUpload1"].SaveAs(path1);
                    if (extension.Trim() == ".xlsx")
                    {
                        connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path1 + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=2\"";
                        DataTable dt = Utility.ConvertXSLXtoDataTable(path1, connString);

                        List<productexcel> excel = new List<productexcel>();
                        productexcel objexcel;
                       
                            var c = (Int64)dt.Rows.Count;
                            for (Int32 i = 0; i < c; i++)
                            {
                                objexcel = new productexcel();                               
                                if (dt.Rows[i]["productName"].ToString() != "")
                                {
                                    objexcel.name = dt.Rows[i]["productName"].ToString().Trim().ToUpper();
                                }
                                else
                                {
                                    throw new Exception("Product name name not valid");
                                }

                                if (dt.Rows[i]["productsku"] != null) objexcel.sku = dt.Rows[i]["productsku"].ToString().Trim().ToUpper();
                               
                               
                                if (dt.Rows[i]["productTitle"].ToString() != "")
                                {
                                    objexcel.productTitle = dt.Rows[i]["productTitle"].ToString().Trim().ToUpper();
                                }
                                else
                                {
                                    throw new Exception("Product title name not valid");
                                }

                                if (dt.Rows[i]["slugURL"] != null) objexcel.slugURL = dt.Rows[i]["slugURL"].ToString().Trim().ToUpper();
                               
                                if (dt.Rows[i]["productCategory"].ToString() != "")
                                {
                                    objexcel.productCategory = dt.Rows[i]["productCategory"].ToString().Trim().ToUpper();
                                }
                                else
                                {
                                    throw new Exception("Product Category  not valid");
                                }

                                if (dt.Rows[i]["brand"] != null) objexcel.brand = dt.Rows[i]["brand"].ToString().Trim().ToUpper();
                              
                                if (dt.Rows[i]["descriptionHtml"].ToString() != "")
                                {
                                    objexcel.descriptionHtml = dt.Rows[i]["descriptionHtml"].ToString().Trim().ToUpper();
                                }
                                else
                                {
                                    throw new Exception("Product description not valid");
                                }

                                if (dt.Rows[i]["materialHtml"] != null) objexcel.materialHtml = dt.Rows[i]["materialHtml"].ToString().Trim().ToUpper();

                                if (dt.Rows[i]["productInformationHtml"] != null) objexcel.productInformationHtml = dt.Rows[i]["productInformationHtml"].ToString().Trim().ToUpper();
                                if (dt.Rows[i]["imprintInformationHtml"] != null) objexcel.imprintInformationHtml = dt.Rows[i]["imprintInformationHtml"].ToString();
                                
                                if(dt.Rows[i]["productionHtml"] != null) objexcel.productionHtml = dt.Rows[i]["productionHtml"].ToString().Trim();
                                if(dt.Rows[i]["specificationsHtml"] != null) objexcel.specificationsHtml = dt.Rows[i]["specificationsHtml"].ToString().Trim();
                                if(dt.Rows[i]["ContentsHtml"] != null)  objexcel.ContentsHtml = dt.Rows[i]["ContentsHtml"].ToString().Trim();
                                
                               
                                if (dt.Rows[i]["pricingHtml"] != null) objexcel.pricingHtml = dt.Rows[i]["pricingHtml"].ToString().Trim();
                                if (dt.Rows[i]["PoductionHtml"] != null) objexcel.PoductionHtml = dt.Rows[i]["PoductionHtml"].ToString().Trim();
                                if (dt.Rows[i]["safetyAndCompliance"] != "") objexcel.safetyAndCompliance = dt.Rows[i]["safetyAndCompliance"].ToString().Trim();
                                if (dt.Rows[i]["unit"] != null) objexcel.unit = dt.Rows[i]["unit"].ToString().Trim();

                                if (dt.Rows[i]["isShowPrice"] != null) objexcel.isShowPrice =Convert.ToBoolean( dt.Rows[i]["isShowPrice"].ToString().Trim());
                                if (dt.Rows[i]["supplier"] != null) objexcel.supplier = dt.Rows[i]["supplier"].ToString().Trim();
                                if (dt.Rows[i]["productImageURL"] != null) objexcel.productImageURL = dt.Rows[i]["productImageURL"].ToString().Trim();
                                if (dt.Rows[i]["productVideo"] != null) objexcel.productVideo = dt.Rows[i]["productVideo"].ToString().Trim();

                                if (dt.Rows[i]["productColor"] != null) objexcel.productColor = dt.Rows[i]["productColor"].ToString().Trim();
                                if (dt.Rows[i]["supplierMobile"] != null) objexcel.supplierMobile = dt.Rows[i]["supplierMobile"].ToString().Trim();
                                if (dt.Rows[i]["supplierEmailAddress"] != null) objexcel.supplierEmailAddress = dt.Rows[i]["supplierEmailAddress"].ToString().Trim();
                                if (dt.Rows[i]["SupplierWebsite"] != null) objexcel.SupplierWebsite = dt.Rows[i]["SupplierWebsite"].ToString().Trim();
                                excel.Add(objexcel);
                            }
                            sbv_uuwebstoreEntities ee = new sbv_uuwebstoreEntities();

                            ee.productexcels.AddRange(excel);
                            ee.SaveChanges();

                            var result = ee.Database.SqlQuery<string>("exec sp_productCRA_uploadExcel").ToList();
                            ViewBag.Data = dt;
                            ViewBag.ErrorData = result;                       
                    }
                    else
                    {
                        ViewBag.Error = "Please Upload File .xlsx format";
                    }

                }
            }
            return View();
        }

    }
}