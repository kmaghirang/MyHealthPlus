using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Web.Http;
using MyHealthPlus.DAL.ViewModels.Login;
using MyHealthPlus.Services.Login.RegistrationService;

namespace MyHealthPlus.Controllers.APIs.Login
{
    [RoutePrefix("api/v1/registration")]
    public class RegistrationApiController : BaseApiController
    {
        private readonly IRegistrationService _registrationService;

        public RegistrationApiController(IRegistrationService registrationService)
        {
            _registrationService = registrationService;
        }

        // POST api/v1/registration
        [HttpPost]
        [Route("")]
        public IHttpActionResult RegisterUser(RegistrationVm data)
        {
            try
            {
                var dataList = _registrationService.RegisterUser(data);
                return Ok(dataList);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Api: RegistrationApiController | Function: RegisterUser");
                throw ex;
            }
        }

        // GET api/v1/registration/{username}
        [HttpGet]
        [Route("{username}")]
        public IHttpActionResult CheckUsername(string username)
        {
            try
            {
                var dataList = _registrationService.CheckUsername(username);
                return Ok(dataList);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Api: RegistrationApiController | Function: CheckUsername");
                throw ex;
            }
        }
    }
}