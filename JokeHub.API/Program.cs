using JokeHub.API.Extensions;
using JokeHub.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add custom services via extensions
builder.Services.RegisterDBcontextService();
builder.Services.RegisterRepositories();
builder.Services.RegisterAppServices();
builder.Services.RegisterMappingServices();


// Register context
builder.Services.AddDbContext<JokeHubContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection")
));


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
else
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "JokeHub API v1");
        c.RoutePrefix = String.Empty;
    });
}
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
