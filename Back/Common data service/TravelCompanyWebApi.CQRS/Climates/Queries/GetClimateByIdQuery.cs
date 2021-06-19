using MediatR;
using TravelCompanyWebApi.Infrastructure.Entity;

namespace TravelCompanyWebApi.CQRS.Climates.Queries
{
    public class GetClimateByIdQuery : IRequest<Climate>
    {
        public byte Id { get; set; }

        public GetClimateByIdQuery(byte id)
        {
            Id = id;
        }
    }
}