namespace TravelCompany.Domain.Entity
{
    public class Tour
    {
        private readonly List<Pass> _passes = new();

        public int Id { get; set; }
        public int? HotelId { get; set; }
        public byte? Duration { get; set; }
        public string? Name { get; set; }
        public DateTime? StartDate { get; set; }
        public int? Price { get; set; }
        public string? Description { get; set; }

        public Hotel? Hotel { get; set; }
        public IEnumerable<Pass> Passes => _passes;
    }
}
