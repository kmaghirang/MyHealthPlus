using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using MyHealthPlus.DAL.ViewModels.Login;

namespace MyHealthPlus.Controllers.ControllerAttributes
{
    public class SessionValidator : AuthorizeAttribute
    {
        private string _cntrlr = string.Empty;
        private string _act = string.Empty;
        private bool _hasSession;

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            _hasSession = false;
            var data = httpContext.Request.RequestContext.RouteData.Values;
            data.TryGetValue("controller", out var controller);
            _cntrlr = controller?.ToString() ?? string.Empty;
            data.TryGetValue("action", out var action);
            _act = action?.ToString() ?? string.Empty;

            var _controller = HttpContext.Current.Request.RequestContext.RouteData.Values["Controller"].ToString();

            if (_controller != "Login")
            {
                if (string.IsNullOrEmpty(_cntrlr) || string.IsNullOrEmpty(_act) || !(httpContext.Session["UserSession"] is UserSession e))
                    return false;
                _hasSession = true;//means Session account exist
                var isTrue = !string.IsNullOrEmpty(e.LastName);
                return isTrue;
            }
            else
            {
                return false;
            }

            //_hasSession = true;//means Session account exist

            ////var isTrue = !string.IsNullOrEmpty(e.HrId);
            ////return isTrue;
            //return true;
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            var _controller = HttpContext.Current.Request.RequestContext.RouteData.Values["Controller"].ToString();
            if (_hasSession)
            {
                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary(
                        new
                        {
                            controller = "Login",
                            action = "Index",
                            id = 602
                        })
                );
            }
            else
            {
                if (_controller != "Login")
                {
                    filterContext.Result = new RedirectToRouteResult(
                        new RouteValueDictionary(
                            new
                            {
                                controller = "Login",
                                action = "Index",
                            })
                    );
                }
            }
        }
    }
}