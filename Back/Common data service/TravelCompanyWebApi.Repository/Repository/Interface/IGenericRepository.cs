using System.Collections.Generic;
using System.Threading.Tasks;
using TravelCompanyWebApi.Infrastructure.Entity;

namespace TravelCompanyWebApi.Repository.Repository.Interface
{
    public interface IGenericRepository <TEntity, TId> where TEntity : class, IEntity<TId>
    {
        public Task Add(TEntity entity);
        public Task Delete(TId id);
        public Task<IEnumerable<TEntity>> Get();
        public Task<TEntity> GetById(TId id);
        public void Update(TEntity entity);
    }
}
