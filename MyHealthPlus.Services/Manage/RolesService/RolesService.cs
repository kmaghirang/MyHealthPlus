using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyHealthPlus.DAL.Models;
using MyHealthPlus.DAL.UnitOfWork;
using MyHealthPlus.DAL.ViewModels.Manage;
using MyHealthPlus.Utilities.Helper;

namespace MyHealthPlus.Services.Manage.RolesService
{
    public class RolesService : IRolesService
    {
        private readonly IMyHealthPlusUnitOfWork _unitOfWork;

        public RolesService(IMyHealthPlusUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IEnumerable<DdRolesVm> GetDrop()
        {
            try
            {
                return _unitOfWork.RolesRepository.GetAll()
                    .Where(x => x.IsActive == true)
                    .OrderBy(x => x.Name)
                    .Select(x => new DdRolesVm()
                    {
                        RoleId = x.RoleId,
                        Name = x.Name
                    });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // GET data for table
        public IEnumerable<TblRolesVm> GetTbl()
        {
            try
            {
                return _unitOfWork.RolesRepository.GetAll()
                    .Where(x => x.IsActive)
                    .Select(x => new TblRolesVm()
                    {
                        RoleId = x.RoleId,
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
        public ByIdRolesVm GetById(int id)
        {
            try
            {
                var data = _unitOfWork.RolesRepository.GetById(id);

                return data == null
                    ? null
                    : new ByIdRolesVm()
                    {
                        RoleId = data.RoleId,
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
        public bool Save(SaveRolesVm data)
        {
            try
            {
                var validate = _unitOfWork.RolesRepository.GetAllAsQueryable()
                    .Count(x => x.Name == data.Name && x.IsActive);

                if (validate > 0)
                {
                    return false;
                }
                else
                {
                    var newdata = _unitOfWork.RolesRepository.Add(new Roles()
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
        public bool Update(SaveRolesVm data)
        {
            try
            {
                var validate = _unitOfWork.RolesRepository.GetAllAsQueryable().Count(x =>
                    x.Name == data.Name && x.RoleId != data.RoleId && x.IsActive);

                if (validate > 0)
                {
                    return false;
                }
                else
                {
                    var dataUpdate = _unitOfWork.RolesRepository.GetById(data.RoleId);

                    if (dataUpdate != null)
                    {
                        dataUpdate.Name = data.Name;
                        dataUpdate.Description = data.Description;
                        dataUpdate.UpdatedBy = data.UpdatedBy;
                        dataUpdate.DateUpdated = TimeZoneConverterHelper.TimeZone();

                        _unitOfWork.RolesRepository.Update(dataUpdate);
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
                var dataUpdate = _unitOfWork.RolesRepository.GetById(id);

                if (dataUpdate != null)
                {
                    dataUpdate.IsActive = false;
                    dataUpdate.UpdatedBy = samAccount;
                    dataUpdate.DateUpdated = TimeZoneConverterHelper.TimeZone();
                    _unitOfWork.RolesRepository.Update(dataUpdate);
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
                var dataUpdate = _unitOfWork.RolesRepository.GetById(id);

                if (dataUpdate != null)
                {
                    dataUpdate.IsActive = true;
                    dataUpdate.UpdatedBy = samAccount;
                    dataUpdate.DateUpdated = TimeZoneConverterHelper.TimeZone();
                    _unitOfWork.RolesRepository.Update(dataUpdate);
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
