using System.Collections.Generic;
using System.Threading.Tasks;
using TravelCompanyWebApi.Infrastructure.Entity;
using TravelCompanyWebApi.Repository.Repository.Interface;
using TravelCompanyWebApi.Repository.UnitOfWork.Interface;
using TravelCompanyWebApi.Service.Interface;

namespace TravelCompanyWebApi.Service
{
    public class HotelService : IHotelService
    {
        private readonly IUnitOfWork _unit;
        private readonly IHotelRepository _repository;

        public HotelService(IUnitOfWork unitOfWork)
        {
            _unit = unitOfWork;
            _repository = _unit.HotelRepository;
        }

        public async Task AddHotel(Hotel hotel)
        {
            await _repository.Add(hotel);

            await _unit.Complete();
        }

        public async Task DeleteHotel(int id)
        {
            await _repository.Delete(id);

            await _unit.Complete();
        }

        public async Task<Hotel> GetHotelById(int id)
        {
            return await _repository.GetById(id);
        }

        public async Task<IEnumerable<Hotel>> GetHotels()
        {
            return await _repository.Get();
        }

        public IEnumerable<Hotel> GetHotelsByCityId(int cityId)
        {
            return _repository.GetHotelsByCityId(cityId);
        }

        public async Task UpdateHotel(Hotel hotel)
        {
            _repository.Update(hotel);

            await _unit.Complete();
        }
    }
}
