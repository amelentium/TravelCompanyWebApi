namespace TravelCompany.Domain.Entity
{
    public class PassDiscount
    {
        public int Id { get; set; }
        public int? PassId { get; set; }
        public int? DiscountId { get; set; }

        public Discount? Discount { get; set; }
        public Pass? Pass { get; set; }
    }
}
