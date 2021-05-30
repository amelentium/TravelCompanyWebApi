using System;
using System.Collections.Generic;
using System.Linq;
using TravelCompanyWebApi.Infrastructure.Context;
using TravelCompanyWebApi.Infrastructure.Entity;
using TravelCompanyWebApi.Repository.Repository.Interface;

namespace TravelCompanyWebApi.Repository.Repository
{
    public class TourRepository : GenericRepository<Tour, int>, ITourRepository
    {
        public TourRepository(TravelCompanyDBContext context) : base(context) { }

        public IEnumerable<Tour> GetToursByClimateName(string cimateName)
        {
            var climate = _context.Climates.Where(c => c.Name == cimateName).FirstOrDefault();
            if (climate == null) throw new Exception("There is no climate with this name.");

            var cities = _context.Cities.Where(c => c.ClimateId == climate.Id);
            if (!cities.Any()) throw new Exception("No cities was found for this climate.");

            var hotels = _context.Hotels.Where(h => cities.Any(c => c.Id == h.CityId));
            if (!hotels.Any()) throw new Exception("No hotels was found for cities with this climate.");

            return _set.Where(t => hotels.Any(h => h.Id == t.HotelId)).AsEnumerable();
        }

        public IEnumerable<Tour> GetToursByDurationId(int durationId)
        {
            return _set.Where(t => t.DurationId == durationId).AsEnumerable();
        }

        public IEnumerable<Tour> GetToursByHotelId(int hotelId)
        {
            return _set.Where(t => t.HotelId == hotelId).AsEnumerable();
        }
    }
}
