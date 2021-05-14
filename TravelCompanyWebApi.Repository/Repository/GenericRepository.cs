using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TravelCompanyWebApi.Infrastructure.Context;
using TravelCompanyWebApi.Infrastructure.Entity;
using TravelCompanyWebApi.Repository.Repository.Interface;

namespace TravelCompanyWebApi.Repository.Repository
{
    public class GenericRepository<TEntity, TId> : IGenericRepository<TEntity, TId> where TEntity : class, IEntity<TId>
    {
        protected readonly TravelCompanyDBContext _context;
        protected readonly DbSet<TEntity> _set;

        public GenericRepository(TravelCompanyDBContext context)
        {
            _context = context;
            _set = context.Set<TEntity>();
        }

        public async Task Add(TEntity entity)
        {
            await _set.AddAsync(entity);
        }

        public async Task Delete(TId id)
        {
            _set.Remove(await _set.FindAsync(id));
        }

        public async Task<IEnumerable<TEntity>> Get()
        {
            return await _set.ToListAsync();
        }

        public async Task<TEntity> GetById(TId id)
        {
            return await _set.FindAsync(id);
        }

        public void Update(TEntity entity)
        {
            _set.Update(entity);
        }
    }
}
