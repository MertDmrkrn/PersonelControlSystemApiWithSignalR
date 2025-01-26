using AutoMapper;
using EntityLayer.Concrete;
using PersonelControlSystemDto.ShiftDto;

namespace PersonelControlSystemApi.Mapping
{
    public class ShiftMapping : Profile
    {
        public ShiftMapping()
        {
            CreateMap<Shift, ResultShiftDto>().ReverseMap();
            CreateMap<Shift, CreateShiftDto>().ReverseMap();
            CreateMap<Shift, UpdateShiftDto>().ReverseMap();
            CreateMap<Shift, GetShiftDto>().ReverseMap();
        }
    }
}
