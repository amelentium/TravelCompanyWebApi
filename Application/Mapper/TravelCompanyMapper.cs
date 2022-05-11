using AutoMapper;
using TravelCompany.Application.DTO;
using TravelCompany.Domain.Entity;
using TravelCompanyWebApi.Infrastructure.DTO;

namespace TravelCompany.Application.Mapper
{
    public class TravelCompanyMapper : Profile
    {
        public TravelCompanyMapper()
        {
            CreateMap<City, CityDTO>();
            CreateMap<CityDTO, City>();

            CreateMap<Client, ClientDTO>();
            CreateMap<ClientDTO, Client>();

            CreateMap<Country, CountryDTO>();
            CreateMap<CountryDTO, Country>();

            CreateMap<Discount, DiscountDTO>();
            CreateMap<DiscountDTO, Discount>();

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
