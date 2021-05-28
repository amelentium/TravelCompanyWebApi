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
    public class TourValidator : MyAbstractValidator<Tour>
    {
        public TourValidator(TravelCompanyDBContext context) : base(context)
        {
            RuleFor(x => x)
                .MustAsync(IsUnique).WithMessage("A tour with same name is already exist");
            //RuleFor(x => x.Duration)
            //    .MustAsync(IsExist).WithMessage("Duration with same Id does not exist");
            //RuleFor(x => x.Hotel)
            //    .MustAsync(IsExist).WithMessage("Hotel with same Id does not exist");
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Tour name must be entered")
                .MinimumLength(10).WithMessage("Tour name too short")
                .MaximumLength(80).WithMessage("Tour name too long");
            RuleFor(x => x.Price)
                .NotNull().WithMessage("Tour price must be entered")
                .GreaterThan(0).WithMessage("Tour price must be greater than 0");
            RuleFor(x => x.StartDate)
                .NotNull().WithMessage("Tour start date must be entered");
        }

        public async Task<bool> IsUnique(Tour tour, CancellationToken cancellationToken)
        {
            return !await _context.Set<Tour>().AnyAsync(t => t.Name == tour.Name && t.Id != tour.Id);
        }
    }
}
