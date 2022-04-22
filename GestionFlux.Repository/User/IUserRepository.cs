using GestionFlux.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionFlux.Repository.User
{
    public interface IUserRepository<TEntity, TContext> : IRepository<TEntity, TContext>
    {
        void SetDepartment(int userId, int departmentID);
    }
}
