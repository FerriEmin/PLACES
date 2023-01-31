using PlacesBackEnd.DTO;
using PlacesDB.Models;
using PlacesDB;
using Microsoft.EntityFrameworkCore;

namespace PlacesBackEnd.CRUD
{
    public class CategoryCRUD
    {
        public static async Task<IResult> GetAllCategories()
        {
            using (var db = new Context())
            {
                return TypedResults.Ok(await db.Categories.ToListAsync());
            }
        }


        public static async Task<IResult> GetCategoryById(int id)
        {
            using (var db = new Context())
            {
                return await db.Categories.FindAsync(id)
                    is Category category
                        ? TypedResults.Ok(category)
                        : TypedResults.NotFound();
            }

        }

        public static async Task<IResult> CreateCategory(CategoryDTO categoryDTO)
        {
            using (var db = new Context())
            {
                var category = new Category { Name = categoryDTO.Name };
                    
                db.Categories.Add(category);
                await db.SaveChangesAsync();

                return TypedResults.Created($"/categories/{category.Id}", categoryDTO);

            }

        }


        public static async Task<IResult> UpdateCategory(int id, CategoryDTO categoryDTO)
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

        public static async Task<IResult> DeleteCategory(int id)
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
    }
}
