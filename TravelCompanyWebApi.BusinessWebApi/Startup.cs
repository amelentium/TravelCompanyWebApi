using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using TravelCompanyWebApi.BusinessBLL;
using TravelCompanyWebApi.BusinessBLL.Interface;
using TravelCompanyWebApi.BusinessDAL.Infrastructure;
using TravelCompanyWebApi.BusinessDAL.Repository;
using TravelCompanyWebApi.BusinessDAL.Repository.Interface;

namespace TravelCompanyWebApi.BusinessWebApi
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(Configuration);

            services.AddTransient<IConnectionFactory, ConnectionFactory>();

            services.AddTransient<IDiscountRepository, DiscountRepository>();
            services.AddTransient<IPassDiscountRepository, PassDiscountRepository>();
            services.AddTransient<IPassRepository, PassRepository>();
            services.AddTransient<ITourRepository, TourRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            services.AddTransient<IDiscountService, DiscountService>();
            services.AddTransient<IPassDiscountService, PassDiscountService>();
            services.AddTransient<IPassService, PassService>();
            services.AddTransient<ITourService, TourService>();

            #region CORS
            services.AddCors(opt =>
            {
                opt.AddPolicy("_myAllowSpecificOrigins", builder =>
                {
                    builder.WithOrigins("https://localhost:44303")
                    .AllowAnyHeader()
                    .AllowAnyMethod();
                });
            });
            #endregion

            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TravelCompanyWebApi.BusinessWebApi", Version = "v1" });
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

            app.UseRouting();

            app.UseCors();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
