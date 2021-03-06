using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using TravelCompanyWebApi.Infrastructure.Context;

namespace TravelCompanyWebApi.Validator
{
    public class MyAbstractValidator<TEntity> : AbstractValidator<TEntity> where TEntity : class
    {
        protected readonly TravelCompanyDBContext _context;
        public MyAbstractValidator(TravelCompanyDBContext context)
        {
            _context = context;
        }

        public async Task<bool> IsExist(TEntity entity, CancellationToken cancellationToken)
        {
            return await _context.Set<TEntity>().ContainsAsync(entity, cancellationToken);
        }

        public async Task<bool> IsNotExist(TEntity entity, CancellationToken cancellationToken)
        {
            return !await _context.Set<TEntity>().ContainsAsync(entity, cancellationToken);
        }
    }
}
