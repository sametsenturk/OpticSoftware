using OpticSoftware.Core;
using OpticSoftware.DAL.Abstract.Product;
using OpticSoftware.Entity.Context;
using OpticSoftware.Entity.Entities;
using OpticSoftware.Entity.Entities.Product;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OpticSoftware.DAL.Concrate.Product
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _uow;
        private readonly IRepository<ProductEntity> _repo;

        public OpticDBContext Context => this._uow.Context;

        public ProductService(IUnitOfWork unit, IRepository<ProductEntity> repo)
        {
            _uow = unit;
            _repo = repo;
        }

        public async Task AddAsync(ProductEntity entity) => await _repo.AddAsync(entity);
        public async Task DeleteAsync(ProductEntity entity) => await _repo.DeleteAsync(entity);
        public async Task<ProductEntity> FirstOrDefaultAsync(Expression<Func<ProductEntity, bool>> predicate, params string[] includes) => await _repo.FirstOrDefaultAsync(predicate, includes);
        public async Task<IEnumerable<ProductEntity>> GetAsync(params string[] includes) => await _repo.GetAsync(includes);
        public async Task<IEnumerable<ProductEntity>> GetAsync(Expression<Func<ProductEntity, bool>> predicate, params string[] includes) => await _repo.GetAsync(predicate, includes);
        public async Task UpdateAsync(ProductEntity entity) => await _repo.UpdateAsync(entity);
        public async Task SaveChangesAsync() => await _uow.SaveChangesAsync();
        //public void Dispose() => this._uow.Dispose();
    }
}
