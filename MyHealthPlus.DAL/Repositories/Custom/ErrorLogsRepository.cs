using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyHealthPlus.DAL.Interfaces.Custom;
using MyHealthPlus.DAL.Models;

namespace MyHealthPlus.DAL.Repositories.Custom
{
    public class ErrorLogsRepository : Repository<ErrorLogs>, IErrorLogsRepository
    {
        public ErrorLogsRepository(DbContext context) : base(context)
        {
        }
    }
}
