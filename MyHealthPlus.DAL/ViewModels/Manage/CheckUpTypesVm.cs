using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHealthPlus.DAL.ViewModels.Manage
{
    public class CheckUpTypesVm
    {
    }

    public class DdCheckUpTypesVm
    {
        public int CheckUpTypeId { get; set; }
        public string Name { get; set; }
    }

    public class TblCheckUpTypesVm
    {
        public int CheckUpTypeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CreatedBy { get; set; }
        public string DateCreated { get; set; }
        public string UpdatedBy { get; set; }
        public string DateUpdated { get; set; }
        public bool? IsActive { get; set; }
    }

    public class ByIdCheckUpTypesVm
    {
        public int CheckUpTypeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class SaveCheckUpTypesVm
    {
        public int CheckUpTypeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime DateUpdated { get; set; }
        public bool? IsActive { get; set; }
    }
}
