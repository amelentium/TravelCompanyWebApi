using System.Collections.Generic;
using System.Threading.Tasks;
using TravelCompanyWebApi.Infrastructure.Entity;

namespace TravelCompanyWebApi.Service.Interface
{
    public interface ITourService
    {
        Task AddTour(Tour tour);
        Task DeleteTour(int id);
        Task<IEnumerable<Tour>> GetTours();
        Task<Tour> GetTourById(int id);
        IEnumerable<Tour> GetToursByClimateName(string climateName);
        IEnumerable<Tour> GetToursByDurationId(byte durationId);
        IEnumerable<Tour> GetToursByHotelId(int hotelId);
        Task UpdateTour(Tour tour);
    }
}
