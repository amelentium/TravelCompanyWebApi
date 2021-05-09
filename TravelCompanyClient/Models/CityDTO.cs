namespace TravelCompanyClient.Models
{
    public class CityDTO
    {
        public int Id { get; set; }
        public int? CountryId { get; set; }
        public int? ClimateId { get; set; }
        public string Name { get; set; }
    }
}
