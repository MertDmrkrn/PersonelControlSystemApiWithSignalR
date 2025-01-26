using AutoMapper;
using EntityLayer.Concrete;
using PersonelControlSystemDto.LocationDto;

namespace PersonelControlSystemApi.Mapping
{
    public class LocationMapping : Profile
    {
        public LocationMapping()
        {
            CreateMap<Location, ResultLocationDto>().ReverseMap();
            CreateMap<Location, CreateLocationDto>().ReverseMap();
            CreateMap<Location, UpdateLocationDto>().ReverseMap();
            CreateMap<Location, GetLocationDto>().ReverseMap();
        }
    }
}
