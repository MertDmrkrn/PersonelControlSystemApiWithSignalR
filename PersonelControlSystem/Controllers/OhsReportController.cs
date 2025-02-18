using Microsoft.AspNetCore.Mvc;

namespace PersonelControlSystem.Controllers
{
    public class OhsReportController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public OhsReportController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
