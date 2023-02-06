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
            try
            {
                using (var db = new Context())
                {
                    return TypedResults.Ok(await db.Events.Select(x => new EventDTO(x)).ToListAsync());
                }
            }
            catch (Exception)
            {
                return TypedResults.StatusCode(500);
            }

        }
        


        public static async Task<IResult> GetEventById(int id)
        {
            try
            {
                using (var db = new Context())
                {
                    return await db.Events.FindAsync(id)
                        is Event _event
                            ? TypedResults.Ok(new EventDTO(_event))
                            : TypedResults.NotFound();
                }

            }
            catch (Exception)
            {
                return TypedResults.StatusCode(500);
            }
        }

        public static async Task<IResult> CreateEvent(EventDTO eventDTO)
        {
            try
            {
                using (var db = new Context())
                {
                    // Hard coded to always use this user
                    var user = await db.Users.Where(x => x.Id == 1).FirstOrDefaultAsync();
                    var location = new Location()
                    {
                        Name = eventDTO.Location.Name,
                        Address = eventDTO.Location.Address,
                        Latitude= eventDTO.Location.Latitude,
                        Longitude= eventDTO.Location.Longitude,
                    };

                    db.Locations.Add(location);

                    if (user == null || location == null)  
                        return TypedResults.StatusCode(500);
                  

                    var _event = new Event
                    {
                        Title= eventDTO.Title,
                        Description= eventDTO.Description,
                        Image = eventDTO.Image,
                        Planned= eventDTO.Planned,
                    };

                    user.Events.Add(_event);
                    location.Events.Add(_event);

                    await db.SaveChangesAsync();

                    return TypedResults.Created($"/event/{_event.Id}", eventDTO);
                }

            }
            catch (Exception)
            {
                return TypedResults.StatusCode(500);
            }


        }


        public static async Task<IResult> UpdateEvent(int id, EventDTO eventDTO)
        {
            try
            {
                using (var db = new Context())
                {
                    var _event = await db.Events.FindAsync(id);

                    if (_event is null) return TypedResults.NotFound();

                    _event.Title = eventDTO.Title == "string" ? _event.Title : eventDTO.Title;
                    _event.Description = eventDTO.Description == "string" ? _event.Description : eventDTO.Description;

                    await db.SaveChangesAsync();

                    return TypedResults.NoContent();
                }

            }
            catch (Exception)
            {
                return TypedResults.StatusCode(500);
            }

        }

        public static async Task<IResult> DeleteEvent(int id)
        {
            try
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
            catch (Exception)
            {
                return TypedResults.StatusCode(500);
            }

        }
        // Specific handlers
        public static async Task<IResult> GetEventsByLocationId(int id)
        {
            try
            {
                using (var db = new Context())
                {
                    var res = await db.Locations.Where(x => x.Id == id).FirstOrDefaultAsync();
                    if (res is null)
                    {
                        return TypedResults.NotFound();
                    }

                    var events = await db.Events.Where(x => x.Location.Id == res.Id).ToListAsync();
                    var listOfEvents = new List<EventDTO>();
                    foreach (var item in events)
                    {
                        listOfEvents.Add(new EventDTO()
                        {
                            Title = item.Title,
                            Description = item.Description,
                            Image = item.Image,
                        });
                    }
                    return TypedResults.Ok(listOfEvents);
                }
            }
            catch (Exception)
            {

                return TypedResults.StatusCode(500);
            }

        }
    }
}
