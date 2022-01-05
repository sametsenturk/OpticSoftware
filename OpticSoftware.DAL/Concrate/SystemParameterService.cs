using OpticSoftware.Core;
using OpticSoftware.DAL.Abstract;
using OpticSoftware.Entity.Context;
using OpticSoftware.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OpticSoftware.DAL.Concrate
{
    public class SystemParameterService : ISystemParameterService
    {
        private readonly IUnitOfWork _uow;
        private readonly IRepository<SystemParameterEntity> _repo;

        public OpticDBContext Context => this._uow.Context;

        public SystemParameterService(IUnitOfWork unit, IRepository<SystemParameterEntity> repo)
        {
            _uow = unit;
            _repo = repo;
        }

        public async Task AddAsync(SystemParameterEntity entity) => await _repo.AddAsync(entity);
        public async Task DeleteAsync(SystemParameterEntity entity) => await _repo.DeleteAsync(entity);
        public async Task<SystemParameterEntity> FirstOrDefaultAsync(Expression<Func<SystemParameterEntity, bool>> predicate, params string[] includes) => await _repo.FirstOrDefaultAsync(predicate, includes);
        public async Task<IEnumerable<SystemParameterEntity>> GetAsync(params string[] includes) => await _repo.GetAsync(includes);
        public async Task<IEnumerable<SystemParameterEntity>> GetAsync(Expression<Func<SystemParameterEntity, bool>> predicate, params string[] includes) => await _repo.GetAsync(predicate, includes);
        public async Task UpdateAsync(SystemParameterEntity entity) => await _repo.UpdateAsync(entity);
        public async Task SaveChangesAsync() => await _uow.SaveChangesAsync();
        //public void Dispose() => this._uow.Dispose();
    }
}
