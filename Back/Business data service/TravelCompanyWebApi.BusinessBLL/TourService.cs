using System.Collections.Generic;
using System.Threading.Tasks;
using TravelCompanyWebApi.BusinessBLL.Interface;
using TravelCompanyWebApi.BusinessDAL.Entity;
using TravelCompanyWebApi.BusinessDAL.Repository.Interface;

namespace TravelCompanyWebApi.BusinessBLL
{
    public class TourService : ITourService
    {
        readonly IUnitOfWork _unitOfWork;
        public TourService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task AddTour(Tour tour)
        {
            await _unitOfWork.TourRepository.Add(tour);
        }

        public async Task DeleteTour(int Id)
        {
            await _unitOfWork.TourRepository.Delete(Id);
        }

        public async Task<IEnumerable<Tour>> GetAllTours()
        {
            return await _unitOfWork.TourRepository.GetAll();
        }

        public async Task<Tour> GetTourById(int Id)
        {
            return await _unitOfWork.TourRepository.Get(Id);
        }

        public async Task<IEnumerable<Tour>> GetToursByDurationId(byte durationId)
        {
            return await _unitOfWork.TourRepository.GetToursByDurationId(durationId);
        }

        public async Task<IEnumerable<Tour>> GetToursByHotelId(int hotelId)
        {
            return await _unitOfWork.TourRepository.GetToursByHotelId(hotelId);
        }

        public async Task UpdateTour(Tour tour, int Id)
        {
            await _unitOfWork.TourRepository.Update(tour, Id);
        }
    }
}
