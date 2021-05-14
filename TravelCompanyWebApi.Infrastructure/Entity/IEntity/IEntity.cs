namespace TravelCompanyWebApi.Infrastructure.Entity
{
    public interface IEntity<TId>
    {
        TId Id { get; set; }
    }
}
