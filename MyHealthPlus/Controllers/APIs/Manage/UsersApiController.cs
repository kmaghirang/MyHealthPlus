using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MyHealthPlus.DAL.ViewModels.Manage;
using MyHealthPlus.Services.Manage.UsersService;

namespace MyHealthPlus.Controllers.APIs.Manage
{
    [RoutePrefix("api/v1/users")]
    public class UsersApiController : BaseApiController
    {
        private readonly IUsersService _usersService;

        public UsersApiController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        // GET api/v1/users/tbl
        [HttpGet]
        [Route("tbl")]
        public IHttpActionResult GetTbl()
        {
            try
            {
                var dataList = _usersService.GetTbl();
                return Ok(dataList);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Api: Users | Function: GetTbl");
                throw ex;
            }
        }

        // GET api/v1/users/{id}
        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult GetById(int id)
        {
            try
            {
                var dataList = _usersService.GetById(id);
                return Ok(dataList);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Api: Users | Function: GetById");
                throw ex;
            }
        }

        // GET api/v1/users
        [HttpPost]
        [Route("")]
        public IHttpActionResult Save(SaveUsersVm data)
        {
            try
            {
                var dataList = _usersService.UpdateUserRole(data);
                return Ok(dataList);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Api: Users | Function: UpdateUserRole");
                throw ex;
            }
        }


    }
}