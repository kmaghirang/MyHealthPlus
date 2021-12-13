using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyHealthPlus.DAL.Interfaces.Custom;
using MyHealthPlus.DAL.Models;
using MyHealthPlus.DAL.Repositories.Custom;

namespace MyHealthPlus.DAL.UnitOfWork
{
    public class MyHealthPlusUnitOfWork : UnitOfWork, IMyHealthPlusUnitOfWork
    {
        private readonly MyHealthPlusDbContext _context;

        private IAppointmentsRepository _appointmentsRepository;
        private ICheckUpTypesRepository _checkUpTypesRepository;
        private IErrorLogsRepository _errorLogsRepository;
        private IRolesRepository _rolesRepository;
        private IStatusRepository _statusRepository;
        private ITimeRangeListRepository _timeRangeListRepository;
        private IUsersRepository _usersRepository;

        public MyHealthPlusUnitOfWork(MyHealthPlusDbContext context) : base(context)
        {
            _context = context;
        }


        public IUsersRepository UsersRepository
        {
            get
            {
                return _usersRepository = _usersRepository ?? new UsersRepository(_context);
            }
        }

        public ITimeRangeListRepository TimeRangeListRepository
        {
            get
            {
                return _timeRangeListRepository = _timeRangeListRepository ?? new TimeRangeListRepository(_context);
            }
        }

        public IStatusRepository StatusRepository
        {
            get
            {
                return _statusRepository = _statusRepository ?? new StatusRepository(_context);
            }
        }

        public IRolesRepository RolesRepository
        {
            get
            {
                return _rolesRepository = _rolesRepository ?? new RolesRepository(_context);
            }
        }

        public IErrorLogsRepository ErrorLogsRepository
        {
            get
            {
                return _errorLogsRepository = _errorLogsRepository ?? new ErrorLogsRepository(_context);
            }
        }

        public ICheckUpTypesRepository CheckUpTypesRepository
        {
            get
            {
                return _checkUpTypesRepository = _checkUpTypesRepository ?? new CheckUpTypesRepository(_context);
            }
        }

        public IAppointmentsRepository AppointmentsRepository
        {
            get
            {
                return _appointmentsRepository = _appointmentsRepository ?? new AppointmentsRepository(_context);
            }
        }

    }
}
