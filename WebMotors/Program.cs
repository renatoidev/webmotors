using Microsoft.EntityFrameworkCore;
using Refit;
using WebMotors.Data;
using WebMotors.Interfaces;

var builder = WebApplication.CreateBuilder(args);

ConfigureServices(builder);

// Add services to the container.

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

void ConfigureServices(WebApplicationBuilder builder)
{
    var baseUrl = builder.Configuration["BaseUrl"].ToString();

    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    builder.Services.AddDbContext<AdDataContext>(options => options.UseSqlite(connectionString));

    builder.Services.AddRefitClient<IExternalAdService>().ConfigureHttpClient(c =>
    {
        c.BaseAddress = new Uri(baseUrl);
    });
}