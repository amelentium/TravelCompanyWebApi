using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TravelCompany.Application.Service;

namespace TravelCompany.Application.Factories
{
	public class DBContextFactory
	{
		private readonly IConfiguration _configuration;
		private readonly IRequestProviderService _providerService;

		public DBContextFactory(IConfiguration configuration, IRequestProviderService providerService)
		{
			_configuration = configuration;
			_providerService = providerService;
		}

		public TravelCompanyContext GetContext()
		{
			var provider = _providerService.Provider;

			var contextOptionsBuilder = new DbContextOptionsBuilder<TravelCompanyContext>();

			var contextOptions = provider switch
			{
				"mysql" => contextOptionsBuilder.UseMySQL(_configuration.GetConnectionString("MySqlConnection")).Options,
				"pgsql" => contextOptionsBuilder.UseNpgsql(_configuration.GetConnectionString("PostgresConnection")).Options,
				"sqlite" => contextOptionsBuilder.UseSqlite(_configuration.GetConnectionString("SqliteConnection")).Options,
				_ => contextOptionsBuilder.UseInMemoryDatabase("TravelCompanyDB").Options
			};

			return new TravelCompanyContext(contextOptions);
		}
	}
}
