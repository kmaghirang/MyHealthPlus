using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyHealthPlus.DAL.Models;
using MyHealthPlus.DAL.UnitOfWork;
using MyHealthPlus.DAL.ViewModels.Manage;
using MyHealthPlus.Utilities.Helper;

namespace MyHealthPlus.Services.Manage.CheckUpTypesService
{
    public class CheckUpTypesService : ICheckUpTypesService
    {
        private readonly IMyHealthPlusUnitOfWork _unitOfWork;

        public CheckUpTypesService(IMyHealthPlusUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public IEnumerable<DdCheckUpTypesVm> GetDrop()
        {
            try
            {
                return _unitOfWork.CheckUpTypesRepository.GetAll()
                    .Where(x => x.IsActive == true)
                    .OrderBy(x => x.Name)
                    .Select(x => new DdCheckUpTypesVm()
                    {
                        CheckUpTypeId = x.CheckUpTypeId,
                        Name = x.Name
                    });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // GET data for table
        public IEnumerable<TblCheckUpTypesVm> GetTbl()
        {
            try
            {
                return _unitOfWork.CheckUpTypesRepository.GetAll()
                    .Where(x => x.IsActive)
                    .Select(x => new TblCheckUpTypesVm()
                    {
                        CheckUpTypeId = x.CheckUpTypeId,
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
        public ByIdCheckUpTypesVm GetById(int id)
        {
            try
            {
                var data = _unitOfWork.CheckUpTypesRepository.GetById(id);

                return data == null
                    ? null
                    : new ByIdCheckUpTypesVm()
                    {
                        CheckUpTypeId = data.CheckUpTypeId,
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
        public bool Save(SaveCheckUpTypesVm data)
        {
            try
            {
                var validate = _unitOfWork.CheckUpTypesRepository.GetAllAsQueryable()
                    .Count(x => x.Name == data.Name && x.IsActive);

                if (validate > 0)
                {
                    return false;
                }
                else
                {
                    var newdata = _unitOfWork.CheckUpTypesRepository.Add(new CheckUpTypes()
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
        public bool Update(SaveCheckUpTypesVm data)
        {
            try
            {
                var validate = _unitOfWork.CheckUpTypesRepository.GetAllAsQueryable().Count(x =>
                    x.Name == data.Name && x.CheckUpTypeId != data.CheckUpTypeId && x.IsActive);

                if (validate > 0)
                {
                    return false;
                }
                else
                {
                    var dataUpdate = _unitOfWork.CheckUpTypesRepository.GetById(data.CheckUpTypeId);

                    if (dataUpdate != null)
                    {
                        dataUpdate.Name = data.Name;
                        dataUpdate.Description = data.Description;
                        dataUpdate.UpdatedBy = data.UpdatedBy;
                        dataUpdate.DateUpdated = TimeZoneConverterHelper.TimeZone();

                        _unitOfWork.CheckUpTypesRepository.Update(dataUpdate);
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
                var dataUpdate = _unitOfWork.CheckUpTypesRepository.GetById(id);

                if (dataUpdate != null)
                {
                    dataUpdate.IsActive = false;
                    dataUpdate.UpdatedBy = samAccount;
                    dataUpdate.DateUpdated = TimeZoneConverterHelper.TimeZone();
                    _unitOfWork.CheckUpTypesRepository.Update(dataUpdate);
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
                var dataUpdate = _unitOfWork.CheckUpTypesRepository.GetById(id);

                if (dataUpdate != null)
                {
                    dataUpdate.IsActive = true;
                    dataUpdate.UpdatedBy = samAccount;
                    dataUpdate.DateUpdated = TimeZoneConverterHelper.TimeZone();
                    _unitOfWork.CheckUpTypesRepository.Update(dataUpdate);
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
