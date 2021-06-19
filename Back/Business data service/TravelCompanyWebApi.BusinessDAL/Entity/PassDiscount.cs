using TravelCompanyWebApi.BusinessDAL.Entity.Interface;

namespace TravelCompanyWebApi.BusinessDAL.Entity
{
    public partial class PassDiscount : IEntity<int>
    {
        public int Id { get; set; }
        public int? PassId { get; set; }
        public int? DiscountId { get; set; }
    }
}
