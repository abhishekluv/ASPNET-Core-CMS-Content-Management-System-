using CoreCMS.Model;
using CoreCMS.Services.Interfaces;
using CoreCMS.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreCMS.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class SidebarsController : Controller
    {
        private readonly ISidebarService _sidebarService;

        public SidebarsController(ISidebarService sidebarService)
        {
            _sidebarService = sidebarService;
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public IActionResult Index()
        {
            var sidebars = _sidebarService.GetSidebars();

            List<SidebarViewModel> list = new List<SidebarViewModel>();

            foreach(var sidebar in sidebars)
            {
                list.Add(new SidebarViewModel { Id = sidebar.Id, SidebarTitle = sidebar.SidebarTitle, Content = sidebar.Content });
            }

            return View(list);
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public IActionResult CreateSidebar()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> CreateSidebar(SidebarViewModel viewModel)
        {
            if(ModelState.IsValid)
            {
                Sidebar sidebar = new Sidebar();
                sidebar.SidebarTitle = viewModel.SidebarTitle;
                sidebar.Content = viewModel.Content;

                _sidebarService.Add(sidebar);
                await _sidebarService.CommitAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(viewModel);
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public IActionResult EditSidebar(int id)
        {
            var sidebar = _sidebarService.GetSidebarById(id);

            SidebarViewModel viewModel= new SidebarViewModel();
            viewModel.Id = sidebar.Id;
            viewModel.SidebarTitle = sidebar.SidebarTitle;
            viewModel.Content = sidebar.Content;

            return View(viewModel);
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> EditSidebar(SidebarViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Sidebar sidebar = _sidebarService.GetSidebarById(viewModel.Id);
                sidebar.SidebarTitle = viewModel.SidebarTitle;
                sidebar.Content = viewModel.Content;

                _sidebarService.Update(sidebar);
                await _sidebarService.CommitAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(viewModel);
        }
    }
}
