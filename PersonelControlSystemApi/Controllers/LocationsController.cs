using AutoMapper;
using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PersonelControlSystemDto.LocationDto;

namespace PersonelControlSystemApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationsController : ControllerBase
    {
        private readonly ILocationService _locationService;
        private readonly IMapper _mapper;

        public LocationsController(ILocationService locationService, IMapper mapper)
        {
            _locationService = locationService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult LocationList() 
        {
            var values=_locationService.TGetListAll();
            return Ok(_mapper.Map<List<ResultLocationDto>>(values));
        }

        [HttpPost]
        public IActionResult AddLocation(CreateLocationDto createLocationDto)
        {
            var value = _mapper.Map<Location>(createLocationDto);
            _locationService.TAdd(value);
            return Ok("Lokasyon Ekleme İşlemi Gerçekleştirildi.");
        }

        [HttpDelete]
        public IActionResult DeleteLocation(int id) 
        {
            var values=_locationService.TGetByID(id);
            _locationService.TDelete(values);
            return Ok("Lokasyon Silme İşlemi Gerçekleştirildi.");
        }

        [HttpPut]
        public IActionResult UpdateLocation(UpdateLocationDto updateLocationDto)
        {
            var value=_mapper.Map<Location>(updateLocationDto);
            _locationService.TUpdate(value);
            return Ok("Lokasyon Güncelleme İşlemi Gerçekleştirildi.");
        }

        [HttpGet("GetLocation")]
        public IActionResult GetLocation(int id)
        {
            var values = _locationService.TGetByID(id);
            return Ok(_mapper.Map<GetLocationDto>(values));
        }

    }
}
