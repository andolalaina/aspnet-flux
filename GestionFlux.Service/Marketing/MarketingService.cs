using GestionFlux.Core.Repository;
using GestionFlux.Core.Service;
using GestionFlux.Domain.Models;
using GestionFlux.Repository;
using GestionFlux.Service.Marketing;
using System.Collections.Generic;

namespace GestionFlux.Service.Marketing
{
    public class MarketingService : IMarketingService
    {
        BaseRepository<Product, FluxDbContext> _productRepository;
        BaseRepository<Client, FluxDbContext> _clientRepository;

        public MarketingService(BaseRepository<Product, FluxDbContext> productRepository, BaseRepository<Client, FluxDbContext> clientRepository)
        {
            _productRepository = productRepository;
            _clientRepository = clientRepository;
        }

        public IEnumerable<Product> GetProducts()
        {
            return _productRepository.GetAll();
        }
        public IEnumerable<Client> GetClients()
        {
            return _clientRepository.GetAll();
        }
        public Product GetProduct(int id)
        {
            return _productRepository.Get(id);
        }
        public void InsertProduct(Product product)
        {

        }
        public void UpdateProduct(Product product)
        {

        }
        public void DeleteProduct(int id)
        {

        }

    }
}
