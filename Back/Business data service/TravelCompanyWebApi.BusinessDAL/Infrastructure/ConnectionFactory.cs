using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace TravelCompanyWebApi.BusinessDAL.Infrastructure
{
    public class ConnectionFactory : IConnectionFactory
    {
        private static string _connectionString;
        private readonly IConfiguration _configuration;

        public ConnectionFactory(IConfiguration config)
        {
            _configuration = config;
        }
        public void SetConnection(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IDbConnection GetSqlConnection
        {
            get
            {
                SqlConnection connection;

                if (!string.IsNullOrEmpty(_connectionString))
                    connection = new SqlConnection(_connectionString);
                else
                    connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

                connection.Open();

                return connection;
            }
        }
    }
}
