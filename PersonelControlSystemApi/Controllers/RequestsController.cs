using AutoMapper;
using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PersonelControlSystemDto.RequestDto;

namespace PersonelControlSystemApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestsController : ControllerBase
    {
        private readonly IRequestService _requestService;
        private readonly IMapper _mapper;

        public RequestsController(IRequestService requestService, IMapper mapper)
        {
            _requestService = requestService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult RequestList()
        {
            var values = _requestService.TGetListAll();
            return Ok(_mapper.Map<List<ResultRequestDto>>(values));
        }

        [HttpPost]
        public IActionResult CreateRequest(CreateRequestDto createRequestDto)
        {
            var values = _mapper.Map<Request>(createRequestDto);
            _requestService.TAdd(values);
            return Ok("İstek Ekleme İşlemi Gerçekleştirildi.");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteRequest(int id)
        {
            var values = _requestService.TGetByID(id);
            _requestService.TDelete(values);
            return Ok("İstek Silme İşlemi Gerçekleştirildi.");
        }
        [HttpPut]
        public IActionResult UpdateRequest(UpdateRequestDto updateRequestDto)
        {
            var values = _mapper.Map<Request>(updateRequestDto);
            _requestService.TUpdate(values);
            return Ok("İstek Güncelleme İşlemi Gerçekleştirildi.");
        }

        [HttpGet("{id}")]
        public IActionResult GetRequest(int id)
        {
            var values= _requestService.TGetByID(id);
            return Ok(_mapper.Map<GetRequestDto>(values));
        }
    }
}
