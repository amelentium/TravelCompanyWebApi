using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using TravelCompanyWebApi.Infrastructure.Context;
using TravelCompanyWebApi.Infrastructure.Entity;

namespace TravelCompanyWebApi.Validator
{
    public class CityValidator : AbstractValidator<City>
    {
        public CityValidator()
        {
            RuleFor(x => x)
                .MustAsync(IsUnique).WithMessage("A city with same name is already exist");
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("City name must be entered")
                .MinimumLength(2).WithMessage("City name too short")
                .MaximumLength(20).WithMessage("City name too long")
                .Matches("\\D*").WithMessage("Invalid city name entered");
        }
    }
}
