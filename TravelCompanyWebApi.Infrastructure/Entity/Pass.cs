using System.Collections.Generic;

#nullable disable

namespace TravelCompanyWebApi.Infrastructure.Entity
{
    public partial class Pass : IEntity
    {
        public Pass()
        {
            PassDiscounts = new HashSet<PassDiscount>();
        }

        public int Id { get; set; }
        public int? ClientId { get; set; }
        public int? TourId { get; set; }
        public int? Count { get; set; }
        public double? TotalDiscount { get; set; }
        public int? FullPrice { get; set; }
        public double? FinalPrice { get; set; }

        public virtual Client Client { get; set; }
        public virtual Tour Tour { get; set; }
        public virtual ICollection<PassDiscount> PassDiscounts { get; set; }
    }
}
