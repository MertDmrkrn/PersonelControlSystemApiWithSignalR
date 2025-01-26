using AutoMapper;
using EntityLayer.Concrete;
using PersonelControlSystemDto.PersonelDto;

namespace PersonelControlSystemApi.Mapping
{
    public class PersonelMapping : Profile
    {
        public PersonelMapping()
        {
            CreateMap<Personel, ResultPersonelDto>().ReverseMap();
            CreateMap<Personel, CreatePersonelDto>().ReverseMap();
            CreateMap<Personel, UpdatePersonelDto>().ReverseMap();
            CreateMap<Personel, GetPersonelDto>().ReverseMap();
        }
    }
}
