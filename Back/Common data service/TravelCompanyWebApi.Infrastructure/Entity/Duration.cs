using System.Collections.Generic;

namespace TravelCompanyWebApi.Infrastructure.Entity
{
    public partial class Duration : IEntity<byte>
    {
        public Duration()
        {
            Tours = new HashSet<Tour>();
        }

        public byte Id { get; set; }
        public byte? Time { get; set; }

        public virtual ICollection<Tour> Tours { get; set; }
    }
}
