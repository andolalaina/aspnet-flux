using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionFlux.Core.Repository
{
    public interface IRepository<TEntity, TContext>
    {
        IEnumerable<TEntity> GetAll();
        TEntity Get(int id);
        void Insert(TEntity entity);
        void Update(int id, TEntity entity);
        void Delete(int id);
        void SaveChanges();
    }
}
