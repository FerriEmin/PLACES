using Microsoft.EntityFrameworkCore;
using PlacesBackEnd.DTO;
using PlacesDB.Models;
using PlacesDB;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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



                    if (user == null || location == null)
                        return TypedResults.StatusCode(500);

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
                        User = user,
                        Category = newcat
                    };

                    await db.Events.AddAsync(_event);

                    await db.SaveChangesAsync();

                    return TypedResults.StatusCode(200);
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

        public static async Task<IResult> GetGroupedReviewsByUserId(int userId)
        {
            using (var db = new Context())
            {
                var grouped = (from e in db.Events
                               where e.User.Id == userId
                               join c in db.Reviews on e.Id equals c.Event.Id
                               select new { Title = e.Title, Image = e.Image, Likes = e.Reviews.Where(x => x.Like == true).Count(), Comment = c.Comment }).ToList();

                    return TypedResults.Ok(grouped);
            };

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
