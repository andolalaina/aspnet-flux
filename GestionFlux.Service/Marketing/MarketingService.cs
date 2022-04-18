using GestionFlux.Core.Repository;
using GestionFlux.Core.Service;
using GestionFlux.Domain.Models;
using GestionFlux.Domain;
using GestionFlux.Repository;
using GestionFlux.SMA;
using System;
using System.Collections.Generic;

namespace GestionFlux.Service.Marketing
{
    public class MarketingService : IMarketingService
    {
        BaseRepository<Product, FluxDbContext> _productRepository;
        BaseRepository<Client, FluxDbContext> _clientRepository;

        #region EVENT
        public event EventHandler<Product> ProductUpdated;
        #endregion

        public MarketingService(BaseRepository<Product, FluxDbContext> productRepository, BaseRepository<Client, FluxDbContext> clientRepository)
        {
            _productRepository = productRepository;
            _clientRepository = clientRepository;
            ProductUpdated += SMA.Agents.Marketing.Instance().OnProductUpdated;
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
            OnProductUpdated(product);
        }
        public void DeleteProduct(int id)
        {

        }

        #region EVENT HANDLER
        protected virtual void OnProductUpdated(Product product)
        {
            ProductUpdated?.Invoke(this, product);
        }
        #endregion

    }
}
