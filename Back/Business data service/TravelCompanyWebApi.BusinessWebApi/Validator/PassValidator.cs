using FluentValidation;
using TravelCompanyWebApi.BusinessDAL.Entity;

namespace TravelCompanyWebApi.Validator
{
    public class PassValidator : AbstractValidator<Pass>
    {
        //public PassValidator()
        //{
        //    RuleFor(x => x.Client)
        //        .MustAsync(IsExist).WithMessage("Client with same Id does not exist");
        //    RuleFor(x => x.Tour)
        //        .MustAsync(IsExist).WithMessage("Tour with same Id does not exist");
        //    RuleFor(x => x.Count)
        //        .NotNull().WithMessage("Pass tours count must be entered")
        //        .GreaterThan(0).WithMessage("Pass tours count must be greater than 0");
        //    RuleFor(x => x.PurchaseDate)
        //        .NotNull().WithMessage("Pass purchase date must be entered");
        //}
    }
}
