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
    public class DurationValidator : MyAbstractValidator<Duration>
    {
        public DurationValidator(TravelCompanyDBContext context) : base(context)
        {
            RuleFor(x => x)
                .MustAsync(IsUnique).WithMessage("A duration with same time is already exist");
            RuleFor(x => x.Time)
                .NotNull().WithMessage("Duration time must be entered")
                .GreaterThan((byte)0).WithMessage("Duration time must be greater than 0");
        }

        public async Task<bool> IsUnique(Duration duration, CancellationToken cancellationToken)
        {
            return !await _context.Set<Duration>().AnyAsync(d => d.Time == duration.Time && d.Id != duration.Id, CancellationToken.None);
        }
    }
}
