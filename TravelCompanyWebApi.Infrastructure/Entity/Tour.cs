using System;
using System.Collections.Generic;

namespace TravelCompanyWebApi.Infrastructure.Entity
{
    public partial class Tour : IEntity<int>
    {
        public Tour()
        {
            Passes = new HashSet<Pass>();
        }

        public int Id { get; set; }
        public int? HotelId { get; set; }
        public byte? DurationId { get; set; }
        public string Name { get; set; }
        public DateTime? StartDate { get; set; }
        public int? Price { get; set; }
        public string Description { get; set; }

        public virtual Duration Duration { get; set; }
        public virtual Hotel Hotel { get; set; }
        public virtual ICollection<Pass> Passes { get; set; }
    }
}
