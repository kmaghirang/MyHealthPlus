using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyHealthPlus.DAL.Interfaces.Custom;

namespace MyHealthPlus.DAL.UnitOfWork
{
    public interface IMyHealthPlusUnitOfWork : IUnitOfWork
    {
        IAppointmentsRepository AppointmentsRepository { get; }
        ICheckUpTypesRepository CheckUpTypesRepository { get; }
        IErrorLogsRepository ErrorLogsRepository { get; }
        IRolesRepository RolesRepository { get; }
        IStatusRepository StatusRepository { get; }
        ITimeRangeListRepository TimeRangeListRepository { get; }
        IUsersRepository UsersRepository { get; }
    }
}
