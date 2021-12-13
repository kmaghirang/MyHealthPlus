using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHealthPlus.DAL.ViewModels.Main
{
    public class AppointmentsVm
    {
    }

    public class DateParamsAppointmentsVm
    {
        public string Date { get; set; }
    }

    public class TblAppointmentsVm
    {
        public int AppointmentId { get; set; }
        public string FullName { get; set; }
        public string CheckUpType { get; set; }
        public string AppointmentDate { get; set; }
        public DateTime AppointmentDateDateFrmt { get; set; }
        public TimeSpan? StartRange { get; set; }
        public TimeSpan? EndRange { get; set; }
        public string Status { get; set; }
        public int? StatusId { get; set; }
    }

    public class GetByIdAppointmentsVm
    {
        public int AppointmentId { get; set; }
        public string FullName { get; set; }
        public string UserNotes { get; set; }
        public string DoctorNotes { get; set; }
        public int? CheckUpTypeId { get; set; }
        public DateTime AppointmentDate { get; set; }
        public int? TimeRangeId { get; set; }
        public int? StatusId { get; set; }
    }


    public class SaveAppointmentsVm
    {
        public int AppointmentId { get; set; }
        public string AppointmentDate { get; set; }
        public int UserId { get; set; }
        public int CheckUpTypeId { get; set; }
        public int TimeRangeId { get; set; }
        public int StatusId { get; set; }
        public string UserNotes { get; set; }
        public string DoctorNotes { get; set; }
    }
}
