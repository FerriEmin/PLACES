using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using PlacesBackEnd;
using PlacesBackEnd.CRUD;
using PlacesBackEnd.DTO;
using System.Net;
using System.Text;
using System.Security.Claims;
using System.Reflection.Metadata.Ecma335;

var builder = WebApplication.CreateBuilder(args);
var corsPolicy = "_myCorsPolicy";

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
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => {
    options.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme."
    });
    options.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
                {
                    {
                        new Microsoft.OpenApi.Models.OpenApiSecurityScheme {
                            Reference = new Microsoft.OpenApi.Models.OpenApiReference {
                            Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    new string[] {}
                }
            });
});

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

app.UseCors(corsPolicy);
app.UseAuthentication();
app.UseAuthorization();


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
users.MapGet("/", UserCRUD.GetAllUsers).RequireAuthorization();
users.MapGet("/{id}", UserCRUD.GetUserById);
users.MapPost("/", UserCRUD.CreateUser);
users.MapPut("/{id}", UserCRUD.UpdateUser);
users.MapPut("/password/update", UserCRUD.UpdatePassword);
users.MapDelete("/{id}", UserCRUD.DeleteUser);
//////

////// EVENT ENDPOINTS
RouteGroupBuilder events = app.MapGroup("/events");
events.MapGet("/", EventCRUD.GetAllEvents);
events.MapGet("/{id}", EventCRUD.GetEventById);
events.MapGet("/location/{id}", EventCRUD.GetEventsByLocationId);
events.MapGet("/user/{userId}", EventCRUD.GetEventsByUserId);
events.MapGet("/city/{cityId}", EventCRUD.GetEventsByCity);
events.MapGet("/favorites/{userId}", EventCRUD.GetUserFavoriteEvents);
events.MapGet("/reviewed/{userId}", EventCRUD.GetUserReviewedEvents);


events.MapPost("/", EventCRUD.CreateEvent);
events.MapPut("/{id}", EventCRUD.UpdateEvent);
events.MapDelete("/{id}", EventCRUD.DeleteEvent);
//////

////// REVIEW ENDPOINTS
RouteGroupBuilder reviews = app.MapGroup("/reviews");
reviews.MapPost("/{id}", ReviewCRUD.CreateReview);
reviews.MapGet("/{userId}", ReviewCRUD.GetGroupedReviewsByUserId);
reviews.MapGet("/event/{eventId}", ReviewCRUD.GetReviewsByEventId);
reviews.MapPut("/user/{userId}", ReviewCRUD.UpdateReview);
//////


////// CITY ENDPOINTS
RouteGroupBuilder cities = app.MapGroup("/cities");
cities.MapGet("/", CityCRUD.GetAllCities);
cities.MapGet("/{id}", CityCRUD.GetCityById);


// Availability check
RouteGroupBuilder check = app.MapGroup("/check");
check.MapGet("/username/{username}", Check.CheckUsernameAvailable);

app.Run();