using Microsoft.EntityFrameworkCore;
using PlacesBackEnd.DTO;
using PlacesDB;
using PlacesDB.Models;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

RouteGroupBuilder users = app.MapGroup("/users");
users.MapGet("/", GetAllUsers);
users.MapGet("/{id}", GetUserById);
users.MapPost("/", CreateUser);
users.MapPut("/{id}", UpdateUser);
users.MapDelete("/{id}", DeleteUser);


app.Run();

static async Task<IResult> GetAllUsers()
{
    using (var db = new Context())
    {
        return TypedResults.Ok(await db.Users.Select(x => new UserDTO(x)).ToListAsync());
    }
}


static async Task<IResult> GetUserById(int id)
{
    using (var db = new Context())
    {
        return await db.Users.FindAsync(id)
            is User user
                ? TypedResults.Ok(new UserDTO(user))
                : TypedResults.NotFound();
    }

}

static async Task<IResult> CreateUser(UserDTO userDTO)
{
    using (var db = new Context())
    {
        var user = new User
        {
            FirstName = userDTO.FirstName,
            LastName = userDTO.LastName,
            Username = userDTO.Username,
            Email = userDTO.Email,
            Password = Hasher.HashPassword(userDTO.Password, Hasher.GenerateSalt()),
            DateOfBirth = userDTO.DateOfBirth,
        };
        db.Users.Add(user);
        await db.SaveChangesAsync();

        return TypedResults.Created($"/user/{user.Id}", userDTO);

    }

}


static async Task<IResult> UpdateUser(int id, UserDTO userDTO)
{
    using (var db = new Context())
    {
        var user = await db.Users.FindAsync(id);
        
        if (user is null) return TypedResults.NotFound();

        user.FirstName = userDTO.FirstName == "string" ? user.FirstName : userDTO.FirstName;
        user.LastName = userDTO.LastName == "string" ? user.LastName : userDTO.LastName;
        user.Username = userDTO.Username == "string" ? user.Username : userDTO.Username;
        user.Email = userDTO.Email == "string" ? user.Email : userDTO.Email;
        user.Password = Hasher.HashPassword(userDTO.Password == "string" ? user.Password : user.Password, Hasher.GenerateSalt());

        await db.SaveChangesAsync();

        return TypedResults.NoContent();       
    }
}

static async Task<IResult> DeleteUser(int id)
{
    using (var db = new Context())
    {
        if (await db.Users.FindAsync(id) is User user)
        {
            db.Users.Remove(user);
            await db.SaveChangesAsync();
            return TypedResults.Ok(user);
        }

        return TypedResults.NotFound();
    }
}