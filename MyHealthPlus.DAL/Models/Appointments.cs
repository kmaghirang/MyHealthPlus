namespace MyHealthPlus.DAL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Appointments
    {
        [Key]
        public int AppointmentId { get; set; }

        public int UserId { get; set; }

        public string UserNotes { get; set; }

        public int? CheckUpTypeId { get; set; }

        public DateTime AppointmentDate { get; set; }

        public int? TimeRangeId { get; set; }

        public string DoctorNotes { get; set; }

        public int? StatusId { get; set; }

        [Required]
        [StringLength(50)]
        public string CreatedBy { get; set; }

        public DateTime DateCreated { get; set; }

        [StringLength(50)]
        public string UpdatedBy { get; set; }

        public DateTime DateUpdated { get; set; }

        public bool IsActive { get; set; }

        public virtual CheckUpTypes CheckUpTypes { get; set; }

        public virtual Status Status { get; set; }

        public virtual TimeRangeList TimeRangeList { get; set; }

        public virtual Users Users { get; set; }
    }
}
