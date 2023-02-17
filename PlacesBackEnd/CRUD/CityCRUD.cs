using PlacesBackEnd.DTO;
using PlacesDB.Models;
using PlacesDB;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

namespace PlacesBackEnd.CRUD
{
    public class CityCRUD
    {
        public static async Task<IResult> GetAllCities()
        {
            try
            {
                using (var db = new Context())
                {

                    var cities = db.Cities
                        .Include(c => c.Country)
                        .ToList()
                        .Select(x => new CityDTO(x)).ToList();


                    return TypedResults.Ok(cities);
                }
            }
            catch (Exception)
            {
                return TypedResults.StatusCode(500);
            }

        }
        public static async Task<IResult> GetCityById(int id)
        {
            try
            {
                using (var db = new Context())
                {
                    return await db.Cities.FindAsync(id)
                        is City city
                            ? TypedResults.Ok(new CityDTO(city))
                            : TypedResults.NotFound();
                }
            }
            catch (Exception)
            {
                return TypedResults.StatusCode(500);
            }
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public static async Task<IResult> CreateCity(CityDTO cityDTO)
        {
            try
            {
                using (var db = new Context())
                {
                    var city = new City
                    {
                        Name = cityDTO.Name,
                    };
                    db.Cities.Add(city);
                    await db.SaveChangesAsync();

                    return TypedResults.Created($"/cities/{city.Id}", cityDTO);

                }
            }
            catch (Exception)
            {
                return TypedResults.StatusCode(500);
            }


        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public static async Task<IResult> UpdateCity(int id, CityDTO cityDTO)
        {
            try
            {
                using (var db = new Context())
                {
                    var city = await db.Cities.FindAsync(id);

                    if (city is null) return TypedResults.NotFound();

                    city.Name = cityDTO.Name == "string" ? city.Name : cityDTO.Name;

                    await db.SaveChangesAsync();

                    return TypedResults.NoContent();
                }
            }
            catch (Exception)
            {
                return TypedResults.StatusCode(500);
            }

        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public static async Task<IResult> DeleteCity(int id)
        {
            try
            {
                using (var db = new Context())
                {
                    if (await db.Cities.FindAsync(id) is City city)
                    {
                        db.Cities.Remove(city);
                        await db.SaveChangesAsync();
                        return TypedResults.Ok(city);
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
