using AutoMapper;
using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PersonelControlSystemDto.NotificationDto;

namespace PersonelControlSystemApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationsController : ControllerBase
    {
        private readonly INotificationService _notificationService;
        private readonly IMapper _mapper;

        public NotificationsController(INotificationService notificationService, IMapper mapper)
        {
            _notificationService = notificationService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult NotificationList()
        {
            var values = _notificationService.TGetListAll();
            return Ok(_mapper.Map<List<ResultNotificationDto>>(values));
        }

        [HttpPost]
        public IActionResult CreateNotification(CreateNotificationDto createNotificationDto)
        {
            var values = _mapper.Map<Notification>(createNotificationDto);
            _notificationService.TAdd(values);
            return Ok("Bildirim Ekleme İşlemi Gerçekleştirildi.");
        }

        [HttpDelete]
        public IActionResult DeleteNotification(int id)
        {
            var values = _notificationService.TGetByID(id);
            _notificationService.TDelete(values);
            return Ok("Bildirim Silme İşlemi Gerçekleştirildi.");
        }

        [HttpPut]
        public IActionResult UpdateNotification(UpdateNotificationDto updateNotificationDto)
        {
            var values = _mapper.Map<Notification>(updateNotificationDto);
            _notificationService.TUpdate(values);
            return Ok("Bildirim Güncelleme İşlemi Gerçekleştirildi.");
        }

        [HttpGet("GetNotification")]
        public IActionResult GetNotification(int id)
        {
            var values=_notificationService.TGetByID(id);
            return Ok(_mapper.Map<GetNotificationDto>(values));
        }
    }
}
