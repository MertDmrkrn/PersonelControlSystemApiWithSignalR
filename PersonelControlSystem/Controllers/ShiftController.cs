using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PersonelControlSystem.Dtos.NotificationDto;
using PersonelControlSystem.Dtos.ShiftDto;
using System.Text;

namespace PersonelControlSystem.Controllers
{
    public class ShiftController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ShiftController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7074/api/Shifts");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultShiftDto>>(jsonData);
                return View(values);
            }
            return View();
        }


        //Vardiya Ekleme Consume
        [HttpGet]
        public IActionResult CreateShift()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateShift(CreateShiftDto createShiftDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createShiftDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7074/api/Shifts", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }


        //Vardiya Silme Consume
        public async Task<IActionResult> DeleteShift(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7074/api/Shifts/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        //Vardiya Güncelleme Consume
        [HttpGet]
        public async Task<IActionResult> UpdateShift(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7074/api/Shifts/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateShiftDto>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateShift(UpdateShiftDto updateShiftDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateShiftDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7074/api/Shifts/", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
