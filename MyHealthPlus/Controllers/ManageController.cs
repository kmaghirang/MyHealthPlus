using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyHealthPlus.Controllers.ControllerAttributes;
using MyHealthPlus.DAL.ViewModels.Login;

namespace MyHealthPlus.Controllers
{
    [SessionValidator]
    public class ManageController : BaseController
    {
        // GET: Manage
        public ActionResult Users()
        {
            return View(Session["UserSession"] as UserSession);
        }
    }
}