using MyWebApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to container
builder.Services.AddControllers();

// Dependency Injection Registration
builder.Services.AddScoped<IUserService, UserService>();

var app = builder.Build();

// Configure middleware
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();