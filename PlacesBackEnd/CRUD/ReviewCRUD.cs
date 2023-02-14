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
        public static async Task<IResult> CreateReview(ReviewDTO reviewDTO, int id, HttpContext httpContext)
        {
            using (var db = new Context())
            {
                var user = Auth.GetUserFromIdentity(httpContext);

                // Check that user exist
                if (user is null) return TypedResults.NotFound(new { msg = "User not found!" });

                var eventRes = db.Events
                    .Where(x => x.Id == id)
                    .Include(x => x.Reviews)
                    .FirstOrDefault();

                if (eventRes == null) return TypedResults.NotFound("Event not found");


                var review = new Review()
                {
                    Like = reviewDTO.Like,
                    Comment = reviewDTO.Comment,
                    Event = eventRes,
                    User = db.Users.Where(x => x.Id == user.Id).FirstOrDefault(),
                };

                db.Reviews.Add(review);
                await db.SaveChangesAsync();
                return TypedResults.Ok();

            }
        }


        public static async Task<IResult> GetGroupedReviewsByUserId(int userId)
        {
            using (var db = new Context())
            {
                var reviews = db.Reviews
                .Include(r => r.User)
                    .Include(r => r.Event).ToList().Where(r => r.User.Id == userId).Select(r => new ReviewDTO(r)).ToList();
                if (reviews.Count == 0 || reviews is null)
                    return TypedResults.NotFound("No Reviews found");

                return TypedResults.Ok(reviews);
            };

        }
    }
}
