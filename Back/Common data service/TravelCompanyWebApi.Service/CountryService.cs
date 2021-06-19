using System.Collections.Generic;
using System.Threading.Tasks;
using TravelCompanyWebApi.Infrastructure.Entity;
using TravelCompanyWebApi.Repository.Repository.Interface;
using TravelCompanyWebApi.Repository.UnitOfWork.Interface;
using TravelCompanyWebApi.Service.Interface;

namespace TravelCompanyWebApi.Service
{
    public class CountryService : ICountryService
    {
        private readonly IUnitOfWork _unit;
        private readonly ICountryRepository _repository;

        public CountryService(IUnitOfWork unitOfWork)
        {
            _unit = unitOfWork;
            _repository = _unit.CountryRepository;
        }

        public async Task AddCountry(Country country)
        {
            await _repository.Add(country);

            await _unit.Complete();
        }

        public async Task DeleteCountry(int id)
        {
            await _repository.Delete(id);

            await _unit.Complete();
        }

        public async Task<IEnumerable<Country>> GetCountries()
        {
            return await _repository.Get();
        }

        public async Task<Country> GetCountryById(int id)
        {
            return await _repository.GetById(id);
        }

        public async Task UpdateCountry(Country country)
        {
            _repository.Update(country);
            
            await _unit.Complete();
        }
    }
}
