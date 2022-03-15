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
        Repository<ProductProfile> productProfileRepository;

        ProductService(Repository<Product> productRepository, Repository<ProductProfile> productProfileRepository)
        {
            this.productRepository = productRepository;
            this.productProfileRepository = productProfileRepository;
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

        IEnumerable<ProductProfile> GetProductProfiles()
        {
            return productProfileRepository.GetAll();
        }
        ProductProfile GetProductProfile(int id)
        {
            return productProfileRepository.Get(id);
        }
        void InsertProductProfile(ProductProfile product)
        {

        }
        void UpdateProductProfile(ProductProfile product)
        {

        }
        void DeleteProductProfile(int id)
        {

        }
    }
}
