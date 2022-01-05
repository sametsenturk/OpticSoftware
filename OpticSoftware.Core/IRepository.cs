using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OpticSoftware.Core
{
    public interface IRepository<T> where T : class, new()
    {
        Task<IEnumerable<T>> GetAsync(params string[] includes);
        Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> predicate, params string[] includes);
        Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate, params string[] includes);
        Task AddAsync(T entity);
        Task DeleteAsync(T entity);
        Task UpdateAsync(T entity);
    }
}
