using GestionFlux.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionFlux.Repository.Department
{
    public interface IDepartmentRepository<TEntity, TContext> : IRepository<TEntity, TContext>
    {
        Domain.Models.Department FindByNameOrCreate(string name);
    }
}
