using Microsoft.EntityFrameworkCore;
using PlacesBackEnd.DTO;
using PlacesDB;
using PlacesDB.Models;
using PlacesBackEnd.CRUD;

const string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors((options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      builder =>
                      {
                          builder.WithOrigins("http://localhost:3000").AllowAnyHeader().AllowAnyMethod();
                      });
}));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(MyAllowSpecificOrigins);

app.UseHttpsRedirection();

////// USER ENDPOINTS
RouteGroupBuilder users = app.MapGroup("/users");
users.MapGet("/", UserCRUD.GetAllUsers);
users.MapGet("/{id}", UserCRUD.GetUserById);
users.MapPost("/", UserCRUD.CreateUser);
users.MapPut("/{id}", UserCRUD.UpdateUser);
users.MapDelete("/{id}", UserCRUD.DeleteUser);
//////

////// CATEGORY ENDPOINTS
RouteGroupBuilder categories = app.MapGroup("/categories");
categories.MapGet("/", CategoryCRUD.GetAllCategories);
categories.MapGet("/{id}", CategoryCRUD.GetCategoryById);
categories.MapPost("/", CategoryCRUD.CreateCategory);
categories.MapPut("/{id}", CategoryCRUD.UpdateCategory);
categories.MapDelete("/{id}", CategoryCRUD.DeleteCategory);

app.Run();