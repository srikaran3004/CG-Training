using Microsoft.EntityFrameworkCore;
using StudentManagementPortal.Interfaces;
using StudentManagementPortal.Models;
using StudentManagementPortal.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// 1. Dependency Injection for DbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// 2. Dependency Injection for Services
builder.Services.AddScoped<IStudentService, StudentService>();

// 3. Add controllers
builder.Services.AddControllers();

// 4. Configure Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// 5. Configure CORS (allow all for simple testing)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// 6. Serve static files (HTML, JS, CSS from wwwroot folder)
app.UseStaticFiles();

// Enable CORS
app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();
