using Microsoft.EntityFrameworkCore;
using WEB_CODEBASE_00016197.Data;
using WEB_CODEBASE_00016197.Models_00016197;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure CORS policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()  // Allows any origin
              .AllowAnyMethod()  // Allows any HTTP method
              .AllowAnyHeader(); // Allows any header
    });
});

// Configure DbContext with SQL Server connection
builder.Services.AddDbContext<IssueTrackerContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

var app = builder.Build();

// Use Swagger UI in development environment
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Enable CORS policy
app.UseCors("AllowAll");  // Add this line before routing

app.UseHttpsRedirection();
app.UseAuthorization();

// Map controllers
app.MapControllers();

app.Run();
