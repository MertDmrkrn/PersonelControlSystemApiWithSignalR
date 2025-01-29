using AutoMapper;
using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PersonelControlSystemDto.OhsReportDto;

namespace PersonelControlSystemApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OhsReportsController : ControllerBase
    {
        private readonly IOhsReportService _ohsReportService;
        private readonly IMapper _mapper;

        public OhsReportsController(IOhsReportService ohsReportService, IMapper mapper)
        {
            _ohsReportService = ohsReportService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult OhsReportList()
        {
            var values = _ohsReportService.TGetListAll();
            return Ok(_mapper.Map<List<ResultOhsReportDto>>(values));
        }

        [HttpPost]
        public IActionResult CreateOhsReport(CreateOhsReportDto createOhsReport)
        {
            var values = _mapper.Map<OhsReport>(createOhsReport);
            _ohsReportService.TAdd(values);
            return Ok("İş Sağlığı Güvenliği Raporu Ekleme İşlemi Gerçekleştirildi.");
        }

        [HttpDelete]
        public IActionResult DeleteOhsReport(int id)
        {
            var values = _ohsReportService.TGetByID(id);
            _ohsReportService.TDelete(values);
            return Ok("İş Sağlığı Güvenliği Raporu Silme İşlemi Gerçekleştirildi.");
        }

        [HttpPut]
        public IActionResult UpdateOhsReport(UpdateOhsReportDto updateOhsReportDto)
        {
            var values = _mapper.Map<OhsReport>(updateOhsReportDto);
            _ohsReportService.TUpdate(values);
            return Ok("İş Sağlığı Güvenliği Raporu Güncelleme İşlemi Gerçekleştirildi.");
        }

        [HttpGet("GetOhsReport")]
        public IActionResult GetOhsReport(int id)
        {
            var values = _ohsReportService.TGetByID(id);
            return Ok(_mapper.Map<GetOhsReportDto>(values));
        }

    }
}
