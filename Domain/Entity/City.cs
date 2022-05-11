using TravelCompany.Domain.Enum;

namespace TravelCompany.Domain.Entity
{
    public class City
    {
        private readonly List<Hotel> _hotels = new();

        public int Id { get; set; }
        public int? CountryId { get; set; }
        public Climate Climate { get; set; }
        public string? Name { get; set; }

        public virtual Country? Country { get; set; }
        public virtual IEnumerable<Hotel> Hotels => _hotels;
    }
}
