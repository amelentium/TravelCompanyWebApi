namespace TravelCompanyClient.Models
{
    public class HotelDTO
    {
        public int Id { get; set; }
        public int? CityId { get; set; }
        public string? Name { get; set; }
        public int? Stars { get; set; }
    }
}
