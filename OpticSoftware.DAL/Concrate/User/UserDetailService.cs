using OpticSoftware.Core;
using OpticSoftware.DAL.Abstract.User;
using OpticSoftware.Entity.Context;
using OpticSoftware.Entity.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OpticSoftware.DAL.Concrate.User
{
    public class UserDetailService : IUserDetailService
    {
        private readonly IUnitOfWork _uow;
        private readonly IRepository<UserDetailEntity> _repo;

        public OpticDBContext Context => this._uow.Context;

        public UserDetailService(IUnitOfWork unit, IRepository<UserDetailEntity> repo)
        {
            _uow = unit;
            _repo = repo;
        }

        public async Task AddAsync(UserDetailEntity entity) => await _repo.AddAsync(entity);
        public async Task DeleteAsync(UserDetailEntity entity) => await _repo.DeleteAsync(entity);
        public async Task<UserDetailEntity> FirstOrDefaultAsync(Expression<Func<UserDetailEntity, bool>> predicate, params string[] includes) => await _repo.FirstOrDefaultAsync(predicate, includes);
        public async Task<IEnumerable<UserDetailEntity>> GetAsync(params string[] includes) => await _repo.GetAsync(includes);
        public async Task<IEnumerable<UserDetailEntity>> GetAsync(Expression<Func<UserDetailEntity, bool>> predicate, params string[] includes) => await _repo.GetAsync(predicate, includes);
        public async Task UpdateAsync(UserDetailEntity entity) => await _repo.UpdateAsync(entity);
        public async Task SaveChangesAsync() => await _uow.SaveChangesAsync();
        //public void Dispose() => this._uow.Dispose();
    }
}
