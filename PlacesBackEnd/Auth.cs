using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PlacesBackEnd.DTO;
using PlacesDB.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PlacesBackEnd
{
    public class Auth
    {
        public static async Task<IResult> Login(UserLoginDTO credentials, WebApplicationBuilder builder)
        {
            if (credentials.Username.IsNullOrEmpty() || credentials.Password.IsNullOrEmpty())
                return TypedResults.Unauthorized();

            // Check that user exist
            using var db = new Context();
            var user = await db.Users.Where(x => x.Username.Equals(credentials.Username)).FirstOrDefaultAsync();

            if (user is null) return TypedResults.Unauthorized();

            // Verify password
            if (!Hasher.PasswordVerify(credentials.Password, user.Password))
                return TypedResults.Unauthorized();

            // Issue a token
            var claims = new[] { new Claim("userId", user.Id.ToString()) };

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

            return TypedResults.Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });

        }

        public static User GetUserFromIdentity(HttpContext httpContext)
        {
            int id;
            var identity = httpContext.User.Identity as ClaimsIdentity;

            if (identity == null) return null;
            if (!int.TryParse(identity.Claims.Where(x => x.Type == "userId").FirstOrDefault()?.Value, out id))
                return null;

            using var db = new Context();
            return db.Users.Where(x => x.Id == id).FirstOrDefault();
        }
    }
}