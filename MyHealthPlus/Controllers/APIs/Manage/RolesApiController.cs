using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MyHealthPlus.DAL.ViewModels.Manage;
using MyHealthPlus.Services.Manage.RolesService;

namespace MyHealthPlus.Controllers.APIs.Manage
{
    [RoutePrefix("api/v1/roles")]
    public class RolesApiController : BaseApiController
    {
        private readonly IRolesService _rolesService;

        public RolesApiController(IRolesService rolesService)
        {
            _rolesService = rolesService;
        }

        // GET api/v1/roles/drop
        [HttpGet]
        [Route("drop")]
        public IHttpActionResult GetDd()
        {
            try
            {
                var dataList = _rolesService.GetDrop();
                return Ok(dataList);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Api: Roles | Function: GetDd");
                throw ex;
            }
        }

        // GET api/v1/roles/tbl
        [HttpGet]
        [Route("tbl")]
        public IHttpActionResult GetTbl()
        {
            try
            {
                var dataList = _rolesService.GetTbl();
                return Ok(dataList);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Api: Roles | Function: GetTbl");
                throw ex;
            }
        }

        // GET api/v1/roles/{id}
        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult GetById(int id)
        {
            try
            {
                var dataList = _rolesService.GetById(id);
                return Ok(dataList);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Api: Roles | Function: GetById");
                throw ex;
            }
        }

        // GET api/v1/roles
        [HttpPost]
        [Route("")]
        public IHttpActionResult Insert(SaveRolesVm data)
        {
            try
            {

                if (data.RoleId == 0)
                {
                    var dataList = _rolesService.Save(data);
                    return Ok(dataList);
                }
                else
                {
                    data.UpdatedBy = data.CreatedBy;
                    data.CreatedBy = "";
                    var dataList = _rolesService.Update(data);
                    return Ok(dataList);
                }

            }
            catch (Exception ex)
            {
                logger.Error(ex, "Api: Roles | Function: Insert");
                throw ex;
            }
        }


        // DELETE api/v1/roles/off/{id}/{samAccount}
        [HttpDelete]
        [Route("off/{id}/{samAccount}")]
        public IHttpActionResult Off(int id, string samAccount)
        {
            try
            {
                var dataList = _rolesService.ToggleOff(id, samAccount);
                return Ok(dataList);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Api: Roles | Function: Off");
                throw ex;
            }
        }

        // DELETE api/v1/roles/on/{id}/{samAccount}
        [HttpDelete]
        [Route("on/{id}/{samAccount}")]
        public IHttpActionResult On(int id, string samAccount)
        {
            try
            {
                var dataList = _rolesService.ToggleOn(id, samAccount);
                return Ok(dataList);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Api: Roles | Function: On");
                throw ex;
            }
        }
    }
}