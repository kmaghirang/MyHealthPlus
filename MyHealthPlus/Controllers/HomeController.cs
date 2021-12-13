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
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View(Session["UserSession"] as UserSession);
        }

        public ActionResult MyAppointments()
        {
            return View(Session["UserSession"] as UserSession);
        }

        public ActionResult MySchedule()
        {
            return View(Session["UserSession"] as UserSession);
        }

    }
}