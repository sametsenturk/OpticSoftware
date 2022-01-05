using OpticSoftware.Core;
using OpticSoftware.Entity.Entities.Company;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpticSoftware.DAL.Abstract.Company
{
    public interface ICompanyParameterService : IRepository<CompanyParameterEntity>, IUnitOfWork
    {
    }
}
