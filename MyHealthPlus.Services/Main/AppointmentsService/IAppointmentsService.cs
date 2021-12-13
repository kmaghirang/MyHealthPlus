using System;
using System.Collections.Generic;
using MyHealthPlus.DAL.ViewModels.Main;

namespace MyHealthPlus.Services.Main.AppointmentsService
{
    public interface IAppointmentsService
    {
        DateTime GetDateToday();
        IEnumerable<TblAppointmentsVm> GetMyAppointments(int id);
        bool AddNew(SaveAppointmentsVm data);
        IEnumerable<TblAppointmentsVm> GetMySchedule(string date);
        GetByIdAppointmentsVm GetAppointmentById(int id);
        bool Update(SaveAppointmentsVm data);
        bool CancelAppointment(int id);
    }
}