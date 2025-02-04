using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PersonelControlSystem.Dtos.ShiftDto;

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
			var client=_httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7074/api/Shifts");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData=await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultShiftDto>>(jsonData);
				return View(values);
			}
			return View();
		}
	}
}
