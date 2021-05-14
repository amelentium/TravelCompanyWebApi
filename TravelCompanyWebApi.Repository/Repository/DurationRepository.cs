using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelCompanyWebApi.Infrastructure.Context;
using TravelCompanyWebApi.Infrastructure.Entity;
using TravelCompanyWebApi.Repository.Repository.Interface;

namespace TravelCompanyWebApi.Repository.Repository
{
    public class DurationRepository : GenericRepository<Duration, byte>, IDurationRepository
    {
        public DurationRepository(TravelCompanyDBContext context) : base(context) { }
    }
}
