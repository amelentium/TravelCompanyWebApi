using TravelCompanyWebApi.BusinessDAL.Repository.Interface;

namespace TravelCompanyWebApi.BusinessDAL.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDiscountRepository _discountRepository;

        private readonly IPassDiscountRepository _passDiscountRepository;

        private readonly IPassRepository _passRepository;

        private readonly ITourRepository _tourRepository;

        public UnitOfWork(IDiscountRepository discountRepository,
            IPassDiscountRepository passDiscountRepository,
            IPassRepository passRepository,
            ITourRepository tourRepository)
        {
            _discountRepository = discountRepository;
            _passDiscountRepository = passDiscountRepository;
            _passRepository = passRepository;
            _tourRepository = tourRepository;
        }

        public IDiscountRepository DiscountRepository { get => _discountRepository; }

        public IPassDiscountRepository PassDiscountRepository { get => _passDiscountRepository; }

        public IPassRepository PassRepository { get => _passRepository; }

        public ITourRepository TourRepository { get => _tourRepository; }
    }
}
