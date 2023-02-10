using Microsoft.EntityFrameworkCore;
using PlacesBackEnd.DTO;
using PlacesDB.Models;

namespace PlacesBackEnd.CRUD
{
    public class ReviewCRUD
    {
        public static async Task<IResult> CreateReview(ReviewDTO reviewDTO, int userId, int eventId)
        {

            using (var db = new Context())
            {
                var userRes = await db.Users.Where(x => x.Id == userId).FirstOrDefaultAsync();
                if (userRes == null) 
                    return TypedResults.NotFound("U are not logged in");


                var eventRes = await db.Events.Where(x => x.Id == eventId).FirstOrDefaultAsync();
                if (eventRes == null)
                    return TypedResults.NotFound("No event matches that id");

                await db.AddAsync(new Review()
                {
                    Like = reviewDTO.Like,
                    Comment= reviewDTO.Comment,
                    Event = eventRes,
                    User= userRes
                    
                });
                await db.SaveChangesAsync();

                return TypedResults.Ok(new { message = "Created!" });
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
