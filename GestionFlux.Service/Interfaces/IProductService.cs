using GestionFlux.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionFlux.Service.Interfaces
{
    interface IProductService
    {
        IEnumerable<Product> GetProducts();
        Product GetProduct(int id);
        void InsertProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(int id);

        IEnumerable<ProductProfile> GetProductProfiles();
        ProductProfile GetProductProfile(int id);
        void InsertProductProfile(ProductProfile product);
        void UpdateProductProfile(ProductProfile product);
        void DeleteProductProfile(int id);

    }
}
