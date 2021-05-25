using AutoMapper;
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

            CreateMap<Duration, DurationDTO>();
            CreateMap<DurationDTO, Duration>();

            CreateMap<Hotel, HotelDTO>();
            CreateMap<HotelDTO, Hotel>();

            CreateMap<Pass, PassOutputDTO>();
            CreateMap<PassInputDTO, Pass>();

            CreateMap<PassDiscount, PassDiscountDTO>();
            CreateMap<PassDiscountDTO, PassDiscount>();

            CreateMap<Tour, TourDTO>();
            CreateMap<TourDTO, Tour>();
        }
    }
}
