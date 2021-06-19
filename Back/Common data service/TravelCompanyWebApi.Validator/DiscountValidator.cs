using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using TravelCompanyWebApi.Infrastructure.Context;
using TravelCompanyWebApi.Infrastructure.Entity;

namespace TravelCompanyWebApi.Validator
{
    public class DiscountValidator : MyAbstractValidator<Discount>
    {
        public DiscountValidator(TravelCompanyDBContext context) : base(context)
        {
            RuleFor(x => x)
                .MustAsync(IsUnique).WithMessage("A discount with same name is already exist");
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Discount name must be entered")
                .MinimumLength(3).WithMessage("Discount name too short")
                .MaximumLength(20).WithMessage("Discount name too long");
            RuleFor(x => x.Value)
                .NotNull().WithMessage("Discount value must be entered")
                .GreaterThan(0).WithMessage("Discount value must be greater than 0");
        }

        public async Task<bool> IsUnique(Discount discount, CancellationToken cancellationToken)
        {
            return !await _context.Set<Discount>().AnyAsync(d => d.Name == discount.Name && d.Id != discount.Id);
        }
    }
}
