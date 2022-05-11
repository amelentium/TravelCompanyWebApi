using TravelCompany.Domain.Enum;

namespace TravelCompany.Application.DTO
{
    public class CityDTO
    {
        public int Id { get; set; }
        public int? CountryId { get; set; }
        public Climate Climate { get; set; }
        public string? Name { get; set; }
    }
}
