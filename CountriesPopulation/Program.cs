using BAL.AutoMapper;
using BAL.Services;
using CountriesPopulation.Interfaces;
using CountriesPopulation.Services;
using DAL.Context;
using Microsoft.EntityFrameworkCore;

namespace CountriesPopulation;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var connectionString = builder.Configuration.GetConnectionString("Default");
        builder.Services.AddDbContext<CountryDBContext>(options => options.UseSqlServer(connectionString));

        builder.Services.AddSingleton<HttpService>();
        builder.Services.AddScoped<ICountry, CountryService>();
        builder.Services.AddAutoMapper(typeof(AutoMapperProfile).Assembly);

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

    }
}