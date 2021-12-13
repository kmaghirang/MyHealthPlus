using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NLog;

namespace MyHealthPlus.Controllers
{
    public class BaseController : Controller
    {
        public static Logger logger = LogManager.GetLogger("databaseLogger");
    }
}