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

        public async Task<IHttpActionResult> PostCustomer(Customer customer)
        {
            if (ModelState.IsValid)
            {
                _context.Customers.Add(customer);

                await _context.SaveChangesAsync();
                return Ok();
            }

            return BadRequest();
        }

        public async Task<IHttpActionResult> GetAllCustomers()
        {
            List<Customer> customers = await _context.Customers.ToListAsync();
            return Ok(customers);
        }
    }
}
