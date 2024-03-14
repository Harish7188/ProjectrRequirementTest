using Microsoft.EntityFrameworkCore;
using ProjectTest.Data;
using ProjectTest.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddDbContext<DbContextClass>();
builder.Services.AddDbContext<DbContextClass>(options =>
        options.UseInMemoryDatabase("DbStoredTest")); // Specify a unique database name

builder.Services.AddControllers();
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

app.UseAuthorization();

app.MapControllers();

app.Run();
