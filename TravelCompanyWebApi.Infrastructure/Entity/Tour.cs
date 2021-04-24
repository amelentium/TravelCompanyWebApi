using System.Collections.Generic;

#nullable disable

namespace TravelCompanyWebApi.Infrastructure.Entity
{
    public partial class Tour : IEntity
    {
        public Tour()
        {
            Passes = new HashSet<Pass>();
        }

        public int Id { get; set; }
        public int? HotelId { get; set; }
        public int? Duration { get; set; }
        public int? Price { get; set; }
        public string Description { get; set; }

        public virtual Hotel Hotel { get; set; }
        public virtual ICollection<Pass> Passes { get; set; }
    }
}
