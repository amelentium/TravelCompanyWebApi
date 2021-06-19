using TravelCompanyWebApi.Infrastructure.Context;
using TravelCompanyWebApi.Infrastructure.Entity;
using TravelCompanyWebApi.Repository.Repository.Interface;

namespace TravelCompanyWebApi.Repository.Repository
{
    public class ClimateRepository : GenericRepository<Climate, byte>, IClimateRepository
    {
        public ClimateRepository(TravelCompanyDBContext context) : base(context) { }
    }
}
