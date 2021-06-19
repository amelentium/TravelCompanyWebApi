using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using TravelCompanyWebApi.Infrastructure.Context;
using TravelCompanyWebApi.Infrastructure.Entity;

namespace TravelCompanyWebApi.Validator
{
    public class CountryValidator : MyAbstractValidator<Country>
    {
        public CountryValidator(TravelCompanyDBContext context) : base(context)
        {
            RuleFor(x => x)
                .MustAsync(IsUnique).WithMessage("A country with same name is already exist");
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Country name must be entered")
                .MinimumLength(2).WithMessage("Country name too short")
                .MaximumLength(20).WithMessage("Country name too long")
                .Matches("\\D*").WithMessage("Invalid country name entered");
        }

        public async Task<bool> IsUnique(Country country, CancellationToken cancellationToken)
        {
            return !await _context.Set<Country>().AnyAsync(c => c.Name == country.Name && c.Id != country.Id);
        }
    }
}
