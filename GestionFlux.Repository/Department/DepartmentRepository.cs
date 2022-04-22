using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionFlux.Repository.Department
{
    public class DepartmentRepository<TEntity, TContext> : BaseRepository<TEntity, TContext>, IDepartmentRepository<TEntity, TContext>
        where TEntity : Domain.Models.Department
        where TContext : Domain.FluxDbContext
    {
        public DepartmentRepository(TContext context) : base(context) { }

        public Domain.Models.Department FindByNameOrCreate(string name)
        {
            name = name.Trim().ToUpper();
            try
            {
                Domain.Models.Department departmentInstance = _context.Departments.First(x => x.Name == name);
                System.Diagnostics.Debug.WriteLine("found department : " + departmentInstance.Name);
                return departmentInstance;
            }
            catch (System.InvalidOperationException ex)
            {
                System.Diagnostics.Debug.WriteLine("Creating new department : " + name);
                Domain.Models.Department departmentInstance = new Domain.Models.Department {
                    Name = name
                };
                this.Insert((TEntity)departmentInstance);
                return departmentInstance;
            }
        }
    }
}
