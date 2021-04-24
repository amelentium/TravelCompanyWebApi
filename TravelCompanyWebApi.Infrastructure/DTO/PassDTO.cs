﻿namespace TravelCompanyWebApi.Infrastructure.DTO
{
    public class PassDTO
    {

        public int Id { get; set; }
        public int? ClientId { get; set; }
        public int? TourId { get; set; }
        public int? Count { get; set; }
        public double? TotalDiscount { get; set; }
        public double? FinalPrice { get; set; }
    }
}
