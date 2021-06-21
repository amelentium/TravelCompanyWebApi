using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TravelCompanyWebApi.Infrastructure.Context;
using TravelCompanyWebApi.Infrastructure.Entity;

namespace TravelCompanyWebApi.Validator
{
    public class PassDiscountValidator : MyAbstractValidator<PassDiscount>
    {
        public PassDiscountValidator(TravelCompanyDBContext context) : base(context)
        {
            RuleFor(x => x)
                .MustAsync(IsUnique).WithMessage("The discount already applied to the pass");
            //RuleFor(x => x.Discount)
            //    .MustAsync(IsExist).WithMessage("Discount with same Id does not exist");
            //RuleFor(x => x.Pass)
            //    .MustAsync(IsExist).WithMessage("Pass with same Id does not exist");
        }

        public async Task<bool> IsUnique(PassDiscount passDiscount, CancellationToken cancellationToken)
        {
            return !await _context.Set<PassDiscount>().AnyAsync(pd => pd.DiscountId == passDiscount.DiscountId && pd.PassId == passDiscount.PassId && pd.Id != passDiscount.Id, CancellationToken.None);
        }
    }
}
