﻿using System.Collections.Generic;
using TravelCompanyWebApi.Infrastructure.Entity;

namespace TravelCompanyWebApi.Repository.Repository.Interface
{
    public interface ITourRepository : IGenericRepository<Tour, int>
    {
        IEnumerable<Tour> GetToursByHotelId(int hotelId);
    }
}
