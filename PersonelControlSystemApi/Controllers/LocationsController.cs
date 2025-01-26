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

        public LocationsController(ILocationService locationService)
        {
            _locationService = locationService;
        }

        [HttpGet]
        public IActionResult LocationList() 
        {
            var values=_locationService.TGetListAll();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult AddLocation(CreateLocationDto createLocationDto)
        {
            Location location = new Location()
            {
                LocationName = createLocationDto.LocationName
            };
            _locationService.TAdd(location);
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
            Location location = new Location()
            {
                LocationID = updateLocationDto.LocationID,
                LocationName = updateLocationDto.LocationName
            };
            _locationService.TUpdate(location);
            return Ok("Lokasyon Güncelleme İşlemi Gerçekleştirildi.");
        }

        [HttpGet("GetLocation")]
        public IActionResult GetLocation(int id)
        {
            var values = _locationService.TGetByID(id);
            return Ok(values);
        }

    }
}
