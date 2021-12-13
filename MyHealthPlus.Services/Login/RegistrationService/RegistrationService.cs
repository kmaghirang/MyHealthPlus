using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyHealthPlus.DAL.Models;
using MyHealthPlus.DAL.UnitOfWork;
using MyHealthPlus.DAL.ViewModels.Login;
using MyHealthPlus.Utilities.Handler;
using MyHealthPlus.Utilities.Helper;

namespace MyHealthPlus.Services.Login.RegistrationService
{
    public class RegistrationService : IRegistrationService
    {
        private readonly IMyHealthPlusUnitOfWork _unitOfWork;

        public RegistrationService(IMyHealthPlusUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public bool RegisterUser(RegistrationVm data)
        {
            try
            {
                _unitOfWork.UsersRepository.Add(new Users()
                {
                    UserName = data.UserName,
                    Password = new SecurityHandler().Encrypt(data.Password),
                    LastName = data.LastName,
                    FirstName = data.FirstName,
                    MiddleName = data.MiddleName,
                    RoleId = 4,
                    CreatedBy = "User",
                    DateCreated = TimeZoneConverterHelper.TimeZone(),
                    UpdatedBy = "",
                    DateUpdated = TimeZoneConverterHelper.TimeZone(),
                    IsActive = true
                });

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool CheckUsername(string username)
        {
            try
            {
                int count = _unitOfWork.UsersRepository.GetAllAsQueryable().Count(x => x.UserName == username && x.IsActive);

                if (count > 0)
                {
                    return false;
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
