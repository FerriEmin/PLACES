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

        public static async Task<IResult> GetReviewsByEventId(int eventId, HttpContext httpContext)
        {
            using (var db = new Context())
            {
                var eventRes = await db.Events.Where(x => x.Id == eventId).FirstOrDefaultAsync();
                if (eventRes == null) return TypedResults.NotFound("No event matches that id");

                var Reviews = await db.Reviews
                    .Where(x => x.Event.Id == eventId)
                    .Select(r => new ReviewDTO(r))
                    .ToListAsync();

                if (Reviews is null) return TypedResults.NotFound("No reviews found for user");

                return TypedResults.Ok(Reviews);
            }

        }

        //Give me an function updates the logged in users reviews for a specific event
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public static async Task<IResult> UpdateReview(ReviewDTO reviewDTO, int reviewId, HttpContext httpContext)
        {
            using (var db = new Context())
            {
                var user = Auth.GetUserFromIdentity(httpContext);
                var newUser = await db.Users.FirstOrDefaultAsync(x => x.Id == user.Id);

                // Check that user exist
                if (newUser is null) return TypedResults.NotFound(new { msg = "User not found!" });

                var review = await db.Reviews
                    .Include(r=> r.User)
                    .Include(r => r.Event)
                    .Where(x => x.Id == reviewId).FirstOrDefaultAsync();
                if (review == null) return TypedResults.NotFound("No review matches that id");

                if (review.User.Id != newUser.Id) return TypedResults.Unauthorized();

                review.Like = reviewDTO.Like;
                review.Comment = reviewDTO.Comment;

                await db.SaveChangesAsync();
                return TypedResults.Ok();
            }
        }




        public static async Task<IResult> GetGroupedReviewsByUserId(int userId)
        {
           
            using (var db = new Context())
            {
                
                var userRevInEvs = await db.Events
                    .Include(x => x.Reviews)
                    .ThenInclude(x => x.User)
                    .Where(x => x.Reviews.Any(y => y.User.Id == userId))
                    .Select(x => new EventDTO()
                    {
                        Id = x.Id,
                        Title = x.Title,
                        Description = x.Description,
                        Image = x.Image,
                        Planned = x.Planned,
                        Location = new LocationDTO()
                        {
                            Id = x.Location.Id,
                            Name = x.Location.Name,
                            Address = x.Location.Address,
                            Latitude = x.Location.Latitude,
                            Longitude = x.Location.Longitude,
                            City = new CityDTO()
                            {
                                Id = x.Location.City.Id,
                                Name = x.Location.City.Name,
                                Country = new CountryDTO()
                                {
                                    Id = x.Location.City.Country.Id,
                                    Name = x.Location.City.Country.Name
                                }
                            }
                        },
                        Comments = x.Reviews.Where(y => y.User.Id == userId).Select(y => new CommentDTO()
                        {
                            Username = y.User.Username,
                            Comment = y.Comment,
                            Liked = y.Like,
                            Date = y.Created
                        }).ToList()
                    }).ToListAsync();

                if (userRevInEvs is null) return TypedResults.NotFound("No reviews found for user");
                
                return TypedResults.Ok(userRevInEvs);
            };

        }
    }
}
