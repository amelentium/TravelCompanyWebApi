namespace TravelCompanyClient.Models
{
    public class TourDTO
    {
        public int Id { get; set; }
        public int? HotelId { get; set; }
        public int? Duration { get; set; }
        public int? Price { get; set; }
        public string Description { get; set; }
    }
}
