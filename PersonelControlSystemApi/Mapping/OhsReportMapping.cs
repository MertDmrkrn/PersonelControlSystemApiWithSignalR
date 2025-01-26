using AutoMapper;
using EntityLayer.Concrete;
using PersonelControlSystemDto.OhsReportDto;

namespace PersonelControlSystemApi.Mapping
{
    public class OhsReportMapping:Profile
    {
        public OhsReportMapping()
        {
            CreateMap<OhsReport, ResultOhsReportDto>().ReverseMap();
            CreateMap<OhsReport, CreateOhsReportDto>().ReverseMap();
            CreateMap<OhsReport, UpdateOhsReportDto>().ReverseMap();
            CreateMap<OhsReport, GetOhsReportDto>().ReverseMap();
        }
    }
}
