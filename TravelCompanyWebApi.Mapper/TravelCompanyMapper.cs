using AutoMapper;
using System.Collections.Generic;
using TravelCompanyWebApi.Infrastructure.DTO;
using TravelCompanyWebApi.Infrastructure.Entity;

namespace TravelCompanyWebApi.Mapper
{
    public class TravelCompanyMapper : Profile
    {
        public TravelCompanyMapper()
        {
            CreateMap<City, CityDTO>();
            CreateMap<CityDTO, City>();

            CreateMap<Client, ClientDTO>();
            CreateMap<ClientDTO, Client>();

            CreateMap<Climate, ClimateDTO>();
            CreateMap<ClimateDTO, Climate>();

            CreateMap<Country, CountryDTO>();
            CreateMap<CountryDTO, Country>();

            CreateMap<Discount, DiscountDTO>();
            CreateMap<DiscountDTO, Discount>();

            CreateMap<Hotel, HotelDTO>();
            CreateMap<HotelDTO, Hotel>();

            CreateMap<Pass, PassDTO>();
            CreateMap<PassDTO, Pass>();

            CreateMap<PassDiscount, PassDiscountDTO>();
            CreateMap<PassDiscountDTO, PassDiscount>();

            CreateMap<Tour, TourDTO>();
            CreateMap<TourDTO, Tour>();
        }
    }
}
