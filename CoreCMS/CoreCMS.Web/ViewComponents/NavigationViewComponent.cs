using CoreCMS.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CoreCMS.Web.ViewComponents
{
    public class NavigationViewComponent : ViewComponent
    {
        private readonly IPageService _pageService;

        public NavigationViewComponent(IPageService pageService)
        {
            _pageService = pageService;
        }

        public IViewComponentResult Invoke()
        {
            var pages = _pageService.GetVisiblePages();
            return View(pages);
        }
    }
}
