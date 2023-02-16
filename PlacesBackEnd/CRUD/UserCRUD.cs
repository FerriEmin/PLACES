using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using PlacesBackEnd.DTO;
using PlacesDB.Models;

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
            using var db = new Context();
            var user = db.Users.Where(x => x.Id == id).FirstOrDefault();
            return (user is null) ? TypedResults.NotFound() : TypedResults.Ok(new UserDTO(user));

        }

        public static async Task<IResult> CreateUser(UserDTO userDTO)
        {
            try
            {
                // Check if username is available
                using var db = new Context();

                if (await UsernameTaken(userDTO.Username))
                    return TypedResults.BadRequest(new { msg = "Username already taken!" });

                Console.WriteLine(userDTO.Password);

                await db.AddAsync(new User()
                {
                    UserGroup = 0,
                    FirstName = userDTO.FirstName,
                    LastName = userDTO.LastName,
                    ProfileImage = userDTO.ProfileImage,
                    Email = userDTO.Email,
                    Username = userDTO.Username,
                    Password = Hasher.HashPassword(userDTO.Password, Hasher.GenerateSalt()),
                    DateOfBirth = userDTO.DateOfBirth,
                    Created = DateTime.UtcNow
                });

                await db.SaveChangesAsync();

                return TypedResults.Ok(new { message = "Created!" });
            }
            catch (Exception ex)
            {
                return TypedResults.StatusCode(500);
            }
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public static async Task<IResult> UpdateUser(int id, UserDTO userDTO, HttpContext httpContext)
        {
            try
            {
                var user = Auth.GetUserFromIdentity(httpContext);

                // Check that user exist
                if (user is null) return TypedResults.NotFound(new { msg = "User not found!" });

                // Only admin can edit any user
                if (user.UserGroup == 0 && user.Id != id) return TypedResults.Unauthorized();

                // Check if username edited
                if (userDTO.Username != user.Username)
                {
                    // Check username
                    if (await UsernameTaken(userDTO.Username))
                        return TypedResults.BadRequest(new { msg = "Username already taken!" });
                }

                using var db = new Context();
                User toBeUpdate = db.Users.Where(u => u.Id == id).FirstOrDefault();
                toBeUpdate.FirstName = userDTO.FirstName;
                toBeUpdate.LastName = userDTO.LastName;
                toBeUpdate.Username = userDTO.Username;
                toBeUpdate.Email = userDTO.Email;

                await db.SaveChangesAsync();
                return TypedResults.Ok(new { msg = "User updated!" });
            }
            catch (Exception ex)
            {
                return TypedResults.StatusCode(500);
            }
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public static async Task<IResult> DeleteUser(HttpContext httpContext)
        {
            try
            {
                var user = Auth.GetUserFromIdentity(httpContext);

                // Check that user exist
                if (user is null) return TypedResults.NotFound(new { msg = "User not found!" });

                using var db = new Context();
                var oldUser = db.Users.Where(x => x.Id == user.Id).FirstOrDefault();
                db.Reviews.Remove(db.Reviews.Include(x => x.User).Where(x => x.User.Id == oldUser.Id).FirstOrDefault());
                db.Events.Remove(db.Events.Include(x => x.User).Where(x => x.User.Id == oldUser.Id).FirstOrDefault());
                db.Users.Remove(oldUser);
                await db.SaveChangesAsync();
                return TypedResults.Ok(user);
            }
            catch (Exception ex)
            {
                return TypedResults.StatusCode(500);
            }
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public static async Task<IResult> UpdatePassword(UserPasswordDTO details, HttpContext httpContext)
        {
            try
            {
                var user = Auth.GetUserFromIdentity(httpContext);

                // Check that user exist
                if (user is null) return TypedResults.NotFound(new { msg = "User not found!" });

                // Only owner of account can change password
                if (user.Id != details.userId) return TypedResults.Unauthorized();

                // Verify password
                if (!Hasher.PasswordVerify(details.currentPassword, user.Password))
                    return TypedResults.BadRequest(new { msg = "Wrong password" });

                using var db = new Context();
                db.Users.Where(x => x.Id == user.Id)
                    .FirstOrDefault()
                    .Password = Hasher.HashPassword(details.newPassword, Hasher.GenerateSalt());

                await db.SaveChangesAsync();
                return TypedResults.Ok(new {msg = "Successfully updated password"});
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
            catch (Exception ex) { }

            return true;
        }
    }
}
