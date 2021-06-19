using System.Collections.Generic;
using System.Threading.Tasks;
using TravelCompanyWebApi.Infrastructure.Entity;

namespace TravelCompanyWebApi.Service.Interface
{
    public interface IHotelService
    {
        Task AddHotel(Hotel hotel);
        Task DeleteHotel(int id);
        Task<IEnumerable<Hotel>> GetHotels();
        Task<Hotel> GetHotelById(int id);
        IEnumerable<Hotel> GetHotelsByCityId(int cityId);
        Task UpdateHotel(Hotel hotel);
    }
}
