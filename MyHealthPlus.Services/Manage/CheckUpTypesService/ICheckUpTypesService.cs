using System.Collections.Generic;
using MyHealthPlus.DAL.ViewModels.Manage;

namespace MyHealthPlus.Services.Manage.CheckUpTypesService
{
    public interface ICheckUpTypesService
    {
        IEnumerable<DdCheckUpTypesVm> GetDrop();
        IEnumerable<TblCheckUpTypesVm> GetTbl();
        ByIdCheckUpTypesVm GetById(int id);
        bool Save(SaveCheckUpTypesVm data);
        bool Update(SaveCheckUpTypesVm data);
        int ToggleOff(int id, string samAccount);
        int ToggleOn(int id, string samAccount);
    }
}