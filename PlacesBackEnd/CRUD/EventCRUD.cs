using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using PlacesBackEnd.DTO;
using PlacesDB.Models;

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
                    var events = db.Events
                        .Include(e => e.User)
                        .Include(e => e.Category)
                        .Include(e => e.Location)
                        .Include(e => e.Location.City)
                        .Include(e => e.Location.City.Country)
                        .Include(e => e.Location.Country)
                        .Include(e => e.Reviews).
                        ToList()
                        .Select(e => new EventDTO(e)).ToList();

                    return TypedResults.Ok(events);
                }
            }
            catch (Exception)
            {
                return TypedResults.StatusCode(500);
            }

        }

        public static async Task<IResult> GetEventById(int eventId)
        {
            using (var db = new Context())
            {
                var @event = db.Events
                    .Include(e => e.User)
                    .Include(e => e.Category)
                    .Include(e => e.Location)
                    .Include(e => e.Location.City)
                    .Include(e => e.Location.City.Country)
                    .Include(e => e.Location.Country)
                    .Include(e => e.Reviews).ToList().Where(x => x.Id == eventId).Select(e => new EventDTO(e)).ToList();

                if (@event.Count == 0 || @event == null)
                    return TypedResults.NotFound("No Event found");

                return TypedResults.Ok(@event);
            }
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public static async Task<IResult> CreateEvent(EventDTO eventDTO, HttpContext httpContext)
        {
            using (var db = new Context())
            {
                var user = Auth.GetUserFromIdentity(httpContext);
                var newUser = await db.Users.FirstOrDefaultAsync(x => x.Id == user.Id);

                // Check that user exist
                if (newUser is null) return TypedResults.NotFound(new { msg = "User not found!" });

                Country countryToUse;
                City cityToUse;

                //Check if countryname exists in DB
                //True: return existing country
                //False: Create new Country and it
                Country? countryRes = await db.Countries.FirstOrDefaultAsync(x => x.Name == eventDTO.Location.City.Country.Name);

                if (countryRes == null)
                {
                    Country newCountry = new Country()
                    {
                        Name = eventDTO.Location.City.Country.Name,
                        CountryCode = eventDTO.Location.City.Country.CountryCode
                    };

                    var addedCountry = await db.Countries.AddAsync(newCountry);
                    await db.SaveChangesAsync();
                    countryToUse = addedCountry.Entity;
                }
                else
                {
                    countryToUse = countryRes;
                }


                //Check if cityname exists in DB
                //True: return existing City
                //False: Create new City and return it
                City? cityRes = await db.Cities.FirstOrDefaultAsync(x => x.Name == eventDTO.Location.City.Name);

                if (cityRes == null)
                {
                    City newCity = new City()
                    {
                        Name = eventDTO.Location.City.Name,
                        Country = countryToUse
                    };

                    var addedCity = await db.Cities.AddAsync(newCity);
                    await db.SaveChangesAsync();
                    cityToUse = addedCity.Entity;
                }
                else
                {
                    cityToUse = cityRes;
                }


                var location = new Location()
                {
                    Name = eventDTO.Location.Name,
                    Address = eventDTO.Location.Address,
                    Latitude = eventDTO.Location.Latitude,
                    Longitude = eventDTO.Location.Longitude,
                    Country = countryToUse,
                    City = cityToUse,
                };

                var loc = await db.Locations.AddAsync(location);

                await db.SaveChangesAsync();

                var newloc = loc.Entity;

                if (location == null)
                    return TypedResults.NotFound("Location not found");

                Category cat = new Category()
                {
                    Name = "cat"
                };

                var category = await db.Categories.AddAsync(cat);
                await db.SaveChangesAsync();
                var newcat = category.Entity;


                var _event = new Event
                {
                    Title = eventDTO.Title,
                    Description = eventDTO.Description,
                    Image = eventDTO.Image,
                    Planned = eventDTO.Planned,
                    Location = newloc,
                    User = newUser,
                    Category = newcat
                };

                await db.Events.AddAsync(_event);

                await db.SaveChangesAsync();

                return TypedResults.Ok();
            }

        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public static async Task<IResult> UpdateEvent(int id, EventDTO eventDTO, HttpContext httpContext)
        {
            try
            {
                var user = Auth.GetUserFromIdentity(httpContext);

                // Check that user exist
                if (user is null) return TypedResults.NotFound(new { msg = "User not found!" });

                using var db = new Context();
                var _event = await db.Events.FindAsync(id);

                if (_event is null) return TypedResults.NotFound();

                // Only admins and creator of the event can edit
                if (user.UserGroup == 0 && user.Id != _event.User.Id)
                        return TypedResults.Unauthorized();

                _event.Title = eventDTO.Title == "string" ? _event.Title : eventDTO.Title;
                _event.Description = eventDTO.Description == "string" ? _event.Description : eventDTO.Description;

                await db.SaveChangesAsync();

                return TypedResults.Ok();
            }
            catch (Exception)
            {
                return TypedResults.StatusCode(500);
            }

        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public static async Task<IResult> DeleteEvent(int id, HttpContext httpContext)
        {
            try
            {
                var user = Auth.GetUserFromIdentity(httpContext);

                // Check that user exist
                if (user is null) return TypedResults.NotFound(new { msg = "User not found!" });

                using var db = new Context();
                if (await db.Events.FindAsync(id) is Event _event)
                {
                    // Only admins and creator of the event can delete
                    if (user.UserGroup == 0 && user.Id != _event.User.Id)
                        return TypedResults.Unauthorized();

                    db.Events.Remove(_event);
                    await db.SaveChangesAsync();
                    return TypedResults.Ok(_event);
                }
                return TypedResults.NotFound();
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

                    var events = await db.Events
                        .Where(x => x.Location.Id == res.Id)
                        .Include(x => x.Reviews)
                        .Include(x => x.Location.City.Country)
                        .ToListAsync();

                    var listOfEvents = new List<EventDTO>();
                    foreach (var item in events)
                        listOfEvents.Add(new EventDTO(item));

                    return TypedResults.Ok(listOfEvents);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return TypedResults.StatusCode(500);
            }

        }

        public static async Task<IResult> GetEventsByUserId(int userId)
        {
            try
            {
                using (var db = new Context())
                {
                    var res = await db.Events.Where(x => x.User.Id.Equals(userId)).FirstOrDefaultAsync();
                    if (res is null)
                    { return TypedResults.NotFound("No events found"); }
                    return TypedResults.Ok();
                }

            }
            catch (Exception)
            {
                return TypedResults.StatusCode(500);
            }
        }

    }
}
