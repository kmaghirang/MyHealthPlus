using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyHealthPlus.DAL.ViewModels.Login;

namespace MyHealthPlus.Services.Login.RegistrationService
{
    public interface IRegistrationService
    {
        bool RegisterUser(RegistrationVm data);
        bool CheckUsername(string username);
    }
}
