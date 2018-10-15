using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using UUWebstore.Models;

namespace UUWebstore.Models.BaseClass
{
    public class BaseClass : Controller
    {

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            String ControllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName.ToUpper();
            String ActionName = filterContext.ActionDescriptor.ActionName.ToUpper();
            String Action = string.Format("{0}Controller{1}", ControllerName, ActionName).ToUpper();

            if (BaseUtil.ListControllerExcluded().Contains(ControllerName))
            {
                if (ControllerName == "ACCOUNT" || ControllerName == "HOME" || (ControllerName == "marketings" && ActionName == "INDEX") )
                {
                    return;
                }
            }
            if (BaseUtil.GetSessionValue(AdminInfo.LoginID.ToString()) == "")
            {
                filterContext.Result = null;
                filterContext.Result = new RedirectResult("/Account/login");
                return;
            }
            return;

        }
        protected override void OnException(ExceptionContext exceptionContext)
        {
             sbv_uuwebstoreEntities db = new sbv_uuwebstoreEntities();
            if (!exceptionContext.ExceptionHandled)
            {               
                exceptionContext.ExceptionHandled = true;
                Response.Redirect("~/Views/Shared/Error.cshtml");
            }
        }

    }
        
}