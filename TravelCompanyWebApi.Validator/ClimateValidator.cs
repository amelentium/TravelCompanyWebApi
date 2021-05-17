using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using TravelCompanyWebApi.Infrastructure.Context;
using TravelCompanyWebApi.Infrastructure.Entity;

namespace TravelCompanyWebApi.Validator
{
    public class ClimateValidator : MyAbstractValidator<Climate>
    {
        public ClimateValidator(TravelCompanyDBContext context) : base(context)
        {
            RuleFor(x => x)
                .MustAsync(IsUnique).WithMessage("A climate with same name is already exist");
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Climate name must be entered")
                .MinimumLength(2).WithMessage("Climate name too short")
                .MaximumLength(20).WithMessage("Climate name too long")
                .Matches(@"^[A-Za-z]*$").WithMessage("Invalid climate name entered");                
        }

        public async Task<bool> IsUnique(Climate climate, CancellationToken cancellationToken)
        {
            return !await _context.Set<Climate>().AnyAsync(c => c.Name == climate.Name && c.Id != climate.Id);
        }
    }
}
