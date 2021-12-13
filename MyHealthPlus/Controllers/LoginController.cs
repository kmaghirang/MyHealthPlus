using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyHealthPlus.DAL.ViewModels.Login;
using MyHealthPlus.Services.Login.LoginService;

namespace MyHealthPlus.Controllers
{
    public class LoginController : BaseController
    {
        private readonly ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        // GET: Login
        public ActionResult ValidateUser(ParamsLoginVm data)
        {
            try
            {
                bool? user = _loginService.LoginValidation(data);

                if (user == null)
                {
                    return Json("no users", JsonRequestBehavior.AllowGet);
                }
                else
                {
                    if (user == false)
                    {
                        return Json(0, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        var userData = _loginService.GetSession(data);
                        Session["UserSession"] = userData;
                        return Json(userData.RoleId, JsonRequestBehavior.AllowGet);
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Controller: Login | Function: Validate");
                throw ex;
            }
        }

        [HttpGet]
        public ActionResult Logout()
        {
            Session["UserSession"] = null;

            if (Session["UserSession"] == null)
            {
                return Json(1, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(0, JsonRequestBehavior.AllowGet);
            }
        }
    }
}