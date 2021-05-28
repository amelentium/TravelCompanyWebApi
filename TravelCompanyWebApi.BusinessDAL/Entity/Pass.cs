﻿using System;
using TravelCompanyWebApi.BusinessDAL.Entity.Interface;

namespace TravelCompanyWebApi.BusinessDAL.Entity
{
    public partial class Pass : IEntity<int>
    {
        public int Id { get; set; }
        public int? ClientId { get; set; }
        public int? TourId { get; set; }
        public int? Count { get; set; }
        public double? TotalDiscount { get; set; }
        public int? FullPrice { get; set; }
        public double? FinalPrice { get; set; }
        public DateTime? PurchaseDate { get; set; }
    }
}
