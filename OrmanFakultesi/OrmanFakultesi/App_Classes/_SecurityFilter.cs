using OrmanFakultesi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace OrmanFakultesi.App_Classes
{
    public class _SecurityFilter: ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {

            string controllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;

            //if (HttpContext.Current.Session["Kullanici"] == null && (controllerName != "Login"))
            //{
            //    filterContext.Result = new RedirectResult("/Login/Index");
            //    return;
            //}
            //if (HttpContext.Current.Session["Kullanici"] != null)
            //{
            //    Kullanici k = (Kullanici)HttpContext.Current.Session["Kullanici"];
            //    if (k.Yetki.adi != "Yonetici" && (controllerName == "Yonetici" || controllerName == "Siparis"))
            //    {
            //        filterContext.Result = new RedirectResult("/Talep/Index");
            //        return;
            //    }
            //}

            base.OnActionExecuting(filterContext);
        }
    }
}