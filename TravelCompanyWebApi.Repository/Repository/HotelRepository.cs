using System.Collections.Generic;
using System.Linq;
using TravelCompanyWebApi.Infrastructure.Context;
using TravelCompanyWebApi.Infrastructure.Entity;
using TravelCompanyWebApi.Repository.Repository.Interface;

namespace TravelCompanyWebApi.Repository.Repository
{
    public class HotelRepository : GenericRepository<Hotel, int>, IHotelRepository
    {
        public HotelRepository(TravelCompanyDBContext context) : base(context) { }

        public IEnumerable<Hotel> GetHotelsByCityId(int cityId)
        {
            return _set.Where(h => h.CityId == cityId).AsEnumerable();
        }
    }
}
