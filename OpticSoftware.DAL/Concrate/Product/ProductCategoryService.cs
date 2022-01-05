using OpticSoftware.Core;
using OpticSoftware.DAL.Abstract.Product;
using OpticSoftware.Entity.Context;
using OpticSoftware.Entity.Entities.Product;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OpticSoftware.DAL.Concrate.Product
{
    public class ProductCategoryService : IProductCategoryService
    {
        private readonly IUnitOfWork _uow;
        private readonly IRepository<ProductCategoryEntity> _repo;

        public OpticDBContext Context => this._uow.Context;

        public ProductCategoryService(IUnitOfWork unit, IRepository<ProductCategoryEntity> repo)
        {
            _uow = unit;
            _repo = repo;
        }

        public async Task AddAsync(ProductCategoryEntity entity) => await _repo.AddAsync(entity);
        public async Task DeleteAsync(ProductCategoryEntity entity) => await _repo.DeleteAsync(entity);
        public async Task<ProductCategoryEntity> FirstOrDefaultAsync(Expression<Func<ProductCategoryEntity, bool>> predicate, params string[] includes) => await _repo.FirstOrDefaultAsync(predicate, includes);
        public async Task<IEnumerable<ProductCategoryEntity>> GetAsync(params string[] includes) => await _repo.GetAsync(includes);
        public async Task<IEnumerable<ProductCategoryEntity>> GetAsync(Expression<Func<ProductCategoryEntity, bool>> predicate, params string[] includes) => await _repo.GetAsync(predicate, includes);
        public async Task UpdateAsync(ProductCategoryEntity entity) => await _repo.UpdateAsync(entity);
        public async Task SaveChangesAsync() => await _uow.SaveChangesAsync();
        //public void Dispose() => this._uow.Dispose();
    }
}
