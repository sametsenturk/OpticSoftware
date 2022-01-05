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
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _uow;
        private readonly IRepository<UserEntity> _repo;

        public OpticDBContext Context => this._uow.Context;

        public UserService(IUnitOfWork unit, IRepository<UserEntity> repo)
        {
            _uow = unit;
            _repo = repo;
        }

        public async Task AddAsync(UserEntity entity) => await _repo.AddAsync(entity);
        public async Task DeleteAsync(UserEntity entity) => await _repo.DeleteAsync(entity);
        public async Task<UserEntity> FirstOrDefaultAsync(Expression<Func<UserEntity, bool>> predicate, params string[] includes) => await _repo.FirstOrDefaultAsync(predicate, includes);
        public async Task<IEnumerable<UserEntity>> GetAsync(params string[] includes) => await _repo.GetAsync(includes);
        public async Task<IEnumerable<UserEntity>> GetAsync(Expression<Func<UserEntity, bool>> predicate, params string[] includes) => await _repo.GetAsync(predicate, includes);
        public async Task UpdateAsync(UserEntity entity) => await _repo.UpdateAsync(entity);
        public async Task SaveChangesAsync() => await _uow.SaveChangesAsync();
        //public void Dispose() => this._uow.Dispose();
    }
}
