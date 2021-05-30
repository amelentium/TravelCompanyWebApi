using System.Collections.Generic;
using System.Threading.Tasks;
using TravelCompanyWebApi.Infrastructure.Entity;
using TravelCompanyWebApi.Repository.Repository.Interface;
using TravelCompanyWebApi.Repository.UnitOfWork.Interface;
using TravelCompanyWebApi.Service.Interface;

namespace TravelCompanyWebApi.Service
{
    public class TourService : ITourService
    {
        private readonly IUnitOfWork _unit;
        private readonly ITourRepository _repository;

        public TourService(IUnitOfWork unitOfWork)
        {
            _unit = unitOfWork;
            _repository = _unit.TourRepository;
        }

        public async Task AddTour(Tour tour)
        {
            await _repository.Add(tour);

            await _unit.Complete();
        }

        public async Task DeleteTour(int id)
        {
            await _repository.Delete(id);

            await _unit.Complete();
        }

        public async Task<Tour> GetTourById(int id)
        {
            return await _repository.GetById(id);
        }

        public async Task<IEnumerable<Tour>> GetTours()
        {
            return await _repository.Get();
        }

        public IEnumerable<Tour> GetToursByClimateName(string climateName)
        {
            return _repository.GetToursByClimateName(climateName);
        }

        public IEnumerable<Tour> GetToursByDurationId(byte durationId)
        {
            return _repository.GetToursByHotelId(durationId);
        }

        public IEnumerable<Tour> GetToursByHotelId(int hotelId)
        {
            return _repository.GetToursByHotelId(hotelId);
        }

        public async Task UpdateTour(Tour tour)
        {
            _repository.Update(tour);

            await _unit.Complete();
        }
    }
}
