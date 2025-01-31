using Microsoft.AspNetCore.Mvc;

namespace PersonelControlSystem.Controllers
{
    public class AdminLayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
