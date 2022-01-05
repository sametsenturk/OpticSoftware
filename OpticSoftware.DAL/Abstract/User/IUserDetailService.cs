using OpticSoftware.Core;
using OpticSoftware.Entity.Entities.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpticSoftware.DAL.Abstract.User
{
    public interface IUserDetailService : IRepository<UserDetailEntity>, IUnitOfWork
    {
    }
}
