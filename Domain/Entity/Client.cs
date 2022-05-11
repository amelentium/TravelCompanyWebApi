namespace TravelCompany.Domain.Entity
{
    public class Client
    {
        private readonly List<Pass> _passes = new();

        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }

        public IEnumerable<Pass> Passes => _passes;
    }
}
