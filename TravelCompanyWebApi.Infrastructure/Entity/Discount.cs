using System.Collections.Generic;

namespace TravelCompanyWebApi.Infrastructure.Entity
{
    public partial class Discount : IEntity<int>
    {
        public Discount()
        {
            PassDiscounts = new HashSet<PassDiscount>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public double? Value { get; set; }

        public virtual ICollection<PassDiscount> PassDiscounts { get; set; }
    }
}
