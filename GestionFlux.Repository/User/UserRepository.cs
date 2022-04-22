using GestionFlux.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionFlux.Repository.User
{
    public class UserRepository<TEntity, TContext> : BaseRepository<TEntity, TContext>, IUserRepository<TEntity, TContext>
        where TEntity : Domain.Models.User
        where TContext : FluxDbContext
    {
        public UserRepository(TContext context) : base(context) { }

        public void SetDepartment(int userId, int departmentId)
        {
            this.Get(userId).Department = null;
            this.Get(userId).Department = _context.Departments.Find(departmentId);
            _context.SaveChanges();
        }
    }
}
