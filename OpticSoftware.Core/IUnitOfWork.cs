using OpticSoftware.Entity.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OpticSoftware.Core
{
    public interface IUnitOfWork
    {
        OpticDBContext Context { get; }
        Task SaveChangesAsync();
    }
}
