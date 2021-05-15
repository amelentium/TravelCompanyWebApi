using MediatR;
using TravelCompanyWebApi.Infrastructure.Entity;

namespace TravelCompanyWebApi.CQRS.Discounts.Commands
{
    public class UpdateDiscountCommand : IRequest
    {
        public Discount Discount { get; set; }

        public UpdateDiscountCommand(Discount discount)
        {
            Discount = discount;
        }
    }
}
