using System.Collections.Generic;

namespace TravelCompanyWebApi.Infrastructure.Entity
{
    public partial class Hotel : IEntity<int>
    {
        public Hotel()
        {
            Tours = new HashSet<Tour>();
        }

        public int Id { get; set; }
        public int? CityId { get; set; }
        public string Name { get; set; }
        public int? Stars { get; set; }

        public virtual City City { get; set; }
        public virtual ICollection<Tour> Tours { get; set; }
    }
}
