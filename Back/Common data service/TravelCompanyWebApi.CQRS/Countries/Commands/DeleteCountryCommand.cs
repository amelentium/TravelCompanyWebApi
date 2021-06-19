using MediatR;

namespace TravelCompanyWebApi.CQRS.Countries.Commands
{
    public class DeleteCountryCommand : IRequest
    {
        public int Id { get; set; }

        public DeleteCountryCommand(int id)
        {
            Id = id;
        }
    }
}
