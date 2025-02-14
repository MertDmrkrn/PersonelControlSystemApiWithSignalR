using AutoMapper;
using BusinessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PersonelControlSystemDto.PersonelDto;

namespace PersonelControlSystemApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonelsController : ControllerBase
    {
        private readonly IPersonelService _personelService;
        private readonly IMapper _mapper;

        public PersonelsController(IPersonelService personelService, IMapper mapper)
        {
            _personelService = personelService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult PersonelList()
        {
            var values = _personelService.TGetListAll();
            return Ok(_mapper.Map<List<ResultPersonelDto>>(values));
        }

        [HttpPost]
        public IActionResult CreatePersonel(CreatePersonelDto createPersonelDto)
        {
            var values = _mapper.Map<Personel>(createPersonelDto);
            _personelService.TAdd(values);
            return Ok("Personel Ekleme İşlemi Gerçekleştirildi.");
        }

        [HttpDelete]
        public IActionResult DeletePersonel(int id)
        {
            var values = _personelService.TGetByID(id);
            _personelService.TDelete(values);
            return Ok("Personel Silme İşlemi Gerçekleştirildi.");
        }

        [HttpPut]
        public IActionResult UpdatePersonel(UpdatePersonelDto updatePersonelDto)
        {
            var values = _mapper.Map<Personel>(updatePersonelDto);
            _personelService.TUpdate(values);
            return Ok("Personel Güncelleme İşlemi Gerçekleştirildi.");
        }

        [HttpGet("GetPersonel")]
        public IActionResult GetPersonel(int id)
        {
            var values=_personelService.TGetByID(id);
            return Ok(_mapper.Map<GetPersonelDto>(values));
        }

        [HttpGet("PersonelListWithShiftAndLocation")]
        public IActionResult PersonelListWithShiftAndLocation()
        {
            var context = new Context();
            var values = context.Personels.Include(x => x.Location).Include(y => y.Shift).Select(z => new ResultPersonelWithShiftAndLocation
            {
                PersonelID = z.PersonelID,
                PersonelName = z.PersonelName,
                PersonelTitle = z.PersonelTitle,
                PersonelRegisterNumber = z.PersonelRegisterNumber,
                PersonelShiftDate = z.PersonelShiftDate,
                ShiftHours = z.Shift.ShiftHours,
                LocationName = z.Location.LocationName
            });
            return Ok(values.ToList());
        }
    }
}
