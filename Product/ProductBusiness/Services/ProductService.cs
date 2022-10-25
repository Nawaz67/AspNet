using Microsoft.EntityFrameworkCore;
using ProductData.Data;
using ProductData.Repository;
using ProductEntity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace ProductBusiness.Services
{
    public class ProductService
    {
        IProduct _product;
        ProductDbContext _db;
        
        public ProductService(IProduct product,ProductDbContext db)
        {
            _product = product;

            _db = db;
        }

        
        public void AddProduct(Product product)
        {
            string ProductCode = string.Empty;
            _product.GenerateProductCode(product, out ProductCode);
            product.productCode = ProductCode;
            _db.products.Add(product);
            
            _db.SaveChangesAsync();
            
        }
        public void UpdateProduct(Product product)
        {
            _product.UpdateProduct(product);
        }
        public void DeleteProduct(Guid productId)
        {
            _product.DeleteProduct(productId);
        }
        public Product GetProductById(Guid productId)
        {
            return _product.GetProductById(productId);
        }
        public IEnumerable<Product> GetProducts()
        {
            return _product.GetProducts();
        }

    }
}
