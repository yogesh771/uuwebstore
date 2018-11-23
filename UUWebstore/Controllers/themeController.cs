using System.Web.Mvc;
using UUWebstore.Models.BaseClass;
using UUWebstore.Models.IRepositories;
using UUWebstore.Models.Repositories;

namespace UUWebstore.Controllers
{
    public class themeController : BaseClass
    {
        private readonly IthemeServices _IthemeServices;       
        public themeController()
        {
            _IthemeServices = new themeServices();         
        }

        // GET: theme
        public ActionResult Index()
        {
            return View(_IthemeServices.getallTheme());
        }
        public int applytheme(int themeId)
        {
           return  _IthemeServices.ApplyTheme(themeId);
        }
       
      
    }
}