using System.Collections.Generic;
using MyHealthPlus.DAL.ViewModels.Manage;

namespace MyHealthPlus.Services.Manage.TimeRangeListService
{
    public interface ITimeRangeListService
    {
        IEnumerable<DdTimeRangeListVm> GetDrop(string date);
        IEnumerable<DdTimeRangeListVm> GetDrop2();
    }
}