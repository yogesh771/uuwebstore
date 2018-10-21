using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using UUWebstore.Models;
using UUWebstore.Models.BaseClass;
using UUWebstore.Models.IRepositories;
using UUWebstore.Models.Repositories;
using UUWebstore.Models;

namespace UUWebstore.Controllers
{
    public class usersController : BaseClass
    {
        private readonly IRoleUserServices _IRoleUserServicess;
        private readonly IaccountServices _IAccountServices;
        private readonly IStateServices _IStateServices;
        private readonly ICountryServices _ICountryServices;
        public usersController()
        {
            _IAccountServices = new accountServices();
             _IRoleUserServicess = new RoleUserSerives();
            _IStateServices = new StateServices();
            _ICountryServices = new CountryServices();
        }

        // GET: users
        public ActionResult Index()
        {

            return View();
        }
        public ActionResult Add_user()
        {
            ViewBag.roleID = _IRoleUserServicess.getAllRoles().Select(e => new { e.roleID, e.name });
            ViewBag.countryId = _ICountryServices.getAllCountries().Select(e => new { e.countryId, e.name });
            ViewBag.stateId = _IStateServices.getAllStatesByCountryId(1).Select(e => new { e.stateId, e.name });
            ViewBag.cityId= _IStateServices.getAllCityByStateId(1).Select(e => new { e.cityId, e.CityName });
            return View();
        }
        public ActionResult fillState(Int32 countryID)
        {
            JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
            string result = javaScriptSerializer.Serialize(_IStateServices.getAllStatesByCountryId(countryID).Select(e => new { e.stateId, e.name }));
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public ActionResult fillCity(Int32 stateId)
        {
            JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
            string result = javaScriptSerializer.Serialize(_IStateServices.getAllCityByStateId(stateId).Select(e => new { e.cityId, e.CityName }));
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        
        [HttpPost]
        public ActionResult Add_user(UUWebstore.Models.user objUser)
        {
            ViewBag.roleID = _IRoleUserServicess.getAllRoles().Select(e => new { e.roleID, e.name });
            ViewBag.countryId = _ICountryServices.getAllCountries().Select(e => new { e.countryId, e.name });
            ViewBag.stateId = _IStateServices.getAllStatesByCountryId(1).Select(e => new { e.stateId, e.name });
            ViewBag.cityId = _IStateServices.getAllCityByStateId(1).Select(e => new { e.cityId, e.CityName });

            if (!IsUserExists_(objUser.userName))
            {
                ViewBag.message = "User name already exists in database.";
            }
            else if (!IsMobileExists_(objUser.mobile))
            {
                ViewBag.message = "Mobile number already exists in database.";
            }
            else if (!IsEmailExists_(objUser.emailAddress))
            {
                ViewBag.message = "Email address already exists in database.";
            }
            else
            {
                bool result = _IAccountServices.create_update_userINformations_sp(objUser);
                ViewBag.message = "Record saved.";
            }
            ViewBag.message = "Record not saved.";
            return View();
        }
      
        public ActionResult Edit(Int64 userID)
        {
            ModelState.Remove("userName");
            ModelState.Remove("mobile");
            ModelState.Remove("emailAddress");
            var user = _IAccountServices.getUserById(userID);
            ViewBag.roleID = new SelectList(_IRoleUserServicess.getAllRoles().Select(e => new { e.roleID, e.name }), "roleID", "name", user.roleID);
            ViewBag.countryId = new SelectList(_ICountryServices.getAllCountries().Select(e => new { e.countryId, e.name }), "countryId", "name", user.countryId);
            ViewBag.stateId = new SelectList(_IStateServices.getAllStatesByCountryId(0).Select(e => new { e.stateId, e.name }), "stateId", "name", user.stateId);
            ViewBag.cityId = new SelectList(_IStateServices.getAllCityByStateId(0).Select(e => new { e.cityId, e.CityName }), "cityId", "CityName", user.cityId);
            return View(user);
        }
        [HttpPost]
        public ActionResult Edit(user user)
        {            
            ViewBag.roleID = new SelectList(_IRoleUserServicess.getAllRoles().Select(e => new { e.roleID, e.name }), "roleID", "name", user.roleID);
            ViewBag.countryId = new SelectList(_ICountryServices.getAllCountries().Select(e => new { e.countryId, e.name }), "countryId", "name", user.countryId);
            ViewBag.stateId = new SelectList(_IStateServices.getAllStatesByCountryId(0).Select(e => new { e.stateId, e.name }), "stateId", "name", user.stateId);
            ViewBag.cityId = new SelectList(_IStateServices.getAllCityByStateId(0).Select(e => new { e.cityId, e.CityName }), "cityId", "CityName", user.cityId);
            bool result = _IAccountServices.create_update_userINformations_sp(user);
            ViewBag.message= result==true ? "Record saved.":  "Record not saved.";
         return View(user);
        }

        public JsonResult IsUserExists(string userName,string PreviousUsername)
        {
            if (userName == PreviousUsername)
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(_IAccountServices.boolCheckExiststance(userName, "uname"), JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult IsMobileExists(string mobile,string Previousmobile)
        {
            if (mobile == Previousmobile)
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(_IAccountServices.boolCheckExiststance(mobile, "mobile"), JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult IsEmailExists(string emailAddress, string PreviousemailAddress)
        {
            if (emailAddress == PreviousemailAddress)
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(_IAccountServices.boolCheckExiststance(emailAddress, "email"), JsonRequestBehavior.AllowGet);
            }
        }

        public bool IsUserExists_(string userName)
        {
            return _IAccountServices.boolCheckExiststance(userName, "uname");
        }       
        public bool IsMobileExists_(string mobile)
        {
            return _IAccountServices.boolCheckExiststance(mobile, "mobile");
        }
        public bool IsEmailExists_(string emailAddress)
        {
            return _IAccountServices.boolCheckExiststance(emailAddress, "email");
        }
        public ActionResult searchUser()
        {
            ViewBag.roleID = new SelectList(_IRoleUserServicess.getAllRoles().Select(e => new { e.roleID, e.name }), "roleID","name",2);
            ViewBag.countryId = new SelectList(_ICountryServices.getAllCountries().Select(e => new { e.countryId, e.name }), "countryId", "name");
            ViewBag.stateId = new SelectList(_IStateServices.getAllStatesByCountryId(1).Select(e => new { e.stateId, e.name }), "stateId", "name");
            ViewBag.cityId = new SelectList(_IStateServices.getAllCityByStateId(1).Select(e => new { e.cityId, e.CityName }),"cityId","CityName");
            return View();
        }
        public ActionResult Partial_SearchUsersReult(int roleID, string  countryId, string stateId, string cityId, string userName, string fullName, string zipcode)
        {
            search osearch = new search();
            osearch.roleID = roleID;
            osearch.countryId = countryId == "" ? 0 : Convert.ToInt32(countryId);
            osearch.stateId =  stateId==""?0:Convert.ToInt32(stateId);
            osearch.cityId = cityId == "" ? 0 : Convert.ToInt32(cityId);
            osearch.userName = userName;
            osearch.fullName = fullName;
            osearch.zipcode = zipcode;
            var result = _IAccountServices.getFilteredUsers(osearch);
            return PartialView("Partial_SearchUsersReult", result);
        }
    }
}