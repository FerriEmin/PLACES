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
        public List<(string, string, bool)> Comments { get; set; }
        public LocationDTO Location { get; set; }

        public EventDTO()
        {
        }

        public EventDTO(Event @event)
        {
            using (var db = new Context())
            {

                //var comments = (from r in @event.Reviews select (r.User.Username, r.Comment, r.Like)).ToList();
                //var likes = comments.Where(x => x.Like == true).Count();
                Id = @event.Id;

                Title = @event.Title;
                Description = @event.Description;
                Image = @event.Image;
                Likes = 0;
                Comments = new List<(string, string, bool)>();
                Planned = @event.Planned;
                Location = new LocationDTO(@event.Location);
            }
        }
    }
}