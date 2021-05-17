using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using TravelCompanyWebApi.Infrastructure.Context;
using TravelCompanyWebApi.Infrastructure.Entity;

namespace TravelCompanyWebApi.Validator
{
    public class HotelValidator : MyAbstractValidator<Hotel>
    {
        public HotelValidator(TravelCompanyDBContext context) : base(context)
        {
            RuleFor(x => x)
                .MustAsync(IsUnique).WithMessage("A hotel with same name is already exist");
            RuleFor(x => x.City)
                .MustAsync(IsExist).WithMessage("City with same Id does not exist");
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Hotel name must be entered")
                .MinimumLength(2).WithMessage("Hotel name too short")
                .MaximumLength(20).WithMessage("Hotel name too long")
                .Matches("^\\D*$").WithMessage("Invalid hotel name entered");
            RuleFor(x => x.Stars)
                .NotNull().WithMessage("Hotel stars count must be entered")
                .LessThan(6).WithMessage("Hotel stars count must be less than 6")
                .GreaterThan(0).WithMessage("Hotel stars count must be greater than 0");
        }

        public async Task<bool> IsUnique(Hotel hotel, CancellationToken cancellationToken)
        {
            return !await _context.Set<Hotel>().AnyAsync(h => h.Name == hotel.Name && h.Id != hotel.Id);
        }
    }
}
