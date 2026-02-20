var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

// Static files middleware (required)
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Default route -> Student Controller
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Student}/{action=CalculateMarks}/{id?}"
);

app.Run();