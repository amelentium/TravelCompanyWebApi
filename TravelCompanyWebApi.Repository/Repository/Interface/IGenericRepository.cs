using System.Collections.Generic;
using System.Threading.Tasks;
using TravelCompanyWebApi.Infrastructure.Entity;

namespace TravelCompanyWebApi.Repository.Repository.Interface
{
    public interface IGenericRepository <TEntity> where TEntity : class, IEntity
    {
        public Task Add(TEntity entity);
        public Task Delete(int id);
        public Task<IEnumerable<TEntity>> Get();
        public Task<TEntity> GetById(int id);
        public void Update(TEntity entity);
    }
}
