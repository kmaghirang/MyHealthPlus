using System.Collections.Generic;
using MyHealthPlus.DAL.ViewModels.Manage;

namespace MyHealthPlus.Services.Manage.RolesService
{
    public interface IRolesService
    {
        IEnumerable<DdRolesVm> GetDrop();
        IEnumerable<TblRolesVm> GetTbl();
        ByIdRolesVm GetById(int id);
        bool Save(SaveRolesVm data);
        bool Update(SaveRolesVm data);
        int ToggleOff(int id, string samAccount);
        int ToggleOn(int id, string samAccount);
    }
}