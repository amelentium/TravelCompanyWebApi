using System.Collections.Generic;
using System.Threading.Tasks;
using TravelCompanyWebApi.BusinessDAL.Entity;

namespace TravelCompanyWebApi.BusinessBLL.Interface
{
    public interface ITourService
    {
        Task AddTour(Tour pass);

        Task UpdateTour(Tour pass, int Id);

        Task DeleteTour(int Id);

        Task<Tour> GetTourById(int Id);

        Task<IEnumerable<Tour>> GetAllTours();
    }
}
