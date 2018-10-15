using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UUWebstore.Models.viewModels;

namespace UUWebstore.Controllers
{
    public class accountController : Controller
    {
        // GET: account
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginIdViewModel oLoginIdViewModel)
        {
            return View();
        }
    }
}