using PlacesBackEnd.CRUD;
using PlacesDB.Models;
using System.Text.Json.Serialization;

namespace PlacesBackEnd.DTO
{
    public class EventDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public DateTime Planned { get; set; }
        public int Likes { get; set; }
        public List<(string, string)> Comments { get; set; }
        public LocationDTO Location { get; set; }

        public EventDTO () {
        }

        public EventDTO(Event @event, bool extended)
        {
            
            (
            Title,
            Description,
            Image,
            Planned,
            Likes,
            Comments,
            Location
            ) =
            (
            @event.Title,
            @event.Description,
            @event.Image,
            @event.Planned,
            @event.Reviews.Where(x => x.Like == true).Count(),
            @event.Reviews.Select(x => (x.User.Username, x.Comment)).ToList(),
            new LocationDTO(@event.Location)
            );
        }


        public EventDTO(Event @event) =>
            (
            Title,
            Description,
            Image,
            Planned,
            Likes,
            Comments,
            Location
            ) =
            (
            @event.Title,
            @event.Description,
            @event.Image,
            @event.Planned,
            @event.Reviews.Where(x => x.Like == true).Count(),
            @event.Reviews.Select(x => (x.User.Username, x.Comment)).ToList(),
            new LocationDTO(@event.Location)
            );
    }
}