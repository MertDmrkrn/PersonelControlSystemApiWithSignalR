using AutoMapper;
using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PersonelControlSystemDto.ShiftDto;

namespace PersonelControlSystemApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShiftsController : ControllerBase
    {
        private readonly IShiftService _shiftService;
        private readonly IMapper _mapper;

        public ShiftsController(IShiftService shiftService, IMapper mapper)
        {
            _shiftService = shiftService;
            _mapper = mapper;
        }


        [HttpGet]
        public IActionResult ShiftList()
        {
            var values = _shiftService.TGetListAll();
            return Ok(_mapper.Map<List<ResultShiftDto>>(values));
        }

        [HttpPost]
        public IActionResult CreateShift(CreateShiftDto createShiftDto)
        {
            var values = _mapper.Map<Shift>(createShiftDto);
            _shiftService.TAdd(values);
            return Ok("Vardiya Ekleme İşlemi Gerçekleştirildi.");
        }

        [HttpDelete]
        public IActionResult DeleteShift(int id)
        {
            var values = _shiftService.TGetByID(id);
            _shiftService.TDelete(values);
            return Ok("Vardiya Silme İşlemi Gerçekleştirildi.");
        }

        [HttpPut]
        public IActionResult UpdateShift(UpdateShiftDto updateShiftDto)
        {
            var values = _mapper.Map<Shift>(updateShiftDto);
            _shiftService.TUpdate(values);
            return Ok("Vardiya Güncelleme İşlemi Gerçekleştirildi.");
        }

        [HttpGet("GetShift")]
        public IActionResult GetShift(int id)
        {
            var values= _shiftService.TGetByID(id);
            return Ok(_mapper.Map<GetShiftDto>(values));
        }
    }
}
