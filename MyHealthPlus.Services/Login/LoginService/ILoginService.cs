using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyHealthPlus.DAL.ViewModels.Login;

namespace MyHealthPlus.Services.Login.LoginService
{
    public interface ILoginService
    {
        bool? LoginValidation(ParamsLoginVm data);
        UserSession GetSession(ParamsLoginVm data);
    }
}
