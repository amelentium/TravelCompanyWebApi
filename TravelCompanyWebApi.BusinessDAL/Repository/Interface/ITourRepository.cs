using System.Collections.Generic;
using System.Threading.Tasks;
using TravelCompanyWebApi.BusinessDAL.Entity;
using TravelCompanyWebApi.BusinessDAL.Repositories.Interfaces;

namespace TravelCompanyWebApi.BusinessDAL.Repository.Interface
{
    public interface ITourRepository : IGenericRepository<Tour, int>
    {
        Task<IEnumerable<Tour>> GetToursByDurationId(int durationId);
        Task<IEnumerable<Tour>> GetToursByHotelId(int hotelId);
    }
}
