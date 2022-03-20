using GestionFlux.Domain.Models;
using GestionFlux.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionFlux.Service.Services
{
    class ProductService
    {
        Repository<Product> productRepository;

        ProductService(Repository<Product> productRepository)
        {
            this.productRepository = productRepository;
        }

        IEnumerable<Product> GetProducts()
        {
            return productRepository.GetAll();
        }
        Product GetProduct(int id)
        {
            return productRepository.Get(id);
        }
        void InsertProduct(Product product)
        {

        }
        void UpdateProduct(Product product)
        {

        }
        void DeleteProduct(int id)
        {

        }
    }
}
