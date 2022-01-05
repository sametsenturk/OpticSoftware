using Microsoft.EntityFrameworkCore;
using OpticSoftware.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OpticSoftware.Core
{
    public class Repository<T> : IRepository<T> where T : BaseEntity, new()
    {
        private readonly IUnitOfWork _unitOfWork;

        public Repository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task AddAsync(T entity)
        {
            await _unitOfWork.Context.Set<T>().AddAsync(entity);
        }

        public async Task DeleteAsync(T entity)
        {
            T existing = await _unitOfWork.Context.Set<T>().AsNoTracking().FirstOrDefaultAsync(x => x.ID == entity.ID);
            if (existing != null)
            {
                _unitOfWork.Context.Set<T>().Remove(existing);
            }
        }

        public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate, params string[] includes)
        {
            IQueryable<T> query = _unitOfWork.Context.Set<T>().AsNoTracking();
            query = this.SetIncludes(query, includes);
            return await query.FirstOrDefaultAsync(predicate);
        }

        public async Task<IEnumerable<T>> GetAsync(params string[] includes)
        {
            IQueryable<T> query = _unitOfWork.Context.Set<T>().AsNoTracking();
            query = this.SetIncludes(query, includes);
            return await query.ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> predicate, params string[] includes)
        {
            IQueryable<T> query = _unitOfWork.Context.Set<T>().Where(predicate).AsNoTracking();
            query = this.SetIncludes(query, includes);
            return await query.ToListAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            T exist = await _unitOfWork.Context.Set<T>().FirstOrDefaultAsync(x => x.ID == entity.ID);
            if (exist != null)
            {
                _unitOfWork.Context.Entry(exist).CurrentValues.SetValues(entity);
                await _unitOfWork.SaveChangesAsync();
            }
        }

        private IQueryable<T> SetIncludes(IQueryable<T> query, params string[] includes)
        {
            if (includes != null && includes.Length > 0)
            {
                Parallel.ForEach(includes, (x) =>
                {
                    query = query.Include(x);
                });
            }
            return query;
        }
    }
}
