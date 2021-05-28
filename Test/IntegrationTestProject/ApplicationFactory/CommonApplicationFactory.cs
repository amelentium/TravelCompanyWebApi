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
                    d => d.ServiceType ==
                        typeof(DbContextOptions<TravelCompanyDBContext>));

                services.Remove(descriptor);

                services.AddDbContext<TravelCompanyDBContext>(options =>
                {
                    options.UseInMemoryDatabase("InMemoryTestingDb");
                });

                var sp = services.BuildServiceProvider();

                using (var scope = sp.CreateScope())
                {
                    var scopedServices = scope.ServiceProvider;
                    var db = scopedServices.GetRequiredService<TravelCompanyDBContext>();

                    db.Database.EnsureCreated();

                    try
                    {
                        db.Climates.AddRange(new List<Climate> 
                        { 
                            new Climate { Id = 1, Name = "Dry"},
                            new Climate { Id = 2, Name = "Arctic"},
                            new Climate { Id = 3, Name = "Tropical"}, 
                        });
                        db.SaveChanges();
                    }
                    catch (Exception) { }
                }
            });
        }
    }
}
