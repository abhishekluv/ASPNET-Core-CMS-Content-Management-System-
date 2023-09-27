using CoreCMS.Model;
using CoreCMS.Services;
using CoreCMS.Services.Interfaces;
using CoreCMS.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CoreCMS.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class PagesController : Controller
    {
        private readonly ISidebarService _sidebarService;
        private readonly IPageService _pageService;

        public PagesController(ISidebarService sidebarService, IPageService pageService)
        {
            _sidebarService = sidebarService;
            _pageService = pageService;
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public IActionResult Index()
        {
            var pages = _pageService.GetPagesWithSidebar();

            List<PageViewModel> result = new List<PageViewModel>();

            foreach(var page in pages)
            {
                result.Add(new PageViewModel { Id = page.Id, Title = page.Title, Slug = page.Slug, Sidebar = page.Sidebar });
            }


            return View(result);
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public IActionResult CreatePage()
        {
            ViewBag.DropDownData = GetSidebarsForDropDownList();
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> CreatePage(PageViewModel pageViewModel)
        {
            if(!ModelState.IsValid)
            {
                ViewBag.DropDownData = GetSidebarsForDropDownList();
                return View(pageViewModel);
            }

            string slug;

            //slug creation
            if (string.IsNullOrEmpty(pageViewModel.Slug))
                slug = SlugService.Create(true, pageViewModel.Title);
            else
                slug = SlugService.Create(true, pageViewModel.Slug);

            //slug existing checking
            if(_pageService.SlugExists(slug))
            {
                ModelState.AddModelError("", "Title or Slug already exists");
                ViewBag.DropDownData = GetSidebarsForDropDownList();
                return View(pageViewModel);
            }

            Page page = new Page();
            page.Title = pageViewModel.Title;
            page.Slug = slug;
            page.IsPageVisibleInMenu = pageViewModel.IsPageVisibleInMenu;
            page.IsSidebarVisible = pageViewModel.IsSidebarVisible;
            page.Content = pageViewModel.Content;
            page.SidebarId = pageViewModel.SidebarId;

            _pageService.Add(page);
            await _pageService.CommitAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public IActionResult EditPage(int id)
        {
            var page = _pageService.GetPageById(id);

            PageViewModel viewModel= new PageViewModel();

            viewModel.Id = page.Id;
            viewModel.Title = page.Title;
            viewModel.Slug = page.Slug;
            viewModel.Content = page.Content;
            viewModel.IsPageVisibleInMenu = page.IsPageVisibleInMenu;
            viewModel.IsSidebarVisible = page.IsSidebarVisible;

            viewModel.SidebarId = page.SidebarId;

            ViewBag.DropDownData = GetSidebarsForDropDownList();

            return View(viewModel);
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> EditPage(PageViewModel pageViewModel)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.DropDownData = GetSidebarsForDropDownList();
                return View(pageViewModel);
            }

            string slug;

            //slug creation
            if (string.IsNullOrEmpty(pageViewModel.Slug))
                slug = SlugService.Create(true, pageViewModel.Title);
            else
                slug = SlugService.Create(true, pageViewModel.Slug);

            //slug existing checking
            if (_pageService.SlugExists(slug, pageViewModel.Id))
            {
                ModelState.AddModelError("", "Title or Slug already exists");
                ViewBag.DropDownData = GetSidebarsForDropDownList();
                return View(pageViewModel);
            }

            Page page = _pageService.GetPageById(pageViewModel.Id);
            page.Title = pageViewModel.Title;
            page.Slug = slug;
            page.IsPageVisibleInMenu = pageViewModel.IsPageVisibleInMenu;
            page.IsSidebarVisible = pageViewModel.IsSidebarVisible;
            page.Content = pageViewModel.Content;
            page.SidebarId = pageViewModel.SidebarId;

            _pageService.Update(page);
            await _pageService.CommitAsync();

            return RedirectToAction(nameof(Index));
        }


        //GetSidebarsForDropDownList
        private List<SelectListItem> GetSidebarsForDropDownList()
        {
            var sidebars = _sidebarService.GetSidebars();

            List<SelectListItem> dropDown = new List<SelectListItem>();

            foreach (var item in sidebars)
            {
                dropDown.Add(new SelectListItem { Text = item.SidebarTitle, Value = item.Id.ToString() });
            }

            return dropDown;
        }
    }
}
