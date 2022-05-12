namespace TravelCompany.Application.Service.Interface
{
    public interface IGenericService<TEntity> : IGenericService<TEntity, int> where TEntity : class 
    {
    }

    public interface IGenericService<TEntity, TId> where TEntity : class where TId : IEquatable<TId>
    {
        public Task AddAsync(TEntity entity);
        public Task UpdateAsync(TEntity entity);
        public Task DeleteAsync(TId id);
        public Task<TEntity> GetByIdAsync(TId id);
        public Task<List<TEntity>> GetAllAsync();
    }
}
