using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using TravelCompany.Application.Factories;
using TravelCompany.Application.Service.Interface;

namespace TravelCompany.Application.Service
{
	public class GenericService<TEntity> : GenericService<TEntity, int>, IGenericService<TEntity> where TEntity : class
	{
		public GenericService(DBContextFactory contextFactory) : base(contextFactory) { }
	}

	public class GenericService<TEntity, TId> : IGenericService<TEntity, TId> where TEntity : class where TId : IEquatable<TId>
	{
		private readonly TravelCompanyContext _context;
		private readonly DbSet<TEntity> _set;

		public GenericService(DBContextFactory contextFactory)
		{
			_context = contextFactory.GetContext();
			_set = _context.Set<TEntity>();
		}

		public async Task AddAsync(TEntity entity)
		{
			await _set.AddAsync(entity);
			await _context.SaveChangesAsync();
		}

		public async Task DeleteAsync(TId id)
		{
			var entity = await GetByIdAsync(id);
			_set.Remove(entity);
			await _context.SaveChangesAsync();
		}

		public async Task<List<TEntity>> GetAllAsync()
		{
			return await _set.ToListAsync();
		}

		public async Task<TEntity> GetByIdAsync(TId id)
		{
			var entity = await _set.FindAsync(id);
			if (entity == null)
				throw new Exception($"{nameof(TEntity)} not found");

			return entity;
		}

		public async Task UpdateAsync(TEntity entity)
		{
			_set.Update(entity);
			await _context.SaveChangesAsync();
		}
	}
}
