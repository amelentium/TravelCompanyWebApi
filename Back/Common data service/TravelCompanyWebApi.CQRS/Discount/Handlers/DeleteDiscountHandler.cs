using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TravelCompanyWebApi.CQRS.Discounts.Commands;
using TravelCompanyWebApi.Service.Interface;

namespace TravelCompanyWebApi.CQRS.Discounts.Handlers
{
    public class DeleteDiscountHandler : IRequestHandler<DeleteDiscountCommand>
    {
        private readonly IDiscountService _discountService;

        public DeleteDiscountHandler(IDiscountService discountService)
        {
            _discountService = discountService;
        }

        public async Task<Unit> Handle(DeleteDiscountCommand request, CancellationToken cancellationToken)
        {
            await _discountService.DeleteDiscount(request.Id);

            return Unit.Value;
        }
    }
}