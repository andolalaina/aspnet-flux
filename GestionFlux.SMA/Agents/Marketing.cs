using GestionFlux.SMA.Interfaces;
using GestionFlux.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionFlux.Repository.Blackboard;
using GestionFlux.Domain;

namespace GestionFlux.SMA.Agents
{
    public class Marketing : IAgent
    {
        private static Marketing _instance;
        private BlackboardRepository<BlackBoard, FluxDbContext> _bbRepository;
        public BlackBoard BlackBoard { get; }

        public Marketing(BlackboardRepository<BlackBoard, FluxDbContext> bRepo)
        {
            _bbRepository = bRepo;
        }

        public static Marketing Instance()
        {
            if (_instance == null) _instance = new Marketing(new BlackboardRepository<BlackBoard, FluxDbContext>(new FluxDbContext()));
            return _instance;
        }

        public SuggProduct GetSuggProduct(int productId)
        {
            return _bbRepository.GetSuggProduct(productId);
        }

        public IEnumerable<SuggProduct> GetSuggProducts()
        {
            return _bbRepository.GetSuggProducts();
        }

        public void OnProductUpdated(Object source, Product product)
        {
            System.Diagnostics.Debug.WriteLine("Updated product : " + product.Id + " - " + product.Name);
            _bbRepository.SetSuggPrice(product);
        }
    }
}
