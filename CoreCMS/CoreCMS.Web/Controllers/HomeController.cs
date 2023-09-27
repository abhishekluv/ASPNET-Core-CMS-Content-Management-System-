using CoreCMS.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CoreCMS.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPageService _pageService;

        public HomeController(IPageService pageService)
        {
            _pageService = pageService;
        }

        [HttpGet]
        public IActionResult Index(string slug)
        {
            if (string.IsNullOrEmpty(slug))
                slug = "home";

            //checking if a page slug exists in the database
            if (!_pageService.SlugExists(slug))
                return RedirectToAction(nameof(Error));

            var pageFromDb = _pageService.GetPageBySlug(slug);

            //SidebarViewComponent
            TempData["SidebarId"] = pageFromDb.SidebarId;

            if (pageFromDb.IsSidebarVisible)
                ViewBag.Sidebar = true;
            else
                ViewBag.Sidebar = false;

            return View(pageFromDb);
        }

        [HttpGet]
        public IActionResult Error()
        {
            return View();
        }
    }
}