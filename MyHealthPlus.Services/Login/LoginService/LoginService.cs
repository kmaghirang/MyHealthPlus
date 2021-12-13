using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyHealthPlus.DAL.UnitOfWork;
using MyHealthPlus.DAL.ViewModels.Login;
using MyHealthPlus.Utilities.Handler;

namespace MyHealthPlus.Services.Login.LoginService
{
    public class LoginService : ILoginService
    {
        private readonly IMyHealthPlusUnitOfWork _unitOfWork;

        public LoginService(IMyHealthPlusUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public bool? LoginValidation(ParamsLoginVm data)
        {
            try
            {
                var user = _unitOfWork.UsersRepository.GetAllAsQueryable().FirstOrDefault(x => x.UserName.Trim() == data.UserName.Trim());

                if (user == null)
                {
                    return null;
                }
                else
                {
                    var password = new SecurityHandler().Decrypt(user.Password);
                    if (data.Password == password)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public UserSession GetSession(ParamsLoginVm data)
        {
            try
            {
                var pass = new SecurityHandler().Encrypt(data.Password);
                var user = _unitOfWork.UsersRepository.GetAllAsQueryable()
                    .FirstOrDefault(x => x.UserName.Trim() == data.UserName.Trim()
                    && x.Password == pass
                    );

                if (user != null)
                    return new UserSession()
                    {
                        UserId = user.UserId,
                        RoleId = user.RoleId,
                        UserName = user.UserName,
                        LastName = user.LastName,
                        FirstName = user.FirstName,
                        MiddleName = user.MiddleName
                    };
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
