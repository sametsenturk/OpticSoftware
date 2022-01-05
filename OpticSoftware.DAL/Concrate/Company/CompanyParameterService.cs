using OpticSoftware.Core;
using OpticSoftware.DAL.Abstract.Company;
using OpticSoftware.Entity.Context;
using OpticSoftware.Entity.Entities;
using OpticSoftware.Entity.Entities.Company;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OpticSoftware.DAL.Concrate.Company
{
    public class CompanyParameterService : ICompanyParameterService
    {
        private readonly IUnitOfWork _uow;
        private readonly IRepository<CompanyParameterEntity> _repo;

        public OpticDBContext Context => this._uow.Context;

        public CompanyParameterService(IUnitOfWork unit, IRepository<CompanyParameterEntity> repo)
        {
            _uow = unit;
            _repo = repo;
        }

        public async Task AddAsync(CompanyParameterEntity entity) => await _repo.AddAsync(entity);
        public async Task DeleteAsync(CompanyParameterEntity entity) => await _repo.DeleteAsync(entity);
        public async Task<CompanyParameterEntity> FirstOrDefaultAsync(Expression<Func<CompanyParameterEntity, bool>> predicate, params string[] includes) => await _repo.FirstOrDefaultAsync(predicate, includes);
        public async Task<IEnumerable<CompanyParameterEntity>> GetAsync(params string[] includes) => await _repo.GetAsync(includes);
        public async Task<IEnumerable<CompanyParameterEntity>> GetAsync(Expression<Func<CompanyParameterEntity, bool>> predicate, params string[] includes) => await _repo.GetAsync(predicate, includes);
        public async Task UpdateAsync(CompanyParameterEntity entity) => await _repo.UpdateAsync(entity);
        public async Task SaveChangesAsync() => await _uow.SaveChangesAsync();
        //public void Dispose() => this._uow.Dispose();
    }
}
