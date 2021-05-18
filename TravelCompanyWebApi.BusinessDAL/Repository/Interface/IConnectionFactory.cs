using System.Data;

namespace TravelCompanyWebApi.BusinessDAL.Repositories.Interfaces
{
    public interface IConnectionFactory
    {
        IDbConnection GetSqlConnection { get; }
        void SetConnection(string connectionString);
    }
}
