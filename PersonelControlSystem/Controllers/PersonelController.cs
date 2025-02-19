using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using PersonelControlSystem.Dtos.LocationDto;
using PersonelControlSystem.Dtos.PersonelDto;
using PersonelControlSystem.Dtos.ShiftDto;
using System.Text;

namespace PersonelControlSystem.Controllers
{
	public class PersonelController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public PersonelController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IActionResult> Index()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7074/api/Personels/PersonelListWithShiftAndLocation");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultPersonelDto>>(jsonData);
				return View(values);
			}
			return View();
		}


		//Personel Ekleme Consume
		[HttpGet]
		public async Task<IActionResult> CreatePersonel()
		{
            var client = _httpClientFactory.CreateClient();

            // Location verisini çek
            var responseMessage1 = await client.GetAsync("https://localhost:7074/api/Location");
            var jsonData1 = await responseMessage1.Content.ReadAsStringAsync();
            var values1 = JsonConvert.DeserializeObject<List<ResultLocationDto>>(jsonData1);
			List<SelectListItem> values2 = (from x in values1
											select new SelectListItem
											{
												Text = x.LocationName,
												Value = x.LocationID.ToString()
											}).ToList();

            // Shift verisini çek
            var responseMessage2 = await client.GetAsync("https://localhost:7074/api/Shift");
            var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
            var values3 = JsonConvert.DeserializeObject<List<ResultShiftDto>>(jsonData2);
			List<SelectListItem> values4 = (from y in values3
											select new SelectListItem
											{
												Text = y.ShiftHours,
												Value = y.ShiftHours.ToString()
											}).ToList();

            ViewBag.v1 = values2;//Location
            ViewBag.v2 = values4;//Shift


            return View();
		}

		[HttpPost]
		public async Task<IActionResult> CreatePersonel(CreatePersonelDto createPersonelDto)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(createPersonelDto);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PostAsync("https://localhost:7074/api/Personels", stringContent);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}


		//Personel Silme Consume
		public async Task<IActionResult> DeletePersonel(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.DeleteAsync($"https://localhost:7074/api/Personels/{id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}


		//Personel Güncelleme Consume
		[HttpGet]
		public async Task<IActionResult> UpdatePersonel(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync($"https://localhost:7074/api/Personels/{id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<UpdatePersonelDto>(jsonData);
				return View(values);
			}
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> UpdatePersonel(UpdatePersonelDto updatePersonelDto)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(updatePersonelDto);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PutAsync("https://localhost:7074/api/Personels", stringContent);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}
	}
}
