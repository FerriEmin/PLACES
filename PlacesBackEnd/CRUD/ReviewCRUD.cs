using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PlacesBackEnd.DTO;
using PlacesDB.Models;

namespace PlacesBackEnd.CRUD
{
    public class ReviewCRUD
    {
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public static async Task<IResult> CreateReview(ReviewDTO reviewDTO, int eventId, HttpContext httpContext)
        {
            using (var db = new Context())
            {

                var user = Auth.GetUserFromIdentity(httpContext);
                var newUser = await db.Users.FirstOrDefaultAsync(x => x.Id == user.Id);

                // Check that user exist
                if (newUser is null) return TypedResults.NotFound(new { msg = "User not found!" });

                //using var db = new Context();
                var eventRes = await db.Events.Where(x => x.Id == eventId).FirstOrDefaultAsync();
                if (eventRes == null) return TypedResults.NotFound("No event matches that id");

                await db.AddAsync(new Review()
                {
                    Like = reviewDTO.Like,
                    Comment = reviewDTO.Comment,
                    Event = eventRes,
                    User = newUser

                });
                await db.SaveChangesAsync();
                return TypedResults.Ok();

            }
            
        }


        public static async Task<IResult> GetGroupedReviewsByUserId(int userId)
        {
           
            using (var db = new Context())
            {
                var events = db.Events
                        .Include(e => e.User)
                        .Include(e => e.Category)
                        .Include(e => e.Location)
                        .Include(e => e.Location.City)
                        .Include(e => e.Location.City.Country)
                        .Include(e => e.Location.Country)
                        .Include(e => e.Reviews)
                        .Where(e => e.Reviews.Any(r => r.User.Id == userId))
                        .ToList();
                
                return TypedResults.Ok(events);
            };

        }
    }
}
