using Microsoft.EntityFrameworkCore;
using PlacesBackEnd.DTO;
using PlacesDB;
using PlacesDB.Models;
using PlacesBackEnd.CRUD;

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

////// USER ENDPOINTS
RouteGroupBuilder users = app.MapGroup("/users");
users.MapGet("/", UserCRUD.GetAllUsers);
users.MapGet("/{id}", UserCRUD.GetUserById);
users.MapPost("/", UserCRUD.CreateUser);
users.MapPut("/{id}", UserCRUD.UpdateUser);
users.MapDelete("/{id}", UserCRUD.DeleteUser);
//////


////// EVENT ENDPOINTS
RouteGroupBuilder events = app.MapGroup("/events");
events.MapGet("/", EventCRUD.GetAllEvents);
events.MapGet("/{id}", EventCRUD.GetEventById);
events.MapPost("/", EventCRUD.CreateEvent);
events.MapPut("/{id}", EventCRUD.UpdateEvent);
events.MapDelete("/{id}", EventCRUD.DeleteEvent);
//////


app.Run();