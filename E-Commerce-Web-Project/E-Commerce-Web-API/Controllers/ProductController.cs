using AutoMapper;
using E_Comemerce_Web_DAL;
using E_commerce_Web_DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace E_Commerce_Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly E_Commerce_Web_DBContext _dbContext;
        private readonly IMapper _mapper;

        public ProductsController(E_Commerce_Web_DBContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        // GET: api/Products
        [HttpGet]
        public List<ProductDTO> GetProducts()
        {
            return _mapper.Map<List<ProductDTO>>(_dbContext.Products.ToList<Product>());
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public ProductDTO GetProductById(int id)
        {
            return _mapper.Map<ProductDTO>(_dbContext.Products.Find(id));
        }

        // POST: api/Products
        [HttpPost]
        public ActionResult AddProduct(ProductDTO newProduct)
        {
            try
            {
                var product = _mapper.Map<Product>(newProduct);
                _dbContext.Products.Add(product);
                _dbContext.SaveChanges();
                return Ok(newProduct);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }

        }

        // PUT: api/Products/5
        [HttpPut("{id}")]
        public ActionResult UpdateProduct([FromRoute] int id, ProductDTO product)
        {
            try
            {
                var myProduct = _dbContext.Products.Find(id);
                if (myProduct == null)
                {
                    return NotFound();
                }

                myProduct.ProductName = product.ProductName;
                myProduct.ProductPicture = product.ProductPicture;
                myProduct.ProductPrice = product.ProductPrice;

                _dbContext.SaveChanges();
                return Ok(myProduct);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }

        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public ActionResult DeleteProduct(int id)
        {
            try
            {
                var product = _dbContext.Products.Find(id);
                if (product == null)
                    return NotFound();

                _dbContext.Products.Remove(product);
                _dbContext.SaveChanges();

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }

        }
    }
}
