using System.Collections.Generic;
using System.Threading.Tasks;
using TravelCompanyWebApi.BusinessBLL.Interface;
using TravelCompanyWebApi.BusinessDAL.Entity;
using TravelCompanyWebApi.BusinessDAL.Repository.Interface;

namespace TravelCompanyWebApi.BusinessBLL
{
    public class PassService : IPassService
    {
        readonly IUnitOfWork _unitOfWork;
        public PassService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task AddPass(Pass pass)
        {
            await _unitOfWork.PassRepository.Add(pass);
        }

        public async Task DeletePass(int Id)
        {
            await _unitOfWork.PassRepository.Delete(Id);
        }

        public async Task<IEnumerable<Pass>> GetAllPasses()
        {
            return await _unitOfWork.PassRepository.GetAll();
        }

        public async Task<Pass> GetPassById(int Id)
        {
            return await _unitOfWork.PassRepository.Get(Id);
        }

        public async Task<IEnumerable<Pass>> GetPassesByClientId(int clientId)
        {
            return await _unitOfWork.PassRepository.GetPassesByClientId(clientId);
        }

        public async Task<IEnumerable<Pass>> GetPassesByTourId(int tourId)
        {
            return await _unitOfWork.PassRepository.GetPassesByTourId(tourId);
        }

        public async Task UpdatePass(Pass pass, int Id)
        {
            await _unitOfWork.PassRepository.Update(pass, Id);
        }
    }
}
