using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyHealthPlus.DAL.UnitOfWork;
using MyHealthPlus.DAL.ViewModels.Manage;
using MyHealthPlus.Utilities.Helper;

namespace MyHealthPlus.Services.Manage.UsersService
{
    public class UsersService : IUsersService
    {
        private readonly IMyHealthPlusUnitOfWork _unitOfWork;

        public UsersService(IMyHealthPlusUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<TblUsersVm> GetTbl()
        {
            try
            {
                return _unitOfWork.UsersRepository.GetAllAsQueryable()
                    .Where(x => x.IsActive)
                    .Select(x => new TblUsersVm()
                    {
                        UserId = x.UserId,
                        UserName = x.UserName,
                        LastName = x.LastName,
                        FirstName = x.FirstName,
                        MiddleName = x.MiddleName,
                        Role = x.Roles.Name
                    }).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public GetByIdUsersVm GetById(int id)
        {
            try
            {
                var data = _unitOfWork.UsersRepository.GetById(id);

                return data == null
                    ? null
                    : new GetByIdUsersVm()
                    {
                        UserId = data.UserId,
                        UserName = data.UserName,
                        LastName = data.LastName,
                        FirstName = data.FirstName,
                        MiddleName = data.MiddleName,
                        RoleId = data.RoleId
                    };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool UpdateUserRole(SaveUsersVm data)
        {
            try
            {
                var dataUpdate = _unitOfWork.UsersRepository.GetById(data.UserId);

                if (dataUpdate != null)
                {
                    dataUpdate.RoleId = data.RoleId;
                    dataUpdate.UpdatedBy = data.UpdatedBy;
                    dataUpdate.DateUpdated = TimeZoneConverterHelper.TimeZone();

                    _unitOfWork.UsersRepository.Update(dataUpdate);
                }

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
