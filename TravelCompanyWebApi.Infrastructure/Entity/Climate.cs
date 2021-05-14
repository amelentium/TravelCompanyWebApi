using System.Collections.Generic;

namespace TravelCompanyWebApi.Infrastructure.Entity
{
    public partial class Climate : IEntity<byte>
    {
        public Climate()
        {
            Cities = new HashSet<City>();
        }

        public byte Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<City> Cities { get; set; }
    }
}
