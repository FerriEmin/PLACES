using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public static async Task<IResult> GetUserById(int id, HttpContext httpContext)
        {
            using (var db = new Context())
            {
                var userAuth = Auth.GetUserFromIdentity(httpContext);

                if(userAuth.Id == id)
                {
                    return TypedResults.Ok(new UserDTO(userAuth));
                }

                return TypedResults.Unauthorized();
            }

        }

        public static async Task<IResult> CreateUser(UserDTO userDTO)
        {
            try
            {
                // Check if username is available
                using var db = new Context();

                if (await UsernameTaken(userDTO.Username))
                    return TypedResults.BadRequest(new { msg = "Username already taken!" });

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

                // Check username
                if (await UsernameTaken(userDTO.Username))
                    return TypedResults.BadRequest(new { msg = "Username already taken!" });

                using var db = new Context();

                user.FirstName = userDTO.FirstName;
                user.LastName = userDTO.LastName;
                user.Username = userDTO.Username;
                user.Email = userDTO.Email;

                await db.SaveChangesAsync();
                return TypedResults.Ok(new { msg = "User updated!" });
            }
            catch (Exception ex)
            {
                return TypedResults.StatusCode(500);
            }
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public static async Task<IResult> DeleteUser(int id, HttpContext httpContext)
        {
            try
            {
                var user = Auth.GetUserFromIdentity(httpContext);

                // Check that user exist
                if (user is null) return TypedResults.NotFound(new { msg = "User not found!" });

                // Only admin can delete any user
                if (user.UserGroup == 0 && user.Id != id) return TypedResults.Unauthorized();

                using var db = new Context();
                db.Users.Remove(user);
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
                    return TypedResults.Unauthorized();

                using var db = new Context();
                user.Password = Hasher.HashPassword(details.newPassword, Hasher.GenerateSalt());
                await db.SaveChangesAsync();
                return TypedResults.Ok();
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
