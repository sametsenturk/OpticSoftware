using OpticSoftware.Core;
using OpticSoftware.Entity.Entities.Product;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpticSoftware.DAL.Abstract.Product
{
    public interface IProductService : IRepository<ProductEntity>, IUnitOfWork
    {
    }
}
