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
        public List<(string , string , bool)> Comments { get; set; }
        public LocationDTO? Location { get; set; }
        
        public EventDTO()
        {
        }

        public EventDTO(Event @event)
        {
            using (var db = new Context())
            {
                //Geting Review info into Comments tuple
                var comments = db.Reviews.Where(x => x.Event.Id == @event.Id).Select(x => new { x.User.Username, x.Comment, x.Like }).ToList();

                var locations = (from e in db.Events
                                 where e.Id == @event.Id
                                 join l in db.Locations on e.Location.Id equals l.Id
                                 join c in db.Cities on l.City.Id equals c.Id
                                 join r in db.Countries on c.Country.Id equals r.Id
                                 select new { l.Name, l.Address, l.Latitude, l.Longitude, l.City }).FirstOrDefault();

                var likes = comments.Where(x => x.Like == true).Count();

                Title = @event.Title;
                Description = @event.Description;
                Image = @event.Image;
                Planned = @event.Planned;
                Likes = likes;
                Comments = comments.Select(x => (x.Username, x.Comment, x.Like)).ToList();

                Location = new LocationDTO();
            }
        }
    }
}