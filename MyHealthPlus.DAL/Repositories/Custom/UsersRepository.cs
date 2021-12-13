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
    public class UsersRepository : Repository<Users>, IUsersRepository
    {
        public UsersRepository(DbContext context) : base(context)
        {
        }
    }
}
