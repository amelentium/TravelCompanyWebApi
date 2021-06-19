using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TravelCompanyWebApi.CQRS.Discounts.Queries;
using TravelCompanyWebApi.Infrastructure.Entity;
using TravelCompanyWebApi.Service.Interface;

namespace TravelCompanyWebApi.CQRS.Discounts.Handlers
{
    public class GetDiscountByIdHandler : IRequestHandler<GetDiscountByIdQuery, Discount>
    {
        private readonly IDiscountService _discountService;

        public GetDiscountByIdHandler(IDiscountService discountService)
        {
            _discountService = discountService;
        }

        public async Task<Discount> Handle(GetDiscountByIdQuery request, CancellationToken cancellationToken)
        {
            return await _discountService.GetDiscountById(request.Id);
        }
    }
}