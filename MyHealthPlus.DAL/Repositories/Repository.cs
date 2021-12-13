using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using MyHealthPlus.DAL.Interfaces;

namespace MyHealthPlus.DAL.Repositories
{
    public class Repository<T> : IBaseRepository<T> where T : class
    {
        private DbContext _context;
        private DbSet<T> dbSet;

        public Repository(DbContext context)
        {
            _context = context;
            dbSet = _context.Set<T>();
        }
        public IEnumerable<T> GetAll()
        {
            return dbSet.ToList();
        }

        public T GetById(object id)
        {
            return dbSet.Find(id);
        }

        public T Add(T obj)
        {
            dbSet.Add(obj);
            Save();
            return obj;
        }
        public IEnumerable<T> Add(IEnumerable<T> obj)
        {
            dbSet.AddRange(obj);
            Save();
            return obj;
        }

        public void Delete(object id)
        {
            T entityToDelete = dbSet.Find(id);
            Delete(entityToDelete);
        }

        public void Delete(T obj)
        {
            if (_context.Entry(obj).State == EntityState.Detached)
            {
                dbSet.Attach(obj);
            }
            dbSet.Remove(obj);
        }

        public T Update(T obj)
        {
            dbSet.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
            Save();
            return obj;
        }

        public T Update(T obj, bool modifiedStatus, Expression<Func<T, object>>[] properties)
        {
            _context.Entry(obj).State = modifiedStatus ? EntityState.Unchanged : EntityState.Modified;
            foreach (var property in properties)
            {
                var propertyName = GetExpressionText(property);
                _context.Entry(obj).Property(propertyName).IsModified = modifiedStatus;
            }

            Save();
            return obj;
            //return DatabaseContext.SaveChangesWithoutValidation();
        }

        public T UpdateIsActive(T obj)
        {
            dbSet.Attach(obj);
            _context.Entry(obj).Property("IsActive").IsModified = true;
            Save();
            return obj;
        }

        public void Save()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        //System.Console.WriteLine("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                        throw new Exception(string.Format("Property: [0] Error: [1]", validationError.PropertyName, validationError.ErrorMessage));
                    }
                }
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_context != null)
                {
                    _context.Dispose();
                    _context = null;
                }
            }
        }

        private string GetExpressionText(LambdaExpression expression)
        {
            Stack<string> stack = new Stack<string>();
            Expression expression1 = expression.Body;
            while (expression1 != null)
            {
                if (expression1.NodeType == ExpressionType.Call)
                {
                    MethodCallExpression methodCallExpression = (MethodCallExpression)expression1;
                    if (IsSingleArgumentIndexer((Expression)methodCallExpression))
                    {
                        stack.Push(GetIndexerInvocation(Enumerable.Single<Expression>((IEnumerable<Expression>)methodCallExpression.Arguments), Enumerable.ToArray<ParameterExpression>((IEnumerable<ParameterExpression>)expression.Parameters)));
                        expression1 = methodCallExpression.Object;
                    }
                    else
                        break;
                }
                else if (expression1.NodeType == ExpressionType.ArrayIndex)
                {
                    BinaryExpression binaryExpression = (BinaryExpression)expression1;
                    stack.Push(GetIndexerInvocation(binaryExpression.Right, Enumerable.ToArray<ParameterExpression>((IEnumerable<ParameterExpression>)expression.Parameters)));
                    expression1 = binaryExpression.Left;
                }
                else if (expression1.NodeType == ExpressionType.MemberAccess)
                {
                    MemberExpression memberExpression = (MemberExpression)expression1;
                    stack.Push("." + memberExpression.Member.Name);
                    expression1 = memberExpression.Expression;
                }
                else if (expression1.NodeType == ExpressionType.Parameter)
                {
                    stack.Push(string.Empty);
                    expression1 = (Expression)null;
                }
                else
                    break;
            }
            if (stack.Count > 0 && string.Equals(stack.Peek(), ".model", StringComparison.OrdinalIgnoreCase))
                stack.Pop();
            if (stack.Count <= 0)
                return string.Empty;

            return Enumerable.Aggregate<string>((IEnumerable<string>)stack, (Func<string, string, string>)((left, right) => left + right)).TrimStart(new char[1]
            {
                '.'
            });
        }

        private bool IsSingleArgumentIndexer(Expression expression)
        {
            var methodExpression = expression as MethodCallExpression;
            if (methodExpression == null || methodExpression.Arguments.Count != 1)
                return false;
            else
                return (methodExpression.Method.DeclaringType.GetDefaultMembers()).OfType<PropertyInfo>().Any((p => p.GetGetMethod() == methodExpression.Method));
        }

        private string GetIndexerInvocation(Expression expression, ParameterExpression[] parameters)
        {
            return "";

        }


        public IQueryable<T> GetAllAsQueryable()
        {
            return dbSet.AsQueryable();
        }

        /// <summary>
        /// Get list of items by sql query
        /// </summary>
        /// <typeparam name="TKey">Entity to be used</typeparam>
        /// <param name="sql">Sql query</param>
        /// <param name="parameters">Sql Parameters if any</param>
        /// <returns>List of item by the given sql query</returns>
        public List<TKey> GetBySql<TKey>(string sql, params object[] parameters)
        {
            var items = _context.Database.SqlQuery<TKey>(sql, parameters).ToList();
            return items;
        }
    }
}
