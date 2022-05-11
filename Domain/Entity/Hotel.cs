namespace TravelCompany.Domain.Entity
{
    public class Hotel
    {
        private readonly List<Tour> _tours = new();

        public int Id { get; set; }
        public int? CityId { get; set; }
        public string? Name { get; set; }
        public int? Stars { get; set; }

        public virtual City? City { get; set; }
        public virtual IEnumerable<Tour> Tours => _tours;
    }
}
