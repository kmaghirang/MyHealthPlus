using System.Collections.Generic;
using MyHealthPlus.DAL.ViewModels.Manage;

namespace MyHealthPlus.Services.Manage.StatusService
{
    public interface IStatusService
    {
        IEnumerable<DdStatusVm> GetDrop();
        IEnumerable<TblStatusVm> GetTbl();
        ByIdStatusVm GetById(int id);
        bool Save(SaveStatusVm data);
        bool Update(SaveStatusVm data);
        int ToggleOff(int id, string samAccount);
        int ToggleOn(int id, string samAccount);
    }
}