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

        public EventDTO () { }
        public EventDTO(Event @event) =>
            (Title, Description, Image, Likes) = (@event.Title, @event.Description, @event.Image, @event.Reviews.Where(x => x.Like == true).Count());
    }
}
