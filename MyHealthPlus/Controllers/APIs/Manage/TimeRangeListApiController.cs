using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MyHealthPlus.DAL.ViewModels.Manage;
using MyHealthPlus.Services.Manage.TimeRangeListService;

namespace MyHealthPlus.Controllers.APIs.Manage
{
    [RoutePrefix("api/v1/timerange")]
    public class TimeRangeListApiController : BaseApiController
    {
        private readonly ITimeRangeListService _timeRangeListService;

        public TimeRangeListApiController(ITimeRangeListService timeRangeListService)
        {
            _timeRangeListService = timeRangeListService;
        }

        // GET api/v1/timerange/drop
        [HttpPost]
        [Route("drop")]
        public IHttpActionResult GetDrop(DdParamsTimeRangeListVm data)
        {
            try
            {
                var dataList = _timeRangeListService.GetDrop(data.CheckDate);
                return Ok(dataList);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Api: CheckUpTypes | Function: GetDd");
                throw ex;
            }
        }


        // GET api/v1/roles/drop
        [HttpGet]
        [Route("drop2")]
        public IHttpActionResult GetDrop2()
        {
            try
            {
                var dataList = _timeRangeListService.GetDrop2();
                return Ok(dataList);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Api: CheckUpTypes | Function: GetDrop2");
                throw ex;
            }
        }

    }
}