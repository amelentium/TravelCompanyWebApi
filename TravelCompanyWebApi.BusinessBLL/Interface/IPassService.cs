using System.Collections.Generic;
using System.Threading.Tasks;
using TravelCompanyWebApi.BusinessDAL.Entity;

namespace TravelCompanyWebApi.BusinessBLL.Interface
{
    public interface IPassService
    {
        Task AddPass(Pass pass);

        Task UpdatePass(Pass pass, int Id);

        Task DeletePass(int Id);

        Task<Pass> GetPassById(int Id);

        Task<IEnumerable<Pass>> GetAllPasses();
    }
}
