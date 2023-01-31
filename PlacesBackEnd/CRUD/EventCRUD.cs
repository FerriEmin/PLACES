using PlacesBackEnd.DTO;
using PlacesDB.Models;
using PlacesDB;
using Microsoft.EntityFrameworkCore;

namespace PlacesBackEnd.CRUD
{
    public class EventCRUD
    {
        public static async Task<IResult> GetAllEvents()
        {
            using (var db = new Context())
            {
                return TypedResults.Ok(await db.Events.Select(x => new EventDTO(x)).ToListAsync());
            }
        }


        public static async Task<IResult> GetEventById(int id)
        {
            using (var db = new Context())
            {
                return await db.Events.FindAsync(id)
                    is Event _event
                        ? TypedResults.Ok(new EventDTO(_event))
                        : TypedResults.NotFound();
            }

        }

        public static async Task<IResult> CreateEvent(EventDTO eventDTO)
        {
            using (var db = new Context())
            {
                var _event = new Event
                {
                    Title= eventDTO.Title,
                    Description= eventDTO.Description,
                    Image = eventDTO.Image,
                    Rating= eventDTO.Rating,
                };
                db.Events.Add(_event);
                await db.SaveChangesAsync();

                return TypedResults.Created($"/event/{_event.Id}", eventDTO);

            }

        }


        public static async Task<IResult> UpdateEvent(int id, EventDTO eventDTO)
        {
            using (var db = new Context())
            {
                var _event = await db.Events.FindAsync(id);

                if (_event is null) return TypedResults.NotFound();

                _event.Title = eventDTO.Title == "string" ? _event.Title : eventDTO.Title;
                _event.Description = eventDTO.Description == "string" ? _event.Description : eventDTO.Description;
                _event.Rating = eventDTO.Rating is null ? _event.Rating : eventDTO.Rating;

                await db.SaveChangesAsync();

                return TypedResults.NoContent();
            }
        }

        public static async Task<IResult> DeleteEvent(int id)
        {
            using (var db = new Context())
            {
                if (await db.Events.FindAsync(id) is Event _event)
                {
                    db.Events.Remove(_event);
                    await db.SaveChangesAsync();
                    return TypedResults.Ok(_event);
                }

                return TypedResults.NotFound();
            }
        }
    }
}
