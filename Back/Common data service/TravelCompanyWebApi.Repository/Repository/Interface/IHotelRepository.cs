using System.Collections.Generic;
using TravelCompanyWebApi.Infrastructure.Entity;

namespace TravelCompanyWebApi.Repository.Repository.Interface
{
    public interface IHotelRepository : IGenericRepository<Hotel, int>
    {
        IEnumerable<Hotel> GetHotelsByCityId(int cityId);
    }
}
