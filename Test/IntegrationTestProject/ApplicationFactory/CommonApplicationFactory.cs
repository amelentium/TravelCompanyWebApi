using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using TravelCompanyWebApi.Infrastructure.Context;
using TravelCompanyWebApi.Infrastructure.Entity;

namespace IntegrationTestProject.ApplicationFactory
{
    public class CommonApplicationFactory<TStartup>
       : WebApplicationFactory<TStartup> where TStartup : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                var descriptor = services.SingleOrDefault(
                    d => d.ServiceType == typeof(DbContextOptions<TravelCompanyDBContext>));

                services.Remove(descriptor);

                services.AddDbContext<TravelCompanyDBContext>(options =>
                {
                    options.UseInMemoryDatabase("InMemoryTestingDb");
                });

                var sp = services.BuildServiceProvider();

                using var scope = sp.CreateScope();
                var scopedServices = scope.ServiceProvider;
                var db = scopedServices.GetRequiredService<TravelCompanyDBContext>();

                db.Database.EnsureCreated();

                try
                {
                    db.Climates.AddRange(new List<Climate> 
                    { 
                        new Climate { Id = 1, Name = "Dry"},
                        new Climate { Id = 2, Name = "Polar"},
                        new Climate { Id = 3, Name = "Tropical"},
                        new Climate { Id = 4, Name = "Mild"}
                    });
                    db.Cities.AddRange(new List<City>
                    {
                        new City { Id = 1, Name = "City1", CountryId = null, ClimateId = 1 },
                        new City { Id = 2, Name = "City2", CountryId = null, ClimateId = 1 },
                        new City { Id = 3, Name = "City3", CountryId = null, ClimateId = 2 },
                        new City { Id = 4, Name = "City4", CountryId = null, ClimateId = 3 }
                    });
                    db.Hotels.AddRange(new List<Hotel>
                    {
                        new Hotel { Id = 1, Name = "Hotel1", CityId = 1, Stars = 3 },
                        new Hotel { Id = 2, Name = "Hotel2", CityId = 1, Stars = 4 },
                        new Hotel { Id = 3, Name = "Hotel3", CityId = 2, Stars = 4 },
                        new Hotel { Id = 4, Name = "Hotel4", CityId = 3, Stars = 5 }
                    });
                    db.Tours.AddRange(new List<Tour>
                    {
                        new Tour { Id = 1, Name = "Tour to Hotel 1 (standart)", HotelId = 1, Price = 1000, StartDate = DateTime.Parse("2020.05.21")},
                        new Tour { Id = 2, Name = "Tour to Hotel 1 (premium)", HotelId = 1, Price = 1500, StartDate = DateTime.Parse("2020.06.07")},
                        new Tour { Id = 3, Name = "Tour to Hotel 2 (premium)", HotelId = 2, Price = 2000, StartDate = DateTime.Parse("2021.09.16")},
                    });
                    db.SaveChanges();
                }
                catch (Exception)
                {
                    // ignored
                }
            });
        }
    }
}
