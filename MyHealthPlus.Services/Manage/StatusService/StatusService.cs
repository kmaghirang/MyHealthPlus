using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyHealthPlus.DAL.Models;
using MyHealthPlus.DAL.UnitOfWork;
using MyHealthPlus.DAL.ViewModels.Manage;
using MyHealthPlus.Utilities.Helper;

namespace MyHealthPlus.Services.Manage.StatusService
{
    public class StatusService : IStatusService
    {
        private readonly IMyHealthPlusUnitOfWork _unitOfWork;

        public StatusService(IMyHealthPlusUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<DdStatusVm> GetDrop()
        {
            try
            {
                return _unitOfWork.StatusRepository.GetAll()
                    .Where(x => x.IsActive == true)
                    .OrderBy(x => x.Name)
                    .Select(x => new DdStatusVm()
                    {
                        StatusId = x.StatusId,
                        Name = x.Name
                    });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // GET data for table
        public IEnumerable<TblStatusVm> GetTbl()
        {
            try
            {
                return _unitOfWork.StatusRepository.GetAll()
                    .Select(x => new TblStatusVm()
                    {
                        StatusId = x.StatusId,
                        Name = x.Name,
                        Description = x.Description,
                        CreatedBy = x.CreatedBy,
                        DateCreated = Convert.ToDateTime(x.DateCreated).ToString("MMMM dd, yyyy"),
                        UpdatedBy = x.UpdatedBy,
                        DateUpdated = Convert.ToDateTime(x.DateUpdated).ToString("MMMM dd, yyyy"),
                        IsActive = x.IsActive

                    });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // Get by id for updating
        public ByIdStatusVm GetById(int id)
        {
            try
            {
                var data = _unitOfWork.StatusRepository.GetById(id);

                return data == null
                    ? null
                    : new ByIdStatusVm()
                    {
                        StatusId = data.StatusId,
                        Name = data.Name,
                        Description = data.Description
                    };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // Save data
        public bool Save(SaveStatusVm data)
        {
            try
            {
                var validate = _unitOfWork.StatusRepository.GetAllAsQueryable()
                    .Count(x => x.Name == data.Name);

                if (validate > 0)
                {
                    return false;
                }
                else
                {
                    var newdata = _unitOfWork.StatusRepository.Add(new Status()
                    {
                        Name = data.Name,
                        Description = data.Description,
                        CreatedBy = data.CreatedBy,
                        DateCreated = TimeZoneConverterHelper.TimeZone(),
                        UpdatedBy = data.UpdatedBy,
                        DateUpdated = TimeZoneConverterHelper.TimeZone(),
                        IsActive = true
                    });

                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Update data
        public bool Update(SaveStatusVm data)
        {
            try
            {
                var validate = _unitOfWork.StatusRepository.GetAllAsQueryable().Count(x =>
                    x.Name == data.Name && x.StatusId != data.StatusId);

                if (validate > 0)
                {
                    return false;
                }
                else
                {
                    var dataUpdate = _unitOfWork.StatusRepository.GetById(data.StatusId);

                    if (dataUpdate != null)
                    {
                        dataUpdate.Name = data.Name;
                        dataUpdate.Description = data.Description;
                        dataUpdate.UpdatedBy = data.UpdatedBy;
                        dataUpdate.DateUpdated = TimeZoneConverterHelper.TimeZone();

                        _unitOfWork.StatusRepository.Update(dataUpdate);
                    }

                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // Remove
        public int ToggleOff(int id, string samAccount)
        {
            try
            {
                var dataUpdate = _unitOfWork.StatusRepository.GetById(id);

                if (dataUpdate != null)
                {
                    dataUpdate.IsActive = false;
                    dataUpdate.UpdatedBy = samAccount;
                    dataUpdate.DateUpdated = TimeZoneConverterHelper.TimeZone();
                    _unitOfWork.StatusRepository.Update(dataUpdate);
                }

                return 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // Include data again
        public int ToggleOn(int id, string samAccount)
        {
            try
            {
                var dataUpdate = _unitOfWork.StatusRepository.GetById(id);

                if (dataUpdate != null)
                {
                    dataUpdate.IsActive = true;
                    dataUpdate.UpdatedBy = samAccount;
                    dataUpdate.DateUpdated = TimeZoneConverterHelper.TimeZone();
                    _unitOfWork.StatusRepository.Update(dataUpdate);
                }

                return 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
