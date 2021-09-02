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
    public class CustomerController : ApiController
    {
        private readonly GeneralStoreDbContext _context = new GeneralStoreDbContext();

        [HttpPost]
        public async Task<IHttpActionResult> PostCustomer(CustomerCreate customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Customer newCustomer = new Customer();
            newCustomer.Name = customer.Name;
            newCustomer.Email = customer.Email;
            newCustomer.DateJoined = DateTime.Now;

            _context.Customers.Add(newCustomer);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetAllCustomers()
        {
            List<Customer> customers = await _context.Customers.ToListAsync();
            return Ok(customers);
        }

        // Get by Id
        // Update

        // Delete
        [HttpDelete]
        public async Task<IHttpActionResult> DeleteCustomer([FromUri] int id)
        {
            Customer customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }

            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
