using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using TravelCompanyWebApi.CQRS;
using TravelCompanyWebApi.Infrastructure.Context;
using TravelCompanyWebApi.Mapper;
using TravelCompanyWebApi.Repository.Repository;
using TravelCompanyWebApi.Repository.Repository.Interface;
using TravelCompanyWebApi.Repository.UnitOfWork;
using TravelCompanyWebApi.Repository.UnitOfWork.Interface;
using TravelCompanyWebApi.Service;
using TravelCompanyWebApi.Service.Interface;

namespace TrevelCompanyWebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        private readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<TravelCompanyDBContext>();

            #region Transients
            #region Repositories
            services.AddTransient<ICityRepository, CityRepository>();
            services.AddTransient<IClientRepository, ClientRepository>();
            services.AddTransient<IClimateRepository, ClimateRepository>();
            services.AddTransient<ICountryRepository, CountryRepository>();
            services.AddTransient<IDiscountRepository, DiscountRepository>();
            services.AddTransient<IDurationRepository, DurationRepository>();
            services.AddTransient<IHotelRepository, HotelRepository>();
            services.AddTransient<IPassDiscountRepository, PassDiscountRepository>();
            services.AddTransient<IPassRepository, PassRepository>();
            services.AddTransient<ITourRepository, TourRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            #endregion

            #region Services
            services.AddTransient<ICityService, CityService>();
            services.AddTransient<IClientService, ClientService>();
            services.AddTransient<IClimateService, ClimateService>();
            services.AddTransient<ICountryService, CountryService>();
            services.AddTransient<IDiscountService, DiscountService>();
            services.AddTransient<IDurationService, DurationService>();
            services.AddTransient<IHotelService, HotelService>();
            services.AddTransient<IPassDiscountService, PassDiscountService>();
            services.AddTransient<IPassService, PassService>();
            services.AddTransient<ITourService, TourService>();
            #endregion
            #endregion

            services.AddControllers();

            services.AddCors(opt =>
            {
                opt.AddPolicy(name: MyAllowSpecificOrigins, builder =>
                {
                    builder.WithOrigins("https://localhost:44303")
                    .AllowAnyHeader()
                    .AllowAnyMethod();
                });
            });

            services.AddAutoMapper(typeof(TravelCompanyMapper));

            services.AddMediatR(typeof(MediatRStartup).Assembly);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TrevelCompanyWebApi", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "TrevelCompanyWebApi v1");
                });
            }

            app.UseCors(MyAllowSpecificOrigins);

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
