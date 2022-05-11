namespace TravelCompany.Domain.Entity
{
    public class Discount
    {
        private readonly List<PassDiscount> _passDiscounts = new();

        public int Id { get; set; }
        public string? Name { get; set; }
        public double? Value { get; set; }

        public IEnumerable<PassDiscount> PassDiscounts => _passDiscounts;
    }
}
