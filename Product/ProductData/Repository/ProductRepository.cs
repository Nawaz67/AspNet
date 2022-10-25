using ProductData.Data;
using ProductEntity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProductData.Repository
{
    public class ProductRepository:IProduct
    {
        ProductDbContext _productDbContext;
        
        public ProductRepository(ProductDbContext productDbContext)
        {
            _productDbContext = productDbContext;
        }

        public void AddProduct(Product product)
        {
            Guid id = Guid.NewGuid();
            product.productId = id;
            _productDbContext.products.Add(product);
            _productDbContext.SaveChanges();
        }

        public void DeleteProduct(Guid productId)
        {
            throw new NotImplementedException();
        }

        public Product GetProductById(Guid productId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetProducts()
        {
            return _productDbContext.products.ToList();
        }

        public void UpdateProduct(Product product)
        {
            throw new NotImplementedException();
        }

        
        private static int code1 = 001;
        private static long code2 = 10000000;
        private static Random random = new Random();
        private const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

        public void GenerateProductCode(Product product, out string code)
        {
            code = ComputeCode(product);

            while (CheckIfUnique(code))
            {
                code = ComputeCode(product);
            }
        }

        private string ComputeCode(Product product)
        {
            string code;

            switch (product.channelId)
            {
                case 1:
                    code = $"{product.productYear}00{code1}";
                    code1++;
                    break;
                case 2:
                    code = AlphanumericGenerator(6);
                    break;
                case 3:
                    code = $"{code2}";
                    code2++;
                    break;

                default: code = "Invalid Code"; break;
            }
            return code;
        }

        private bool CheckIfUnique(string code)
        {
            return _productDbContext.products.Any(x => x.productCode == code);
        }
        private string AlphanumericGenerator(int length)
        {
            var result = new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
            return result;
        }
    }
}
