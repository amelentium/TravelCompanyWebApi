using MediatR;
using System.Collections.Generic;
using TravelCompanyWebApi.Infrastructure.Entity;

namespace TravelCompanyWebApi.CQRS.Discounts.Queries
{
    public class GetAllDiscountsQuery : IRequest<IEnumerable<Discount>>
    {

    }
}