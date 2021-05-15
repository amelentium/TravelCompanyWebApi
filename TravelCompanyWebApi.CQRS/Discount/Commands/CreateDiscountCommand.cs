using MediatR;
using TravelCompanyWebApi.Infrastructure.Entity;

namespace TravelCompanyWebApi.CQRS.Discounts.Commands
{
    public class CreateDiscountCommand : IRequest
    {
        public Discount Discount { get; set; }

        public CreateDiscountCommand(Discount discount)
        {
            Discount = discount;
        }
    }
}
