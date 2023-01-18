using JokeHub.Infrastructure.Data;
using JokeHub.Web.Extensions;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


// Add custom services via extensions
builder.Services.RegisterDBcontextService();
builder.Services.RegisterRepositories();
builder.Services.RegisterAppServices();
builder.Services.RegisterMappingServices();


// Register context
builder.Services.AddDbContext<JokeHubContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection")
));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
