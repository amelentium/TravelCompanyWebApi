using System.Collections.Generic;
using TravelCompanyWebApi.Infrastructure.Entity;

namespace TravelCompanyWebApi.Repository.Repository.Interface
{
    public interface IHotelRepository : IGenericRepository<Hotel>
    {
        IEnumerable<Hotel> GetHotelsByCityId(int cityId);
    }
}
