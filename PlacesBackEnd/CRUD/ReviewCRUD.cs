using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
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
                var grouped = (from e in db.Events
                               where e.User.Id == userId
                               join c in db.Reviews on e.Id equals c.Event.Id
                               select new { Title = e.Title, Image = e.Image, Likes = e.Reviews.Where(x => x.Like == true).Count(), Comment = c.Comment }).ToList();

                return TypedResults.Ok(grouped);
            };

        }
    }
}
