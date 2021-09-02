using GeneralStoreAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace GeneralStoreAPI.Controllers
{
    public class ProductController : ApiController
    {
        private readonly GeneralStoreDbContext _context = new GeneralStoreDbContext();

        // C / P
        [HttpPost]
        public async Task<IHttpActionResult> PostProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                // Adds the product to the C3 representation of the database, not the actual database
                _context.Products.Add(product);
                // This translates our changes to SQL and then executes them
                await _context.SaveChangesAsync();
                return Ok();
            }

            return BadRequest(ModelState);
        }
        // R

        [HttpGet]
        public async Task<IHttpActionResult> GetAllProducts()
        {
            List<Product> products = await _context.Products.ToListAsync();
            return Ok(products);
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetProductById([FromUri] int id)
        {
            Product product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        // U 
        [HttpPut]
        [Route("api/Product/{id}/Update")]
        public async Task<IHttpActionResult> UpdateProduct([FromUri] string id, [FromBody] ProductUpdate newProduct)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // 400
            }

            int idInt = Int32.Parse(id);
            Product oldProduct = await _context.Products.FindAsync(idInt);

            if (oldProduct == null)
            {
                return NotFound(); //404
            }

            oldProduct.Name = newProduct.Name;
            oldProduct.Price = newProduct.Price;
            //oldProduct.Quantity = newProduct.Quantity;
            oldProduct.UPC = newProduct.UPC;

            await _context.SaveChangesAsync();

            return Ok(); //200
        }
        [HttpPut]
        [Route("api/Product/{id}/Restock")]

        // Define the pattern in App_Start/RouteConfig.cs
        // ../api/Product/1/Restock
        public async Task<IHttpActionResult> RestockProduct([FromUri] int id, [FromBody] Restock restock)
        {
            Product product = await _context.Products.FindAsync(id);

            if(product == null)
            {
                return NotFound();
            }

            product.Quantity += restock.Amount;

            await _context.SaveChangesAsync();

            return Ok();
        }
        // D
        [HttpDelete]
        public async Task<IHttpActionResult> DeleteProduct([FromUri] int id)
        {
            Product product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            // This actaully deletes the product
            _context.Products.Remove(product);
            // You could just remove the product from the display method and not actually delete product from database
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}

