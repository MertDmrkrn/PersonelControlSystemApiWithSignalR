using Microsoft.AspNetCore.Mvc;

namespace PersonelControlSystem.ViewComponents.LayoutComponents
{
    public class _LayoutScriptComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
