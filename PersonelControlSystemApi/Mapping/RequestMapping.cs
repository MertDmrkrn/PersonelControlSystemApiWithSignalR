using AutoMapper;
using EntityLayer.Concrete;
using PersonelControlSystemDto.RequestDto;

namespace PersonelControlSystemApi.Mapping
{
    public class RequestMapping:Profile
    {
        public RequestMapping()
        {
            CreateMap<Request,ResultRequestDto>().ReverseMap();
            CreateMap<Request,CreateRequestDto>().ReverseMap();
            CreateMap<Request,UpdateRequestDto>().ReverseMap();
            CreateMap<Request,GetRequestDto>().ReverseMap();
        }
    }
}
