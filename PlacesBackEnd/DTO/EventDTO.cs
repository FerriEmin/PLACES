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
        public int Likes { get; set; }
        public string Country { get; set; }
        public string Address { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }

        public List<(string, string)> Comments { get; set; }

        public EventDTO () { }
        public EventDTO(Event @event) =>
            (
            Title,
            Description,
            Image,
            Likes,
            Comments
            ) =
            (
            @event.Title,
            @event.Description,
            @event.Image,
            @event.Reviews.Where(x => x.Like == true).Count(),
            @event.Reviews.Select(x => (x.User.Username, x.Comment)).ToList()
            );
    }
}