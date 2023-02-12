using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using PlacesBackEnd;
using PlacesBackEnd.CRUD;
using PlacesBackEnd.DTO;
using PlacesDB.Models;
using System.Security.Claims;
using System.Text;


var corsPolicy = "_myCorsPolicy";
var builder = WebApplication.CreateBuilder(args);


builder.Services.AddCors(options =>
{
    options.AddPolicy(name: corsPolicy,
        policy =>
        {
            policy.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
        });
});


// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateActor = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))

    };
});
builder.Services.AddAuthorization();

var app = builder.Build();

app.UseAuthorization();
app.UseAuthentication();

// Set cors policy
app.UseCors(corsPolicy);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Authentication Endpoints
RouteGroupBuilder auth = app.MapGroup("/auth");
auth.MapPost("/login", async (UserLoginDTO details) => { return await Auth.Login(details, builder); });

// USER ENDPOINTS
RouteGroupBuilder users = app.MapGroup("/users");
users.MapGet("/", UserCRUD.GetAllUsers);
users.MapGet("/{id}", UserCRUD.GetUserById);
users.MapPost("/", UserCRUD.CreateUser);
users.MapPut("/{id}", UserCRUD.UpdateUser);
users.MapDelete("/{id}", UserCRUD.DeleteUser);
//////

////// CITY ENDPOINTS
RouteGroupBuilder cities = app.MapGroup("/cities");
cities.MapGet("/", CityCRUD.GetAllCitys);
cities.MapGet("/{id}", CityCRUD.GetCityById);
cities.MapPost("/", CityCRUD.CreateCity);
cities.MapPut("/{id}", CityCRUD.UpdateCity);
cities.MapDelete("/{id}", CityCRUD.DeleteCity);

////// EVENT ENDPOINTS
RouteGroupBuilder events = app.MapGroup("/events");
events.MapGet("/", EventCRUD.GetAllEvents);
events.MapGet("/{id}", EventCRUD.GetEventById);
events.MapGet("/location/{locationid}", EventCRUD.GetEventsByLocationId);
events.MapPost("/", EventCRUD.CreateEvent);
events.MapPut("/{id}", EventCRUD.UpdateEvent);
events.MapDelete("/{id}", EventCRUD.DeleteEvent);
//////

////// CATEGORY ENDPOINTS
RouteGroupBuilder categories = app.MapGroup("/categories");
categories.MapGet("/", CategoryCRUD.GetAllCategories);
categories.MapGet("/{id}", CategoryCRUD.GetCategoryById);
categories.MapPost("/", CategoryCRUD.CreateCategory);
categories.MapPut("/{id}", CategoryCRUD.UpdateCategory);
categories.MapDelete("/{id}", CategoryCRUD.DeleteCategory);
//////

////// LOCATION ENDPOINTS
RouteGroupBuilder locations = app.MapGroup("/locations");
locations.MapGet("/", LocationCRUD.GetAllLocations);
locations.MapGet("/{id}", LocationCRUD.GetLocationById);
locations.MapPost("/", LocationCRUD.CreateLocation);
locations.MapPut("/{id}", LocationCRUD.UpdateLocation);
locations.MapDelete("/{id}", LocationCRUD.DeleteLocation);

// Availability check
RouteGroupBuilder check = app.MapGroup("/check");
check.MapGet("/username/{username}", Check.CheckUsernameAvailable);

app.Run();