using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PlacesDB.Models;

namespace PlacesBackEnd.DTO
{
    public class EventDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public DateTime? Planned { get; set; } = DateTime.Now;
        public int Likes { get; set; }
        public List<CommentDTO> Comments { get; set; }
        public LocationDTO Location { get; set; }

        public EventDTO()
        {
        }

        public EventDTO(Event @event)
        {
            using var db = new Context();
            var comments = (from r in db.Reviews.Include(x => x.User)
                            where r.Event.Id == @event.Id
                            select new CommentDTO()
                            {
                                ReviewId = r.Id,
                                Username = r.User.Username,
                                Comment = r.Comment,
                                Liked = r.Like,
                                Date = r.Created
                            }).ToList();

            var likes = comments.Where(x => x.Liked == true).Count();

            Id = @event.Id;
            Title = @event.Title;
            Description = @event.Description;
            Image = @event.Image;
            Likes = 0;
            Comments = comments.Where(x => !x.Comment.IsNullOrEmpty()).ToList();
            Planned = @event.Planned;
            Location = new LocationDTO(@event.Location);
        }
    }
}