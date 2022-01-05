using OpticSoftware.Entity.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OpticSoftware.Core
{
    public class UnitOfWork : IUnitOfWork
    {
        public OpticDBContext Context { get; }

        public UnitOfWork(OpticDBContext context)
        {
            Context = context;
        }

        public async Task SaveChangesAsync()
        {
            await Context.SaveChangesAsync();
        }
    }
}
