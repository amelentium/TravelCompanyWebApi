using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TravelCompanyWebApi.CQRS.Discounts.Commands;
using TravelCompanyWebApi.Service.Interface;

namespace TravelCompanyWebApi.CQRS.Discounts.Handlers
{
    public class CreateDiscountHandler : IRequestHandler<CreateDiscountCommand>
    {
        private readonly IDiscountService _discountService;

        public CreateDiscountHandler(IDiscountService discountService)
        {
            _discountService = discountService;
        }

        public async Task<Unit> Handle(CreateDiscountCommand request, CancellationToken cancellationToken)
        {
            await _discountService.AddDiscount(request.Discount);

            return Unit.Value;
        }
    }
}