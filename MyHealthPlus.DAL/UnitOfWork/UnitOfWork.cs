using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyHealthPlus.DAL.Models;

namespace MyHealthPlus.DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _context;
        private DbContextTransaction _transaction;

        public UnitOfWork(MyHealthPlusDbContext context)
        {
            _context = context;
        }

        public void BeginTransaction()
        {
            _transaction = _context?.Database?.BeginTransaction();
        }

        public void Save()
        {
            _context?.SaveChanges();
        }

        public void Commit()
        {
            _transaction?.Commit();
        }

        public void Rollback()
        {
            _transaction?.Rollback();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
