using GestionFlux.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionFlux.Repository.Blackboard
{
    public class BlackboardRepository<TEntity, TContext> : BaseRepository<TEntity, TContext>, IBlackboardRepository<TEntity, TContext>
        where TEntity : Domain.Models.BlackBoard
        where TContext : FluxDbContext
    {
        public BlackboardRepository(TContext context) : base(context) { }

        private Domain.Models.BlackBoard GetBlackboard()
        {
            Domain.Models.BlackBoard b = _context.BlackBoards.Find(1);
            if (b == null)
            {
                _context.BlackBoards.Add(new Domain.Models.BlackBoard { Id = 1 });
                _context.SaveChanges();
                b = _context.BlackBoards.Find(1);
            }
            return b;
        }

        public void SetSuggPrice(Domain.Models.Product prod)
        {
            var blackboard = GetBlackboard();
            var product = _context.Products.Find(prod.Id);
            if (blackboard.SuggProducts == null)
            {
                blackboard.SuggProducts = new List<Domain.Models.SuggProduct>();
                _context.SaveChanges();
            }

            var suggProduct = blackboard.SuggProducts.Where((s) => s.Product.Id == product.Id);
            if (suggProduct.Count() == 0) blackboard.SuggProducts.Add(new Domain.Models.SuggProduct { Product = product, SuggPrice = 1300 });
            else suggProduct.FirstOrDefault().SuggPrice = 1000;
            _context.SaveChanges();
        }

        public Domain.Models.SuggProduct GetSuggProduct(int productId)
        {
            return _context.SuggProducts.Where((p) => p.Product.Id == productId).FirstOrDefault();
        }

        public IEnumerable<Domain.Models.SuggProduct> GetSuggProducts()
        {
            return _context.SuggProducts.AsEnumerable();
        }
    }
}
