using OpticSoftware.Core;
using OpticSoftware.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpticSoftware.DAL.Abstract
{
    public interface ISystemParameterService : IRepository<SystemParameterEntity>, IUnitOfWork
    {
    }
}
