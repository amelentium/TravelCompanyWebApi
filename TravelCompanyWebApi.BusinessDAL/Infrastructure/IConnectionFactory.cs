using System.Data;

namespace TravelCompanyWebApi.BusinessDAL.Infrastructure
{
    public interface IConnectionFactory
    {
        IDbConnection GetSqlConnection { get; }
        void SetConnection(string connectionString);
    }
}
