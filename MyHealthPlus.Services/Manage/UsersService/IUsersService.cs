using System.Collections.Generic;
using MyHealthPlus.DAL.ViewModels.Manage;

namespace MyHealthPlus.Services.Manage.UsersService
{
    public interface IUsersService
    {
        IEnumerable<TblUsersVm> GetTbl();
        GetByIdUsersVm GetById(int id);
        bool UpdateUserRole(SaveUsersVm data);
    }
}