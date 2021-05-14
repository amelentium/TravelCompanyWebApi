namespace TravelCompanyWebApi.Infrastructure.DTO
{
    public class CityDTO
    {
        public int Id { get; set; }
        public int? CountryId { get; set; }
        public byte? ClimateId { get; set; }
        public string Name { get; set; }
    }
}
