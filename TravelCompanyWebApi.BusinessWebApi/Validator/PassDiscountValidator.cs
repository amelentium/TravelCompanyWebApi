using FluentValidation;
using System.Threading;
using System.Threading.Tasks;
using TravelCompanyWebApi.BusinessDAL.Entity;

namespace TravelCompanyWebApi.Validator
{
    public class PassDiscountValidator : AbstractValidator<PassDiscount>
    {
        //public PassDiscountValidator()
        //{
        //    RuleFor(x => x)
        //        .MustAsync(IsUnique).WithMessage("The discount already applied to the pass");
        //    RuleFor(x => x.DiscountId)
        //        .MustAsync(IsExist).WithMessage("Discount with same Id does not exist");
        //    RuleFor(x => x.PassId)
        //        .MustAsync(IsExist).WithMessage("Pass with same Id does not exist");
        //}

        //public async Task<bool> IsUnique(PassDiscount passDiscount, CancellationToken cancellationToken)
        //{
        //    return !await _context.Set<PassDiscount>().AnyAsync(pd => pd.DiscountId == passDiscount.DiscountId && pd.PassId == passDiscount.PassId && pd.Id != passDiscount.Id);
        //}
    }
}
