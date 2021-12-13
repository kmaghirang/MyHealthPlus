namespace MyHealthPlus.DAL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Manage.TimeRangeList")]
    public partial class TimeRangeList
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TimeRangeList()
        {
            Appointments = new HashSet<Appointments>();
        }

        [Key]
        public int TimeRangeId { get; set; }

        [Required]
        [StringLength(2)]
        public string Period { get; set; }

        public TimeSpan? StartRange { get; set; }

        public TimeSpan? EndRange { get; set; }

        public string Description { get; set; }

        [Required]
        [StringLength(50)]
        public string CreatedBy { get; set; }

        public DateTime DateCreated { get; set; }

        [StringLength(50)]
        public string UpdatedBy { get; set; }

        public DateTime DateUpdated { get; set; }

        public bool IsActive { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Appointments> Appointments { get; set; }
    }
}
