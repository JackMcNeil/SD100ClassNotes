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
    public class RatingController : ApiController
    {
        private readonly RestaurantDBContext _context = new RestaurantDBContext();

        //C
        [HttpPost]
        public async Task<IHttpActionResult> CreateRating(Rating rating)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var restaurant = await _context.Restaurants.FindAsync(rating.RestaurantId);
            if(restaurant == null)
            {
                return BadRequest($"The restaurant with an Id of {rating.RestaurantId} does not exist");
            }

            _context.Ratings.Add(rating);
            if(await _context.SaveChangesAsync() == 1)
            {
                return Ok($"You successfully rated {restaurant.Name}");
            }

            return InternalServerError();
        }

        //R
        [HttpGet]
        public async Task<IHttpActionResult> GetAll()
        {
            List<RatingDisplay> ratings = await 
                _context
                .Ratings
                .Select(r => new RatingDisplay
                {
                    Id = r.Id,
                    FoodScore = r.FoodScore,
                    AtmosphereScore = r.AtmosphereScore,
                    CleanlinessScore = r.CleanlinessScore,
                    Restaurant = new RestaurantListItem
                    {
                        Id = r.Restaurant.Id,
                        Name = r.Restaurant.Name,
                        Location = r.Restaurant.Location
                    }
                })
                .ToListAsync();
            return Ok(ratings);
        }
        //R Id
        [HttpGet]
        public async Task<IHttpActionResult> GetById(int id)
        {
            Rating rating = await _context
                .Ratings
                .FirstOrDefaultAsync(
                r =>
                r.Id == id);

            if(rating != null)
            {
                RatingDisplay display = new RatingDisplay
                {
                    Id = rating.Id,
                    FoodScore = rating.FoodScore,
                    AtmosphereScore = rating.AtmosphereScore,
                    CleanlinessScore = rating.CleanlinessScore,
                    Restaurant = new RestaurantListItem
                    {
                        Id = rating.Restaurant.Id,
                        Name = rating.Restaurant.Name,
                        Location = rating.Restaurant.Location,
                    }
                };
                return Ok(display);
            }
            return NotFound();
        }

        //U
        [HttpPut]
        public async Task<IHttpActionResult> UpdateRating([FromUri] int id, [FromBody] Rating updatedRating)
        {
            if (ModelState.IsValid)
            {
                Rating oldrating = await _context.Ratings.FindAsync(id);

                if (oldrating != null)
                {
                    oldrating.AtmosphereScore = updatedRating.AtmosphereScore;
                    oldrating.CleanlinessScore = updatedRating.CleanlinessScore;
                    oldrating.FoodScore = updatedRating.FoodScore;
                    await _context.SaveChangesAsync();
                    return Ok("Rating Updated");
                }
                return NotFound();
            }
            return BadRequest();
        }
        //D
        [HttpDelete]
        public async Task<IHttpActionResult> DeleteById(int id)
        {
            var rating = await _context.Ratings.FindAsync(id);
            if (rating == null)
            {
                return NotFound();
            }
            _context.Ratings.Remove(rating);

            if (await _context.SaveChangesAsync() == 1)
            {
                return Ok("The rating was deleted");
            }
            return InternalServerError();
        }
    }
}
