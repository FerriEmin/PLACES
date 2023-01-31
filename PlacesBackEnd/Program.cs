using Microsoft.EntityFrameworkCore;
using PlacesBackEnd.DTO;
using PlacesDB;
using PlacesDB.Models;
using PlacesBackEnd.CRUD;
using PlacesBackEnd;

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
builder.Services.AddCors((options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      builder =>
                      {
                          builder.WithOrigins("http://localhost:3000").AllowAnyHeader().AllowAnyMethod();
                      });
}));



var app = builder.Build();

// Set cors policy
app.UseCors(corsPolicy);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(MyAllowSpecificOrigins);

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

// CATEGORY ENDPOINTS
RouteGroupBuilder categories = app.MapGroup("/categories");
categories.MapGet("/", CategoryCRUD.GetAllCategories);
categories.MapGet("/{id}", CategoryCRUD.GetCategoryById);
categories.MapPost("/", CategoryCRUD.CreateCategory);
categories.MapPut("/{id}", CategoryCRUD.UpdateCategory);
categories.MapDelete("/{id}", CategoryCRUD.DeleteCategory);

app.Run();