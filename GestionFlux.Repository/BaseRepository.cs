using GestionFlux.Core.Domain;
using GestionFlux.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionFlux.Repository
{
    public class BaseRepository<TEntity, TContext> : GenericRepository<TEntity, TContext>, IRepository<TEntity, TContext>
        where TEntity : BaseEntity
        where TContext : FluxDbContext
    {
        public BaseRepository(TContext context) : base(context) { }
    }
}
