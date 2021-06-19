using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TravelCompanyWebApi.CQRS.Discounts.Commands;
using TravelCompanyWebApi.Service.Interface;

namespace TravelCompanyWebApi.CQRS.Discounts.Handlers
{
    public class UpdateDiscountHandler : IRequestHandler<UpdateDiscountCommand>
    {
        private readonly IDiscountService _discountService;

        public UpdateDiscountHandler(IDiscountService discountService)
        {
            _discountService = discountService;
        }

        public async Task<Unit> Handle(UpdateDiscountCommand request, CancellationToken cancellationToken)
        {
            await _discountService.UpdateDiscount(request.Discount);

            return Unit.Value;
        }
    }
}