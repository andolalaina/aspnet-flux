using GestionFlux.Domain.Models;
using GestionFlux.Repository;
using GestionFlux.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionFlux.Service.Services
{
    public class MarketingService : IMarketingService
    {
        Repository<Product> productRepository;
        Repository<Client> clientRepository;

        public MarketingService(Repository<Product> productRepository, Repository<Client> clientRepository)
        {
            this.productRepository = productRepository;
            this.clientRepository = clientRepository;
        }

        public IEnumerable<Product> GetProducts()
        {
            return productRepository.GetAll();
        }
        public IEnumerable<Client> GetClients()
        {
            return clientRepository.GetAll();
        }
        public Product GetProduct(int id)
        {
            return productRepository.Get(id);
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
