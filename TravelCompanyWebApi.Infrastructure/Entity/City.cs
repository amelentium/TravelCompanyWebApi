using System.Collections.Generic;

#nullable disable

namespace TravelCompanyWebApi.Infrastructure.Entity
{
    public partial class City : IEntity
    {
        public City()
        {
            Hotels = new HashSet<Hotel>();
        }

        public int Id { get; set; }
        public int? CountryId { get; set; }
        public int? ClimateId { get; set; }
        public string Name { get; set; }

        public virtual Climate Climate { get; set; }
        public virtual Country Country { get; set; }
        public virtual ICollection<Hotel> Hotels { get; set; }
    }
}
