using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using TravelCompanyWebApi.Infrastructure.Context;
using TravelCompanyWebApi.Infrastructure.Entity;

namespace TravelCompanyWebApi.Validator
{
    public class CityValidator : MyAbstractValidator<City>
    {
        public CityValidator(TravelCompanyDBContext context) : base(context)
        {
            RuleFor(x => x)
                .MustAsync(IsUnique).WithMessage("A city with same name is already exist");
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("City name must be entered")
                .MinimumLength(2).WithMessage("City name too short")
                .MaximumLength(20).WithMessage("City name too long")
                .Matches("\\D*").WithMessage("Invalid city name entered");
            RuleFor(x => x.Climate)
                .MustAsync(IsExist).WithMessage("Climate with same Id does not exist");
            RuleFor(x => x.Country)
                .MustAsync(IsExist).WithMessage("Country with same Id does not exist");
        }

        public async Task<bool> IsUnique(City city, CancellationToken cancellationToken)
        {
            return !await _context.Set<City>().AnyAsync(c => c.Name == city.Name && c.Id != city.Id);
        }
    }
}
