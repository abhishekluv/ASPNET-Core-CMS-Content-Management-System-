using CoreCMS.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CoreCMS.Web.ViewComponents
{
    public class SidebarViewComponent : ViewComponent
    {
        private readonly ISidebarService _sidebarService;

        public SidebarViewComponent(ISidebarService sidebarService)
        {
            _sidebarService = sidebarService;
        }

        public IViewComponentResult Invoke()
        {
            int sidebarId = (int)TempData["SidebarId"];
            var sidebar = _sidebarService.GetSidebarById(sidebarId);
            return View(sidebar);
        }
    }
}
