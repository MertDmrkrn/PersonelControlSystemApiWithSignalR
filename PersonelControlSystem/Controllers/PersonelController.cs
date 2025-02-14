using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PersonelControlSystem.Dtos.PersonelDto;
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
		public IActionResult CreatePersonel()
		{
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
