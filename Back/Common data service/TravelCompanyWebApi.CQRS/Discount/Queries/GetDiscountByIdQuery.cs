using MediatR;
using TravelCompanyWebApi.Infrastructure.Entity;

namespace TravelCompanyWebApi.CQRS.Discounts.Queries
{
    public class GetDiscountByIdQuery : IRequest<Discount>
    {
        public int Id { get; set; }

        public GetDiscountByIdQuery(int id)
        {
            Id = id;
        }
    }
}