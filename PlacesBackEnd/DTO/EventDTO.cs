using PlacesBackEnd.CRUD;
using PlacesDB.Models;
using System.Text.Json.Serialization;

namespace PlacesBackEnd.DTO
{
    public class EventDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }
        public float? Rating { get; set; }

        public EventDTO () { }
        public EventDTO(Event @event) =>
            (Title, Description, Image, Rating) = (@event.Title, @event.Description, @event.Image, @event.Rating);
    }
}
