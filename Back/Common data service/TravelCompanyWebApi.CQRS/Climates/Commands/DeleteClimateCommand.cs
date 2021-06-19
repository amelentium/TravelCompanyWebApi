using MediatR;

namespace TravelCompanyWebApi.CQRS.Climates.Commands
{
    public class DeleteClimateCommand : IRequest
    {
        public byte Id { get; set; }

        public DeleteClimateCommand(byte id)
        {
            Id = id;
        }
    }
}
