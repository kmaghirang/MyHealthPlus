using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyHealthPlus.DAL.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        IEnumerable<T> GetAll();

        T GetById(object id);

        T Add(T obj);

        IEnumerable<T> Add(IEnumerable<T> obj);

        T Update(T obj);

        T Update(T obj, bool modifiedStatus, Expression<Func<T, object>>[] properties);

        void Delete(object id);

        void Save();

        IQueryable<T> GetAllAsQueryable();

        List<TKey> GetBySql<TKey>(string sql, params object[] parameters);
    }
}
