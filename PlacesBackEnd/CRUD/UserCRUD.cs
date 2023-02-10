using PlacesBackEnd.DTO;
using PlacesDB.Models;
using PlacesDB;
using Microsoft.EntityFrameworkCore;

namespace PlacesBackEnd.CRUD
{
    public class UserCRUD
    {
        public static async Task<IResult> GetAllUsers()
        {
            try
            {
                using var db = new Context();
                return TypedResults.Ok(await db.Users.Select(x => new UserDTO(x)).ToListAsync());
            } 
            catch (Exception ex) 
            {
                return TypedResults.StatusCode(500);
            }
        }

        public static async Task<IResult> GetUserById(int id)
        {
            try
            {
                using var db = new Context();
                return await db.Users.FindAsync(id)
                    is User user ?
                        TypedResults.Ok(new UserDTO(user)) :
                        TypedResults.NotFound();
            }
            catch (Exception ex)
            {
                return TypedResults.StatusCode(500);
            }

        }

        public static async Task<IResult> CreateUser(UserDTO userDTO)
        {
            try
            {
                // Check if username is available
                using var db = new Context();

                if (await UsernameTaken(userDTO.Username))
                    return TypedResults.BadRequest(new {msg = "Username already taken!"});

                await db.AddAsync(new User() {
                    UserGroup = 0,
                    FirstName = userDTO.FirstName,
                    LastName = userDTO.LastName,
                    ProfileImage= userDTO.ProfileImage,
                    Email = userDTO.Email,
                    Username = userDTO.Username,
                    Password = Hasher.HashPassword(userDTO.Password, Hasher.GenerateSalt()),
                    DateOfBirth = userDTO.DateOfBirth,
                    Created = DateTime.UtcNow
                });

                await db.SaveChangesAsync();

                return TypedResults.Ok(new {message = "Created!"});
            }
            catch (Exception ex)
            {
                return TypedResults.StatusCode(500);
            }
        }

        public static async Task<IResult> UpdateUser(int id, UserDTO userDTO)
        {
            try
            {
                using var db = new Context();
                var user = await db.Users.FindAsync(id);

                // Check that user exist
                if (user is null) return TypedResults.NotFound(new {msg = "User not found!"});

                // Check username
                if (await UsernameTaken(userDTO.Username))
                    return TypedResults.BadRequest(new { msg = "Username already taken!" });

                user.FirstName = userDTO.FirstName == "string" ? user.FirstName : userDTO.FirstName;
                user.LastName = userDTO.LastName == "string" ? user.LastName : userDTO.LastName;
                user.Username = userDTO.Username == "string" ? user.Username : userDTO.Username;
                user.Email = userDTO.Email == "string" ? user.Email : userDTO.Email;

                await db.SaveChangesAsync();

                    return TypedResults.Ok(new { msg = "User updated!" });
            }
            catch (Exception ex)
            {
                return TypedResults.StatusCode(500);
            }
        }

        public static async Task<IResult> DeleteUser(int id)
        {
            try
            {
                using var db = new Context();
                if (await db.Users.FindAsync(id) is User user)
                {
                    db.Users.Remove(user);
                    await db.SaveChangesAsync();
                    return TypedResults.Ok(user);
                }
                return TypedResults.NotFound();
            }
            catch (Exception ex)
            {
                return TypedResults.StatusCode(500);
            }
        }

        public static async Task<IResult> UpdatePassword(UserPasswordDTO details)
        {
            try
            {
                using var db = new Context();
                if( await db.Users.Where(x => x.Id == details.userId).FirstOrDefaultAsync() is User user)
                {
                    // Verify password
                    if (!Hasher.PasswordVerify(details.currentPassword, user.Password))
                        return TypedResults.Unauthorized();

                    user.Password = Hasher.HashPassword(details.newPassword, Hasher.GenerateSalt());
                    await db.SaveChangesAsync();
                    return TypedResults.Ok();

                }
                return TypedResults.StatusCode(404);
            }
            catch (Exception)
            {
                return TypedResults.StatusCode(500);
            }
        }

        // Helper methods
        private static async Task<bool> UsernameTaken(string username)
        {
            try
            {
                // Check if username is available
                using var db = new Context();

                if (!await db.Users.Where(x => x.Username == username).AnyAsync())
                    return false;

            }
            catch (Exception ex) {}

            return true;
        }
    }
}
