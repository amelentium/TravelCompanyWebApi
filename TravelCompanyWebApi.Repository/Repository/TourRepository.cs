﻿using System.Collections.Generic;
using System.Linq;
using TravelCompanyWebApi.Infrastructure.Context;
using TravelCompanyWebApi.Infrastructure.Entity;
using TravelCompanyWebApi.Repository.Repository.Interface;

namespace TravelCompanyWebApi.Repository.Repository
{
    public class TourRepository : GenericRepository<Tour>, ITourRepository
    {
        public TourRepository(TravelCompanyDBContext context) : base(context) { }

        public IEnumerable<Tour> GetToursByHotelId(int hotelId)
        {
            return _set.Where(t => t.HotelId == hotelId).AsEnumerable();
        }
    }
}
