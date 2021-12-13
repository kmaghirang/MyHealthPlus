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
    public class StatusRepository : Repository<Status>, IStatusRepository
    {
        public StatusRepository(DbContext context) : base(context)
        {
        }
    }
}
