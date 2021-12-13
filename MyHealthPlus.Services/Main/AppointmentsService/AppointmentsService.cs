using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyHealthPlus.DAL.Models;
using MyHealthPlus.DAL.UnitOfWork;
using MyHealthPlus.DAL.ViewModels.Main;
using MyHealthPlus.Utilities.Helper;

namespace MyHealthPlus.Services.Main.AppointmentsService
{
    public class AppointmentsService : IAppointmentsService
    {
        private readonly IMyHealthPlusUnitOfWork _unitOfWork;

        public AppointmentsService(IMyHealthPlusUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public DateTime GetDateToday()
        {
            return DateTime.Now;
        }

        public IEnumerable<TblAppointmentsVm> GetMyAppointments(int id)
        {
            try
            {
                return _unitOfWork.AppointmentsRepository.GetAllAsQueryable().ToList()
                    .Where(x => x.UserId == id)
                    .Select(x => new TblAppointmentsVm()
                    {
                        AppointmentId = x.AppointmentId,
                        FullName = x.Users.LastName + ", " + x.Users.FirstName + " " + x.Users.MiddleName,
                        CheckUpType = x.CheckUpTypes.Name,
                        AppointmentDate = x.AppointmentDate.ToString("MMMM dd, yyyy"),
                        StartRange = x.TimeRangeList.StartRange,
                        EndRange = x.TimeRangeList.EndRange,
                        Status = x.Status.Name,
                        StatusId = x.StatusId
                    }).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool AddNew(SaveAppointmentsVm data)
        {
            try
            {
                _unitOfWork.AppointmentsRepository.Add(new Appointments()
                {
                    UserId = data.UserId,
                    UserNotes = data.UserNotes,
                    CheckUpTypeId = data.CheckUpTypeId,
                    AppointmentDate = Convert.ToDateTime(data.AppointmentDate),
                    TimeRangeId = data.TimeRangeId,
                    DoctorNotes = "",
                    StatusId = 1,
                    CreatedBy = "UserId: "+ data.UserId,
                    DateCreated = TimeZoneConverterHelper.TimeZone(),
                    UpdatedBy = "",
                    DateUpdated = TimeZoneConverterHelper.TimeZone(),
                    IsActive = true
                });
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<TblAppointmentsVm> GetMySchedule(string date)
        {
            try
            {
                var dateSp = Convert.ToDateTime(date).ToString("yyyy-MM-dd");
                return _unitOfWork.TimeRangeListRepository.GetBySql<TblAppointmentsVm>($"EXEC [dbo].[usp_GetMySchedule] @date='{dateSp}'").ToList()
                    .Select(x => new TblAppointmentsVm()
                    {
                        AppointmentId = x.AppointmentId,
                        FullName = x.FullName,
                        CheckUpType = x.CheckUpType,
                        AppointmentDate = x.AppointmentDateDateFrmt.ToString("MMMM dd, yyyy"),
                        StartRange = x.StartRange,
                        EndRange = x.EndRange,
                        Status = x.Status,
                        StatusId = x.StatusId
                    }).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public GetByIdAppointmentsVm GetAppointmentById(int id)
        {
            try
            {
                var data = _unitOfWork.AppointmentsRepository.GetById(id);


                return data == null
                    ? null
                    : new GetByIdAppointmentsVm()
                    {
                        AppointmentId = data.AppointmentId,
                        FullName = data.Users.LastName + ", " + data.Users.FirstName + " " + data.Users.MiddleName,
                        UserNotes = data.UserNotes,
                        DoctorNotes = data.DoctorNotes,
                        CheckUpTypeId = data.CheckUpTypeId,
                        AppointmentDate = data.AppointmentDate,
                        TimeRangeId = data.TimeRangeId,
                        StatusId = data.StatusId
                    };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Update(SaveAppointmentsVm data)
        {
            try
            {
                var dataUpdate = _unitOfWork.AppointmentsRepository.GetById(data.AppointmentId);

                if (dataUpdate != null)
                {
                    dataUpdate.StatusId = data.StatusId;
                    dataUpdate.DoctorNotes = data.DoctorNotes;
                    dataUpdate.UpdatedBy = "Doctor";
                    dataUpdate.DateUpdated = TimeZoneConverterHelper.TimeZone();

                    _unitOfWork.AppointmentsRepository.Update(dataUpdate);
                }

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool CancelAppointment(int id)
        {
            try
            {
                var dataUpdate = _unitOfWork.AppointmentsRepository.GetById(id);
                if (dataUpdate != null)
                {
                    dataUpdate.StatusId = 4;
                    dataUpdate.IsActive = false;
                    dataUpdate.UpdatedBy = "User";
                    dataUpdate.DateUpdated = TimeZoneConverterHelper.TimeZone();

                    _unitOfWork.AppointmentsRepository.Update(dataUpdate);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
