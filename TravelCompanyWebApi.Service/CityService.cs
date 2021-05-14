using System.Collections.Generic;
using System.Threading.Tasks;
using TravelCompanyWebApi.Infrastructure.Entity;
using TravelCompanyWebApi.Repository.Repository.Interface;
using TravelCompanyWebApi.Repository.UnitOfWork.Interface;
using TravelCompanyWebApi.Service.Interface;

namespace TravelCompanyWebApi.Service
{
    public class CityService : ICityService
    {
        private readonly IUnitOfWork _unit;
        private readonly ICityRepository _repository;

        public CityService(IUnitOfWork unitOfWork)
        {
            _unit = unitOfWork;
            _repository = _unit.CityRepository;
        }

        public async Task AddCity(City city)
        {
            await _repository.Add(city);

            await _unit.Complete();
        }

        public async Task DeleteCity(int id)
        {
            await _repository.Delete(id);

            await _unit.Complete();
        }

        public async Task<IEnumerable<City>> GetCities()
        {
            return await _repository.Get();
        }

        public IEnumerable<City> GetCitiesByClimateId(byte climateId)
        {
            return _repository.GetCitiesByClimateId(climateId);
        }

        public IEnumerable<City> GetCitiesByCountryId(int countryId)
        {
            return _repository.GetCitiesByCountryId(countryId);
        }

        public async Task<City> GetCityById(int id)
        {
            return await _repository.GetById(id);
        }

        public async Task UpdateCity(City city)
        {
            _repository.Update(city);

            await _unit.Complete();
        }
    }
}
