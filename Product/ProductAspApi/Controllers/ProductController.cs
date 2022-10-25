using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductBusiness.Services;
using ProductEntity.Models;
using System;
using System.Collections.Generic;

namespace ProductAspApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        ProductService _productService;
        public ProductController(ProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("GetProducts")]
        public IEnumerable<Product> GetProducts()
        {
            return _productService.GetProducts();
        }

        [HttpGet("GetProductById")]
        public Product GetProductById(Guid productId)
        {
            return _productService.GetProductById(productId);
        }

        [HttpPost("AddProduct")]
        public IActionResult AddProduct([FromBody] Product product)
        {
            _productService.AddProduct(product);
            return Ok("Product Added Successfully");
        }

        [HttpPut("UpdateProduct")]
        public IActionResult UpdateProduct([FromBody] Product product)
        {
            _productService.UpdateProduct(product);
            return Ok("Product Updated Successfully");
        }

        [HttpDelete("DeleteProduct")]
        public IActionResult DeleteProduct(Guid productId)
        {
            _productService.DeleteProduct(productId);
            return Ok("Product Deleted Successfully");
        }
    }
}
