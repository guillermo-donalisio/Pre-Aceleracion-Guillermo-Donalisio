using Api_Disney.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// Configure Swagger Authorization
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddSwaggerGen(o =>
{
    o.SwaggerDoc("v1", new OpenApiInfo { Title = "Pre-Aceleracion Guillermo Donalisio", Version = "v1" });
});

// Create Database SQL SERVER
var disneyConn = builder.Configuration.GetConnectionString("DisneyConnection");
builder.Services.AddDbContext<DisneyContext>(x => x.UseSqlServer(disneyConn));

var userConn = builder.Configuration.GetConnectionString("UserConnection");
builder.Services.AddDbContext<UserContext>(x => x.UseSqlServer(userConn));

// Build API
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Authentication & Authorization
//app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
