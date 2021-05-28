using System;
using TravelCompanyWebApi.BusinessDAL.Entity.Interface;

namespace TravelCompanyWebApi.BusinessDAL.Entity
{
    public partial class Tour : IEntity<int>
    {
        public int Id { get; set; }
        public int? HotelId { get; set; }
        public byte? DurationId { get; set; }
        public string Name { get; set; }
        public DateTime? StartDate { get; set; }
        public int? Price { get; set; }
        public string Description { get; set; }
    }
}
