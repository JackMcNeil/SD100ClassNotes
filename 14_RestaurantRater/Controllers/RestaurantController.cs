using _14_RestaurantRater.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace _14_RestaurantRater.Controllers
{
    public class RestaurantController : ApiController
    {
        private readonly RestaurantDBContext _context = new RestaurantDBContext();
        //C
        //Post
        [HttpPost]
        public async Task<IHttpActionResult> PostRestaurant(Restaurant restaurant)
        {
            if (ModelState.IsValid)
            {
                _context.Restaurants.Add(restaurant);
                await _context.SaveChangesAsync();

                return Ok();
            }

            return BadRequest(ModelState);
        }

        //R
        //Get
        [HttpGet]
        public async Task<IHttpActionResult> Get()
        {
            List<Restaurant> restaurants = await _context.Restaurants.ToListAsync();
            return Ok(restaurants); //200 ok
        }
        // Get by Id
        [HttpGet]
        public async Task<IHttpActionResult> GetById(int id)
        {
            Restaurant restaurant = await _context.Restaurants.FindAsync(id);
            if(restaurant != null)
            {
                return Ok(restaurant); // 200
            }
            return NotFound(); // 404
        }

        //U
        //Put
        [HttpPut]
        public async Task<IHttpActionResult> UpdateRestaurant([FromUri]int id, [FromBody]Restaurant model)
        {
            if (ModelState.IsValid)
            {
                Restaurant restaurant = await _context.Restaurants.FindAsync(id);

                if (restaurant != null)
                {
                    restaurant.Name = model.Name;
                    restaurant.Location = model.Location;

                    await _context.SaveChangesAsync();

                    return Ok(); // 200
                }
                return NotFound(); // 404
            }
            return BadRequest(ModelState); // 500
        }

        //D
        //Delete
        [HttpDelete]
        public async Task<IHttpActionResult> DeleteRestaurantById(int id)
        {
            Restaurant restaurant = await _context.Restaurants.FindAsync(id);

            if (restaurant == null)
            {
                return NotFound(); // 404
            }

            _context.Restaurants.Remove(restaurant);

            if (await _context.SaveChangesAsync() == 1)
            {
                return Ok(); // 200
            }

            return InternalServerError(); //500
        }


    }
}
