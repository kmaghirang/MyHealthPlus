using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MyHealthPlus.DAL.ViewModels.Main;
using MyHealthPlus.Services.Main.AppointmentsService;

namespace MyHealthPlus.Controllers.APIs.Main
{
    [RoutePrefix("api/v1/appointments")]
    public class AppointmentsApiController : BaseApiController
    {
        private readonly IAppointmentsService _appointmentsService;

        public AppointmentsApiController(IAppointmentsService appointmentsService)
        {
            _appointmentsService = appointmentsService;
        }

        ///////////////////////////////////////////////////////////////////////////
        // 
        //      User


        // GET api/v1/appointments/myappointments/{id}
        [HttpGet]
        [Route("myappointments/{id}")]
        public IHttpActionResult GetMyAppointments(int id)
        {
            try
            {
                var dataList = _appointmentsService.GetMyAppointments(id);
                return Ok(dataList);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Api: Appointments | Function: GetMyAppointments");
                throw ex;
            }
        }

        // GET api/v1/appointments/save
        [HttpPost]
        [Route("save")]
        public IHttpActionResult Save(SaveAppointmentsVm data)
        {
            try
            {
                if (data.AppointmentId == 0)
                {
                    var dataList = _appointmentsService.AddNew(data);
                    return Ok(dataList);
                }
                else
                {
                    var dataList = _appointmentsService.Update(data);
                    return Ok(dataList);
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Api: Appointments | Function: Save");
                throw ex;
            }
        }


        // GET api/v1/appointments/cancel/{id}
        [HttpGet]
        [Route("cancel/{id}")]
        public IHttpActionResult CancelAppointment(int id)
        {
            try
            {
                var dataList = _appointmentsService.CancelAppointment(id);
                return Ok(dataList);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Api: Appointments | Function: CancelAppointment");
                throw ex;
            }
        }


        ///////////////////////////////////////////////////////////////////////////

        ///////////////////////////////////////////////////////////////////////////
        // 
        //      Doctor/Staff

        // GET api/v1/appointments/myschedule
        [HttpPost]
        [Route("myschedule")]
        public IHttpActionResult GetMySchedule(DateParamsAppointmentsVm data)
        {
            try
            {
                var dataList = _appointmentsService.GetMySchedule(data.Date);
                return Ok(dataList);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Api: Appointments | Function: GetMySchedule");
                throw ex;
            }
        }

        // GET api/v1/appointments/getappointmentbyid/{id}
        [HttpGet]
        [Route("getappointmentbyid/{id}")]
        public IHttpActionResult GetAppointmentById(int id)
        {
            try
            {
                var dataList = _appointmentsService.GetAppointmentById(id);
                return Ok(dataList);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Api: Appointments | Function: GetAppointmentById");
                throw ex;
            }
        }


        ///////////////////////////////////////////////////////////////////////////

        // GET api/v1/appointments/today
        [HttpGet]
        [Route("today")]
        public IHttpActionResult GetDateToday()
        {
            try
            {
                var dataList = _appointmentsService.GetDateToday();
                return Ok(dataList);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Api: Appointments | Function: GetMyAppointments");
                throw ex;
            }
        }

    }
}