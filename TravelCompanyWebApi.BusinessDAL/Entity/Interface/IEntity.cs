namespace TravelCompanyWebApi.BusinessDAL.Entity.Interface
{
    public interface IEntity<T>
    {
        T Id { get; set; }
    }
}
