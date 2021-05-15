using MediatR;

namespace TravelCompanyWebApi.CQRS.Discounts.Commands
{
    public class DeleteDiscountCommand : IRequest
    {
        public int Id { get; set; }

        public DeleteDiscountCommand(int id)
        {
            Id = id;
        }
    }
}
