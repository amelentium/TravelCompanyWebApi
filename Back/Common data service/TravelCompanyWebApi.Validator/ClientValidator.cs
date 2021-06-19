using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using TravelCompanyWebApi.Infrastructure.Context;
using TravelCompanyWebApi.Infrastructure.Entity;

namespace TravelCompanyWebApi.Validator
{
    public class ClientValidator : MyAbstractValidator<Client>
    {
        public ClientValidator(TravelCompanyDBContext context) : base(context)
        {
            RuleFor(x => x)
                .MustAsync(IsUnique).WithMessage("A client with same phone number is already exist");
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("Client's first name must be entered")
                .MinimumLength(2).WithMessage("Client's first name too short")
                .MaximumLength(20).WithMessage("Client's first name too long")
                .Matches(@"^[A-Za-z]*$").WithMessage("Invalid first name entered");
            RuleFor(x => x.MiddleName)
                    .NotEmpty().WithMessage("Client's second name must be entered")
                    .MinimumLength(2).WithMessage("Client's second name too short")
                    .MaximumLength(20).WithMessage("Client's second name too long")
                    .Matches(@"^[A-Za-z]*$").WithMessage("Invalid second name entered");
            RuleFor(x => x.LastName)
                    .NotEmpty().WithMessage("Client's last name must be entered")
                    .MinimumLength(2).WithMessage("Client's last name too short")
                    .MaximumLength(20).WithMessage("Client's last name too long")
                    .Matches(@"^[A-Za-z]*$").WithMessage("Invalid last name entered");
            RuleFor(x => x.Address)
                .NotEmpty().WithMessage("Client's address must be entered")
                .MinimumLength(10).WithMessage("Client's address too short")
                .MaximumLength(50).WithMessage("Client's address too long");
            RuleFor(x => x.PhoneNumber)
                .NotEmpty().WithMessage("Phone number must be entered")
                .Matches(@"^(\d{9,15})$").WithMessage("Invalid phone number entered");
        }

        public async Task<bool> IsUnique(Client client, CancellationToken cancellationToken)
        {
            return !await _context.Set<Client>().AnyAsync(c => c.PhoneNumber == client.PhoneNumber && c.Id != client.Id);
        }
    }
}
