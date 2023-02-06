using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualBasic;
using PlacesBackEnd.DTO;
using PlacesDB.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PlacesBackEnd
{
    public class Auth
    {
        public static async Task<IResult> Login(UserLoginDTO details, WebApplicationBuilder builder)
        {
            try
            {
                using var db = new Context();
                var user = await db.Users.Where(x => x.Username == details.Username).FirstOrDefaultAsync();

                // Check that user exist
                if (user is null) return TypedResults.NotFound("User not found");

                // Verify password
                if (!Hasher.PasswordVerify(details.Password, user.Password))
                    return TypedResults.Unauthorized();

                // Issue a security token
                var claims = new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, details.Username),
                };

                var token = new JwtSecurityToken
                    (
                        issuer: builder.Configuration["Jwt:Issuer"],
                        audience: builder.Configuration["Jwt:Audience"],
                        claims: claims,
                        expires: DateTime.UtcNow.AddMinutes(30),
                        notBefore: DateTime.UtcNow,
                        signingCredentials: new SigningCredentials(
                            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),
                            SecurityAlgorithms.HmacSha256)
                    );

                var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
                return TypedResults.Ok(tokenString);

            }
            catch (Exception)
            {

            }
            return TypedResults.Ok(new {msg = "Successfully logged in!"});
        }
    }
}
