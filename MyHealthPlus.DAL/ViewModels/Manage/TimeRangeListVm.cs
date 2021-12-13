using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHealthPlus.DAL.ViewModels.Manage
{
    public class TimeRangeListVm
    {
    }
    public class DdParamsTimeRangeListVm
    {
        public string CheckDate { get; set; }
    }

    public class DdTimeRangeListVm
    {
        public int TimeRangeId { get; set; }
        public TimeSpan? StartRange { get; set; }
        public TimeSpan? EndRange { get; set; }
    }

    public class TblTimeRangeListVm
    {
        public int TimeRangeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CreatedBy { get; set; }
        public string DateCreated { get; set; }
        public string UpdatedBy { get; set; }
        public string DateUpdated { get; set; }
        public bool? IsActive { get; set; }
    }

    public class ByIdTimeRangeListVm
    {
        public int TimeRangeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class SaveTimeRangeListVm
    {
        public int TimeRangeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime DateUpdated { get; set; }
        public bool? IsActive { get; set; }
    }
}
