namespace TravelCompany.Domain.Entity
{
    public class Pass
    {
        private readonly List<PassDiscount> _passDiscounts = new();

        public int Id { get; set; }
        public int? ClientId { get; set; }
        public int? TourId { get; set; }
        public int? Count { get; set; }
        public double? TotalDiscount { get; set; }
        public int? FullPrice { get; set; }
        public double? FinalPrice { get; set; }
        public DateTime? PurchaseDate { get; set; }

        public Client? Client { get; set; }
        public Tour? Tour { get; set; }
        public IEnumerable<PassDiscount> PassDiscounts => _passDiscounts;
    }
}
