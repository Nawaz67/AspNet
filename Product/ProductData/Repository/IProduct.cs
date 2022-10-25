using ProductEntity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductData.Repository
{
    public interface IProduct
    {
        void AddProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(Guid productId);
        Product GetProductById(Guid productId);
        IEnumerable<Product> GetProducts();
        void GenerateProductCode(Product product, out string productCode);

    }
}
