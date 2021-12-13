using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MyHealthPlus.DAL.ViewModels.Manage;
using MyHealthPlus.Services.Manage.CheckUpTypesService;

namespace MyHealthPlus.Controllers.APIs.Manage
{
    [RoutePrefix("api/v1/checkuptypes")]
    public class CheckUpTypesApiController : BaseApiController
    {
        private readonly ICheckUpTypesService _checkUpTypesService;

        public CheckUpTypesApiController(ICheckUpTypesService checkUpTypesService)
        {
            _checkUpTypesService = checkUpTypesService;
        }


        // GET api/v1/checkuptypes/drop
        [HttpGet]
        [Route("drop")]
        public IHttpActionResult GetDd()
        {
            try
            {
                var dataList = _checkUpTypesService.GetDrop();
                return Ok(dataList);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Api: CheckUpTypes | Function: GetDd");
                throw ex;
            }
        }

        // GET api/v1/checkuptypes/tbl
        [HttpGet]
        [Route("tbl")]
        public IHttpActionResult GetTbl()
        {
            try
            {
                var dataList = _checkUpTypesService.GetTbl();
                return Ok(dataList);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Api: CheckUpTypes | Function: GetTbl");
                throw ex;
            }
        }

        // GET api/v1/checkuptypes/{id}
        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult GetById(int id)
        {
            try
            {
                var dataList = _checkUpTypesService.GetById(id);
                return Ok(dataList);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Api: CheckUpTypes | Function: GetById");
                throw ex;
            }
        }

        // GET api/v1/checkuptypes
        [HttpPost]
        [Route("")]
        public IHttpActionResult Save(SaveCheckUpTypesVm data)
        {
            try
            {

                if (data.CheckUpTypeId == 0)
                {
                    var dataList = _checkUpTypesService.Save(data);
                    return Ok(dataList);
                }
                else
                {
                    data.UpdatedBy = data.CreatedBy;
                    var dataList = _checkUpTypesService.Update(data);
                    return Ok(dataList);
                }

            }
            catch (Exception ex)
            {
                logger.Error(ex, "Api: CheckUpTypes | Function: Insert");
                throw ex;
            }
        }


        // DELETE api/v1/checkuptypes/off/{id}/{samAccount}
        [HttpDelete]
        [Route("off/{id}/{samAccount}")]
        public IHttpActionResult Off(int id, string samAccount)
        {
            try
            {
                var dataList = _checkUpTypesService.ToggleOff(id, samAccount);
                return Ok(dataList);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Api: CheckUpTypes | Function: Off");
                throw ex;
            }
        }

        // DELETE api/v1/checkuptypes/on/{id}/{samAccount}
        [HttpDelete]
        [Route("on/{id}/{samAccount}")]
        public IHttpActionResult On(int id, string samAccount)
        {
            try
            {
                var dataList = _checkUpTypesService.ToggleOn(id, samAccount);
                return Ok(dataList);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Api: CheckUpTypes | Function: On");
                throw ex;
            }
        }
    }
}