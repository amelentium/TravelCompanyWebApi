using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using TravelCompanyWebApi.BusinessDAL.Entity.Interface;
using TravelCompanyWebApi.BusinessDAL.Infrastructure;
using TravelCompanyWebApi.BusinessDAL.Repositories.Interfaces;

namespace TravelCompanyWebApi.BusinessDAL.Repository
{
    public class GenericRepository<TEntity, TId> : IGenericRepository<TEntity, TId> where TEntity : IEntity<TId>
    {
        protected IConnectionFactory _connectionFactory;
        protected readonly string _tableName;

        public GenericRepository(IConnectionFactory connectionFactory, IConfiguration config, string tableName)
        {
            _connectionFactory = connectionFactory;
            _connectionFactory.SetConnection(config["ConnectionString:DefaultConnection"]);
            _tableName = tableName;
        }

        public async Task Add(TEntity entity)
        {
            var stringOfColumns = string.Join(", ", GetColumns());
            var stringOfProperties = string.Join(", ", GetProperties(entity));
            var query = "SP_InsertRecordToTable";

            using var db = _connectionFactory.GetSqlConnection;
            var Id = await db.ExecuteAsync(
                sql: query,
                param: new { P_tableName = _tableName, P_columnsString = stringOfColumns, P_propertiesString = stringOfProperties },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<TEntity> Get(TId Id)
        {
            var query = "SP_GetRecordByIdFromTable";

            using var db = _connectionFactory.GetSqlConnection;
            var result = await db.QueryAsync<TEntity>(query,
                new { P_tableName = _tableName, P_Id = Id },
                commandType: CommandType.StoredProcedure);

            return result.FirstOrDefault();
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            var query = "SP_GetAllRecordsFromTable";

            using var db = _connectionFactory.GetSqlConnection;
            return await db.QueryAsync<TEntity>(query,
                new { P_tableName = _tableName },
                commandType: CommandType.StoredProcedure);
        }

        public async Task Update(TEntity entity, TId Id)
        {
            var columns = GetColumns();
            var properties = GetProperties(entity);
            columns = columns.Zip(properties, (column, property) => column + " = " + property);
            var stringOfColumns = string.Join(", ", columns);

            using var db = _connectionFactory.GetSqlConnection;
            var query = "SP_UpdateRecordInTable";

            await db.ExecuteAsync(
                sql: query,
                param: new { P_tableName = _tableName, P_columnsString = stringOfColumns, P_Id = Id },
                commandType: CommandType.StoredProcedure);
        }

        public async Task Delete(TId Id)
        {
            using var db = _connectionFactory.GetSqlConnection;
            var query = "SP_DeleteRecordFromTable";
            await db.ExecuteAsync(
                sql: query,
                param: new { P_tableName = _tableName, P_Id = Id },
                commandType: CommandType.StoredProcedure);
        }

        private static IEnumerable<string> GetColumns()
        {
            return typeof(TEntity)
                    .GetProperties()
                    .Where(e => e.Name != "Id" && e.Name != "TotalDiscount" && e.Name != "FullPrice" && e.Name != "FinalPrice")
                    .Select(e => e.Name);
        }

        private static IEnumerable<string> GetProperties(TEntity entity)
        {
            return typeof(TEntity)
                    .GetProperties()
                    .Where(e => e.Name != "Id" && e.Name != "TotalDiscount" && e.Name != "FullPrice" && e.Name != "FinalPrice")
                    .Select(e => e.PropertyType.Equals(typeof(DateTime?))? '\'' + DateTime.Parse(e.GetValue(entity).ToString()).ToString("yyyy-MM-dd HH:mm:ss") + '\'' : '\'' + e.GetValue(entity).ToString() + '\'');
        }
    }
}
