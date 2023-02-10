using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using PlacesBackEnd.DTO;
using PlacesDB.Models;

namespace PlacesBackEnd
{
    public class Auth
    {
        public static async Task<IResult> Login(UserLoginDTO details)
        {
            try
            {
                using var db = new Context();
                var user = await db.Users.Where(x => x.Username == details.Username).FirstOrDefaultAsync();

                // Check that user exist
                if (user is null) { Console.WriteLine("No user found");  return TypedResults.Unauthorized(); }

                // Verify password
                if (!Hasher.PasswordVerify(details.Password, user.Password))
                {
                    Console.WriteLine("Incorrect Password");
                    return TypedResults.Unauthorized();
                }

                // Issue a security token
            }
            catch (Exception)
            {

            }
            return TypedResults.Ok(new {msg = "Successfully logged in!"});
        }
    }
}
