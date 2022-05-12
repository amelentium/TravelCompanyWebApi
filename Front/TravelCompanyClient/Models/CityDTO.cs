using System.ComponentModel.DataAnnotations;

namespace TravelCompanyClient.Models
{
    public class CityDTO
    {
        public int Id { get; set; }
        [Required]
        public int? CountryId { get; set; }
        [Required]
        public Climate? Climate { get; set; }
        [Required]
        [MinLength(2)]
        [MaxLength(20)]
        public string? Name { get; set; }
    }
}
