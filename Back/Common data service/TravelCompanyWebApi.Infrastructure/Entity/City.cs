using System.Collections.Generic;

namespace TravelCompanyWebApi.Infrastructure.Entity
{
    public partial class City : IEntity<int>
    {
        public City()
        {
            Hotels = new HashSet<Hotel>();
        }

        public int Id { get; set; }
        public int? CountryId { get; set; }
        public byte? ClimateId { get; set; }
        public string Name { get; set; }

        public virtual Climate Climate { get; set; }
        public virtual Country Country { get; set; }
        public virtual ICollection<Hotel> Hotels { get; set; }
    }
}
