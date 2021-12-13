using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MyHealthPlus.DAL.ViewModels.Manage;
using MyHealthPlus.Services.Manage.StatusService;

namespace MyHealthPlus.Controllers.APIs.Manage
{
    [RoutePrefix("api/v1/status")]
    public class StatusApiController : BaseApiController
    {
        private readonly IStatusService _statusService;

        public StatusApiController(IStatusService statusService)
        {
            _statusService = statusService;
        }

        // GET api/v1/status/drop
        [HttpGet]
        [Route("drop")]
        public IHttpActionResult GetDd()
        {
            try
            {
                var dataList = _statusService.GetDrop();
                return Ok(dataList);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Api: Status | Function: GetDd");
                throw ex;
            }
        }

        // GET api/v1/status/tbl
        [HttpGet]
        [Route("tbl")]
        public IHttpActionResult GetTbl()
        {
            try
            {
                var dataList = _statusService.GetTbl();
                return Ok(dataList);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Api: Status | Function: GetTbl");
                throw ex;
            }
        }

        // GET api/v1/status/{id}
        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult GetById(int id)
        {
            try
            {
                var dataList = _statusService.GetById(id);
                return Ok(dataList);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Api: Status | Function: GetById");
                throw ex;
            }
        }

        // GET api/v1/status
        [HttpPost]
        [Route("")]
        public IHttpActionResult Save(SaveStatusVm data)
        {
            try
            {

                if (data.StatusId == 0)
                {
                    var dataList = _statusService.Save(data);
                    return Ok(dataList);
                }
                else
                {
                    data.UpdatedBy = data.CreatedBy;
                    data.CreatedBy = "";
                    var dataList = _statusService.Update(data);
                    return Ok(dataList);
                }

            }
            catch (Exception ex)
            {
                logger.Error(ex, "Api: Status | Function: Save");
                throw ex;
            }
        }


        // DELETE api/v1/status/off/{id}/{samAccount}
        [HttpDelete]
        [Route("off/{id}/{samAccount}")]
        public IHttpActionResult Off(int id, string samAccount)
        {
            try
            {
                var dataList = _statusService.ToggleOff(id, samAccount);
                return Ok(dataList);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Api: Status | Function: ToggleOff");
                throw ex;
            }
        }

        // DELETE api/v1/status/on/{id}/{samAccount}
        [HttpDelete]
        [Route("on/{id}/{samAccount}")]
        public IHttpActionResult On(int id, string samAccount)
        {
            try
            {
                var dataList = _statusService.ToggleOn(id, samAccount);
                return Ok(dataList);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Api: Status | Function: ToggleOn");
                throw ex;
            }
        }
    }
}