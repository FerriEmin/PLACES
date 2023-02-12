using PlacesBackEnd.DTO;
using PlacesDB.Models;
using PlacesDB;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

namespace PlacesBackEnd.CRUD
{
    public class LocationCRUD
    {
        public static async Task<IResult> GetAllLocations()
        {
            try
            {
                using (var db = new Context())
                {
                    return TypedResults.Ok(await db.Locations.Select(x => new LocationDTO(x)).ToListAsync());
                }

            }
            catch (Exception)
            {
                return TypedResults.StatusCode(500);
            }

        }

        public static async Task<IResult> GetLocationById(int id)
        {
            try
            {
                using (var db = new Context())
                {
                  return await db.Locations.FindAsync(id)
                        is Location location
                            ? TypedResults.Ok(new LocationDTO(location))
                            : TypedResults.NotFound();
                }
            }
            catch (Exception)
            {
                return TypedResults.StatusCode(500);
            }


        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public static async Task<IResult> CreateLocation(LocationDTO locationDTO)
        {
            try
            {
                using (var db = new Context())
                {
                    var location = new Location
                    {
                        Name = locationDTO.Name,
                        Address= locationDTO.Address,
                        Longitude= locationDTO.Longitude,
                        Latitude= locationDTO.Latitude,
                    };
                    db.Locations.Add(location);
                    await db.SaveChangesAsync();

                    return TypedResults.Created($"/user/{location.Id}", locationDTO);
                }   
            }
            catch (Exception)
            {
                return TypedResults.StatusCode(500);
            }
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public static async Task<IResult> UpdateLocation(int id, LocationDTO locationDTO)
        {
            try
            {
                using (var db = new Context())
                {
                    var location = await db.Locations.FindAsync(id);

                    if (location is null) return TypedResults.NotFound();

                    location.Name = locationDTO.Name == "string" ? location.Name : location.Name;
                    location.Address = locationDTO.Address == "string" ? location.Address : locationDTO.Address;
                    location.Longitude = locationDTO.Longitude;
                    location.Latitude = locationDTO.Latitude;

                    await db.SaveChangesAsync();

                    return TypedResults.Ok();
                }   
            }
            catch (Exception)
            {
                return TypedResults.StatusCode(500);
            }
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public static async Task<IResult> DeleteLocation(int id)
        {
            try
            {
                using (var db = new Context())
                {
                    if (await db.Locations.FindAsync(id) is Location location)
                    {
                        db.Locations.Remove(location);
                        await db.SaveChangesAsync();
                        return TypedResults.Ok(location);
                    }
                    return TypedResults.NotFound();
                }
            }
            catch (Exception)
            {
                return TypedResults.StatusCode(500);
            }    
        }
    }
}
