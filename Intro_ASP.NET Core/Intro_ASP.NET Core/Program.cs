using Intro_ASP.NET_Core.Data;
using Intro_ASP.NET_Core.Services;
using Microsoft.EntityFrameworkCore;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();    
builder.Services.AddSwaggerGen();
// Add MVC services
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IGreetingService, Greetings>();



string? connectionString = builder.Configuration["DefaultConnection"] ?? throw new InvalidOperationException("Connection not found");
// ^^^^^^^^^^^^^^^^^^ Ensure this exact name "DefaultConnection" matches appsettings.json



builder.Services.AddDbContext<ApplicationDbContext>(options => 
    options.UseSqlServer(connectionString));

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
// Configure static files (needed for CSS, JS, images)
app.UseStaticFiles();
// Add routing middleware
app.UseRouting();

// Configure MVC routes
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.Run();