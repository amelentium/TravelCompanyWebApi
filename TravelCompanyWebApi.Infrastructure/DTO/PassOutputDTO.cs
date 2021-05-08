using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelCompanyWebApi.Infrastructure.DTO
{
    public class PassOutputDTO
    {
        public int Id { get; set; }
        public int? ClientId { get; set; }
        public int? TourId { get; set; }
        public int? Count { get; set; }
        public double? TotalDiscount { get; set; }
        public int? FullPrice { get; set; }
        public double? FinalPrice { get; set; }
    }
}
