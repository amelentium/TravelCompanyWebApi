namespace TravelCompanyWebApi.BusinessDAL.Repository.Interface
{
    public interface IUnitOfWork
    {
        IDiscountRepository DiscountRepository { get; }
        IPassDiscountRepository PassDiscountRepository { get; }
        IPassRepository PassRepository { get; }
        ITourRepository TourRepository { get; }
    }
}
