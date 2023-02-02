using Microsoft.EntityFrameworkCore;
using PlacesBackEnd.DTO;
using PlacesDB;
using PlacesDB.Models;
using PlacesBackEnd.CRUD;
using PlacesBackEnd;
using Microsoft.AspNetCore.Mvc;

var corsPolicy = "_myAllowSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);


builder.Services.AddCors(options =>
{
    options.AddPolicy(name: corsPolicy,
        policy => { 
            policy.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
        });
});


// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



var app = builder.Build();

// Set cors policy
app.UseCors(corsPolicy);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(corsPolicy);

app.UseHttpsRedirection();

// Authentication Endpoints
RouteGroupBuilder auth = app.MapGroup("/auth");
auth.MapPost("/login", Auth.Login);

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

app.Run();