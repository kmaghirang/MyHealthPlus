using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHealthPlus.DAL.ViewModels.Login
{
    public class LoginVm
    {
    }

    public class ParamsLoginVm
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public class UserSession
    {
        public int UserId { get; set; }
        public int? RoleId { get; set; }
        public string UserName { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
    }
}
