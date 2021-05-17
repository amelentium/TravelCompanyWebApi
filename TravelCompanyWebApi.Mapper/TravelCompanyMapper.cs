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
            CreateMap<CityDTO, City>()
                .ForMember(x =>
                    x.Climate, map =>
                    map.MapFrom(source =>
                        new Climate
                        {
                            Id = (byte)source.ClimateId
                        }))
                .ForMember(x =>
                    x.Country, map =>
                    map.MapFrom(source =>
                        new Country
                        {
                            Id = (byte)source.CountryId
                        }));

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
            CreateMap<HotelDTO, Hotel>()
                .ForMember(x => 
                    x.City, map => 
                    map.MapFrom( source => 
                        new City 
                        { 
                            Id = (int)source.CityId
                        }));

            CreateMap<Pass, PassOutputDTO>();
            CreateMap<PassInputDTO, Pass>()
                .ForMember(x =>
                    x.Client, map =>
                    map.MapFrom(source =>
                       new Client
                       {
                           Id = (int)source.ClientId
                       }))
                .ForMember(x =>
                    x.Tour, map =>
                    map.MapFrom(source =>
                       new Tour
                       {
                           Id = (int)source.TourId
                       }));

            CreateMap<PassDiscount, PassDiscountDTO>();
            CreateMap<PassDiscountDTO, PassDiscount>()
                .ForMember(x =>
                    x.Discount, map =>
                    map.MapFrom(source =>
                       new Discount
                       {
                           Id = (int)source.DiscountId
                       }))
                .ForMember(x =>
                    x.Pass, map =>
                    map.MapFrom(source =>
                       new Pass
                       {
                           Id = (int)source.PassId
                       }));

            CreateMap<Tour, TourDTO>();
            CreateMap<TourDTO, Tour>()
                .ForMember(x =>
                    x.Hotel, map =>
                    map.MapFrom(source =>
                       new Hotel
                       {
                           Id = (int)source.HotelId
                       }))
                .ForMember(x =>
                    x.Duration, map =>
                    map.MapFrom(source =>
                       new Duration
                       {
                           Id = (byte)source.DurationId
                       }));
        }
    }
}
