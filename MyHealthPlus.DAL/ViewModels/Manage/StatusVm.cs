using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHealthPlus.DAL.ViewModels.Manage
{
    public class StatusVm
    {
    }

    public class DdStatusVm
    {
        public int StatusId { get; set; }
        public string Name { get; set; }
    }

    public class TblStatusVm
    {
        public int StatusId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CreatedBy { get; set; }
        public string DateCreated { get; set; }
        public string UpdatedBy { get; set; }
        public string DateUpdated { get; set; }
        public bool? IsActive { get; set; }
    }

    public class ByIdStatusVm
    {
        public int StatusId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class SaveStatusVm
    {
        public int StatusId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime DateUpdated { get; set; }
        public bool? IsActive { get; set; }
    }
}
