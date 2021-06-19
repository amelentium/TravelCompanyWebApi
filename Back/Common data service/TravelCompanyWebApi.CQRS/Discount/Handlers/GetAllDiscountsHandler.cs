using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TravelCompanyWebApi.CQRS.Discounts.Queries;
using TravelCompanyWebApi.Infrastructure.Entity;
using TravelCompanyWebApi.Service.Interface;

namespace TravelCompanyWebApi.CQRS.Discounts.Handlers
{
    public class GetAllDiscountHandler : IRequestHandler<GetAllDiscountsQuery, IEnumerable<Discount>>
    {
        private readonly IDiscountService _discountService;

        public GetAllDiscountHandler(IDiscountService discountService)
        {
            _discountService = discountService;
        }

        public async Task<IEnumerable<Discount>> Handle(GetAllDiscountsQuery request, CancellationToken cancellationToken)
        {
            return await _discountService.GetDiscounts();
        }
    }
}