using System.Collections.Generic;
using System.Threading.Tasks;
using TravelCompanyWebApi.BusinessDAL.Entity.Interface;

namespace TravelCompanyWebApi.BusinessDAL.Repositories.Interfaces
{
    public interface IGenericRepository<TEntity, TId> where TEntity : IEntity<TId>
    {
        Task<IEnumerable<TEntity>> GetAll();

        Task<TEntity> Get(TId Id);

        Task Add(TEntity entity);

        Task Update(TEntity entity, TId Id);

        Task Delete(TId Id);
    }
}
