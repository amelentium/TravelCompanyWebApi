using TravelCompanyWebApi.BusinessDAL.Entity.Interface;

namespace TravelCompanyWebApi.BusinessDAL.Entity
{
    public partial class Discount : IEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double? Value { get; set; }
    }
}
