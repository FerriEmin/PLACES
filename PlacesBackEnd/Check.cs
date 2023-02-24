using Microsoft.EntityFrameworkCore;
using PlacesDB.Models;

namespace PlacesBackEnd
{
    public class Check
    {
        public static async Task<IResult> CheckUsernameAvailable(string username)
        {
            using var db = new Context();
            if (await db.Users.Where(x => x.Username == username).AnyAsync())
                return TypedResults.Ok(new { taken = true });

            return TypedResults.Ok(new { taken = false });
        }
    }
}
