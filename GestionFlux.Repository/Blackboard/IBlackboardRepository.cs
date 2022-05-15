using GestionFlux.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionFlux.Repository.Blackboard
{
    public interface IBlackboardRepository<TEntity, TContext> : IRepository<TEntity, TContext>
    {
        void SetSuggPrice(Domain.Models.Product product);
    }
}
