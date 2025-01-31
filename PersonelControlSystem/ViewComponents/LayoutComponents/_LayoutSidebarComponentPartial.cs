using Microsoft.AspNetCore.Mvc;

namespace PersonelControlSystem.ViewComponents.LayoutComponents
{
    public class _LayoutSidebarComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
