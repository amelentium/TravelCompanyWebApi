using System.Threading.Tasks;
using TravelCompanyWebApi.Repository.Repository.Interface;

namespace TravelCompanyWebApi.Repository.UnitOfWork.Interface
{
    public interface IUnitOfWork
    {
        ICityRepository CityRepository { get; }
        IClientRepository ClientRepository { get; }
        IClimateRepository ClimateRepository { get; }
        ICountryRepository CountryRepository { get; }
        IDiscountRepository DiscountRepository { get; }
        IDurationRepository DurationRepository { get; }
        IHotelRepository HotelRepository { get; }
        IPassDiscountRepository PassDiscountRepository { get; }
        IPassRepository PassRepository { get; }
        ITourRepository TourRepository { get; }
        Task Complete();
    }
}
