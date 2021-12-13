using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHealthPlus.DAL.ViewModels.Manage
{
    public class UsersVm
    {
    }

    public class TblUsersVm
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string Role { get; set; }
    }

    public class GetByIdUsersVm
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public int? RoleId { get; set; }
    }

    public class SaveUsersVm
    {
        public int UserId { get; set; }
        public int? RoleId { get; set; }
        public string UpdatedBy { get; set; }
    }
}
