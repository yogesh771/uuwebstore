using System;
using System.Linq;
using System.Web.Mvc;
using UUWebstore.Models;
using UUWebstore.Models.BaseClass;
using UUWebstore.Models.IRepositories;
using UUWebstore.Models.Repositories;

namespace UUWebstore.Controllers
{
    public class accountController : BaseClass
    {
        private readonly IaccountServices _IAccountServices;       
        public accountController()
        {
            _IAccountServices = new accountServices();           
        }
      
        // GET: account
        public ActionResult Index()
        {
            return View();
        }       
        public ActionResult Login()
        {
            ViewBag.message = "";
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginIdViewModel oLoginIdViewModel)
        {
            if (ModelState.IsValid)
            {
                var result=  _IAccountServices.UserLogin(oLoginIdViewModel.Email, oLoginIdViewModel.Password);
                if (result.message == "")
                {
                    BaseUtil.SetSessionValue(AdminInfo.LoginID.ToString(), result.userId.ToString());
                    BaseUtil.SetSessionValue(AdminInfo.FullName.ToString(), result.fullName.ToString());
                    BaseUtil.SetSessionValue(AdminInfo.userType.ToString(), result.roleID.ToString());
                    return RedirectToAction("Index");
                }
                else {
                    ViewBag.message = result.message;
                    return View(oLoginIdViewModel);
                }
             
            }
            else
            {
                var errors =  string.Join(" | ", ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage));
                CaptureErrorValues(errors);
            }
            return View(oLoginIdViewModel);
        }

        public ActionResult reset_password()
        {
            return View();
        }
        [HttpPost]
        public ActionResult reset_password(resetPassword oresetPassowrd)
        {
            if (ModelState.IsValid)
            {
                var result = _IAccountServices.resetPassword(oresetPassowrd);
                ViewBag.message = result;
                return View();
            }
            else
            {
                var errors = string.Join(" | ", ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage));
                CaptureErrorValues(errors);
                TempData["error"] = errors;
                return View("Error");
            }
            return View();
        }
        public ActionResult forgot_password()
        {
            return View();
        }
        [HttpPost]
        public string sendLinkToMail(string EmailAddress)
        {
            return _IAccountServices.getUserByEmailAddress(EmailAddress);
        }
        [HttpGet]      
        public ActionResult Reset__password(Int64 id)
        {
            ViewBag.id = id;
            return View();
        }
        [HttpPost]
        public ActionResult Reset__password(forgotPassword oforgotPassword)
        {
            ViewBag.message = _IAccountServices.resetPasswordFromForget(oforgotPassword);
            return View();
        }
        public ActionResult LogOut()
        {
            Session.Abandon();
            return RedirectToAction("Login");
        }
        public ActionResult NotFound404()
        {
            Response.StatusCode = 404;
            ViewBag.Title = "Error 404 - File not Found";
            return View();
        }
    }
}