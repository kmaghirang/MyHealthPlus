using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyHealthPlus.DAL.UnitOfWork;
using MyHealthPlus.DAL.ViewModels.Manage;

namespace MyHealthPlus.Services.Manage.TimeRangeListService
{
    public class TimeRangeListService : ITimeRangeListService
    {
        private readonly IMyHealthPlusUnitOfWork _unitOfWork;

        public TimeRangeListService(IMyHealthPlusUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public IEnumerable<DdTimeRangeListVm> GetDrop(string date)
        {
            try
            {
                var dateSp = Convert.ToDateTime(date).ToString("yyyy-MM-dd");
                return  _unitOfWork.TimeRangeListRepository.GetBySql<DdTimeRangeListVm>($"EXEC [dbo].[usp_GetAvailableTimeRange] @date='{dateSp}'").ToList()
                    .Select(x => new DdTimeRangeListVm()
                    {
                        TimeRangeId = x.TimeRangeId,
                        StartRange = x.StartRange,
                        EndRange = x.EndRange
                    }).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<DdTimeRangeListVm> GetDrop2()
        {
            try
            {
                return _unitOfWork.TimeRangeListRepository.GetAll()
                    .Where(x => x.IsActive == true)
                    .OrderBy(x => x.StartRange)
                    .Select(x => new DdTimeRangeListVm()
                    {
                        TimeRangeId = x.TimeRangeId,
                        StartRange = x.StartRange,
                        EndRange = x.EndRange
                    });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
