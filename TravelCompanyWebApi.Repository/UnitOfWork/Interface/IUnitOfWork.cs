using System.Threading.Tasks;
using TravelCompanyWebApi.Repository.Repository.Interface;

namespace TravelCompanyWebApi.Repository.UnitOfWork.Interface
{
    public interface IUnitOfWork
    {
        IClientRepository ClientRepository { get; }
        IClimateRepository ClimateRepository { get; }
        ICountryRepository CountryRepository { get; }
        IDiscountRepository DiscountRepository { get; }
        Task Complete();
    }
}
