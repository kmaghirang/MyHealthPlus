namespace MyHealthPlus.DAL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ErrorLogs
    {
        [Key]
        public int LogId { get; set; }

        [Required]
        public string Level { get; set; }

        [Required]
        public string CallSite { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        public string Message { get; set; }

        [Required]
        public string StackTrace { get; set; }

        [Required]
        public string InnerException { get; set; }

        [Required]
        public string AdditionalInfo { get; set; }

        public DateTime LoggedOnDate { get; set; }
    }
}
