using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using NLog;

namespace MyHealthPlus.Controllers.APIs
{
    public class BaseApiController : ApiController
    {
        public static Logger logger = LogManager.GetLogger("databaseLogger");
    }
}