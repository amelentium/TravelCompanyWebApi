namespace TravelCompany.Domain.Entity
{
    public class Country
    {
        private readonly List<City> _cities = new();

        public int Id { get; set; }
        public string? Name { get; set; }

        public virtual IEnumerable<City> Cities => _cities;
    }
}
