using PlacesDB.Models;

namespace PlacesBackEnd.DTO
{
    public class EventDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public DateTime? Planned { get; set; } = DateTime.Now;
        public int Likes { get; set; }
        public List<(string, string, bool)> Comments { get; set; }
        public LocationDTO Location { get; set; }

        public EventDTO()
        {
        }

        public EventDTO(Event @event)
        {
            using (var db = new Context())
            {

                var comments = (from r in @event.Reviews select (r.User.Username, r.Comment, r.Like)).ToList();
                var likes = comments.Where(x => x.Like == true).Count();

                Title = @event.Title;
                Description = @event.Description;
                Image = @event.Image;
                Planned = @event.Planned;
                Likes = likes;
                Comments = comments;
                Location = new LocationDTO(@event.Location);
            }
        }
    }
}