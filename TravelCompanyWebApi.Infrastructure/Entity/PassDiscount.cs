#nullable disable

namespace TravelCompanyWebApi.Infrastructure.Entity
{
    public partial class PassDiscount : IEntity
    {
        public int Id { get; set; }
        public int? PassId { get; set; }
        public int? DiscountId { get; set; }

        public virtual Discount Discount { get; set; }
        public virtual Pass Pass { get; set; }
    }
}
