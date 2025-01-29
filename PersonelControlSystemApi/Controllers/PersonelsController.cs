using AutoMapper;
using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
            var values=_personelService.TGetListAll();
            return Ok(_mapper.Map<List<ResultPersonelDto>>(values));
        }

        [HttpPost]
        public IActionResult CreatePersonel(CreatePersonelDto createPersonelDto)
        {
            var values = _mapper.Map<Personel>(createPersonelDto);
            _personelService.TAdd(values);
            return Ok("Personel Ekleme İşlemi Gerçekleştirildi.");
        }

        
    }
}
