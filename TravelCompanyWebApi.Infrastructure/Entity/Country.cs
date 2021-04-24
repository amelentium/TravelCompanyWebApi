using System.Collections.Generic;

#nullable disable

namespace TravelCompanyWebApi.Infrastructure.Entity
{
    public partial class Country : IEntity
    {
        public Country()
        {
            Cities = new HashSet<City>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<City> Cities { get; set; }
    }
}
