using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHealthPlus.DAL.ViewModels.Manage
{
    public class RolesVm
    {
    }

    public class DdRolesVm
    {
        public int RoleId { get; set; }
        public string Name { get; set; }
    }

    public class TblRolesVm
    {
        public int RoleId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CreatedBy { get; set; }
        public string DateCreated { get; set; }
        public string UpdatedBy { get; set; }
        public string DateUpdated { get; set; }
        public bool? IsActive { get; set; }
    }

    public class ByIdRolesVm
    {
        public int RoleId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class SaveRolesVm
    {
        public int RoleId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime DateUpdated { get; set; }
        public bool? IsActive { get; set; }
    }
}
