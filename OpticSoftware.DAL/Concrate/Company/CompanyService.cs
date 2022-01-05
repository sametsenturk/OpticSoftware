using OpticSoftware.Core;
using OpticSoftware.DAL.Abstract.Company;
using OpticSoftware.Entity.Context;
using OpticSoftware.Entity.Entities.Company;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OpticSoftware.DAL.Concrate.Company
{
    public class CompanyService : ICompanyService
    {
        private readonly IUnitOfWork _uow;
        private readonly IRepository<CompanyEntity> _repo;

        public OpticDBContext Context => this._uow.Context;

        public CompanyService(IUnitOfWork unit, IRepository<CompanyEntity> repo)
        {
            _uow = unit;
            _repo = repo;
        }

        public async Task AddAsync(CompanyEntity entity) => await _repo.AddAsync(entity);
        public async Task DeleteAsync(CompanyEntity entity) => await _repo.DeleteAsync(entity);
        public async Task<CompanyEntity> FirstOrDefaultAsync(Expression<Func<CompanyEntity, bool>> predicate, params string[] includes) => await _repo.FirstOrDefaultAsync(predicate, includes);
        public async Task<IEnumerable<CompanyEntity>> GetAsync(params string[] includes) => await _repo.GetAsync(includes);
        public async Task<IEnumerable<CompanyEntity>> GetAsync(Expression<Func<CompanyEntity, bool>> predicate, params string[] includes) => await _repo.GetAsync(predicate, includes);
        public async Task UpdateAsync(CompanyEntity entity) => await _repo.UpdateAsync(entity);
        public async Task SaveChangesAsync() => await _uow.SaveChangesAsync();
        //public void Dispose() => this._uow.Dispose();
    }
}
