using CandidateTracker.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CadidateTracker.web
{
    public class LayoutDataAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var db = new CandidateRepository(Properties.Settings.Default.ConStr);
            filterContext.Controller.ViewBag.Pending = db.GetCount(Status.Pending);
            filterContext.Controller.ViewBag.Confirmed = db.GetCount(Status.Confirmed);
            filterContext.Controller.ViewBag.Refused = db.GetCount(Status.Refused);
            base.OnActionExecuting(filterContext);
        }
    }
}