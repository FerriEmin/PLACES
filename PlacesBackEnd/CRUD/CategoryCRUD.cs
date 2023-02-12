using PlacesBackEnd.DTO;
using PlacesDB.Models;
using PlacesDB;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

namespace PlacesBackEnd.CRUD
{
    public class CategoryCRUD
    {
        public static async Task<IResult> GetAllCategories()
        {
            try
            {
                using (var db = new Context())
                {
                    return TypedResults.Ok(await db.Categories.ToListAsync());
                }

            }
            catch (Exception)
            {

                return TypedResults.StatusCode(500);
            }

        }

        public static async Task<IResult> GetCategoryById(int id)
        {
            try
            {
                using (var db = new Context())
                {
                    return await db.Categories.FindAsync(id)
                        is Category category
                            ? TypedResults.Ok(category)
                            : TypedResults.NotFound();
                }

            }
            catch (Exception)
            {

                return TypedResults.StatusCode(500);
            }

        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public static async Task<IResult> CreateCategory(CategoryDTO categoryDTO)
        {
            try
            {
                using (var db = new Context())
                {
                    var category = new Category { Name = categoryDTO.Name };
                    
                    db.Categories.Add(category);
                    await db.SaveChangesAsync();

                    return TypedResults.Created($"/categories/{category.Id}", categoryDTO);
                }

            }
            catch (Exception)
            {
                return TypedResults.StatusCode(500);
            }


        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public static async Task<IResult> UpdateCategory(int id, CategoryDTO categoryDTO)
        {
            try
            {
                using (var db = new Context())
                {
                    var category = await db.Categories.FindAsync(id);

                    if (category is null) return TypedResults.NotFound();

                    category.Name = categoryDTO.Name == "string" ? category.Name : categoryDTO.Name; ;

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
        public static async Task<IResult> DeleteCategory(int id)
        {
            try
            {
                using (var db = new Context())
                {
                    if (await db.Categories.FindAsync(id) is Category category)
                    {
                        db.Categories.Remove(category);
                        await db.SaveChangesAsync();
                        return TypedResults.Ok(category);
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
