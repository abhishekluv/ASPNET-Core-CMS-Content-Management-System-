using CoreCMS.Data;
using CoreCMS.Model;
using CoreCMS.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreCMS.Services.Concrete
{
    public class PageService : IPageService
    {
        private readonly CoreCMSContext _context;

        public PageService(CoreCMSContext context)
        {
            _context = context;
        }

        public void Add(Page page)
        {
            _context.Pages.Add(page);
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Delete(int id)
        {
            var page = GetPageById(id);
            _context.Pages.Remove(page);
        }

        public Page GetPageById(int id)
        {
            return _context.Pages.Where(x => x.Id == id).AsNoTracking().FirstOrDefault();
        }

        public Page GetPageBySlug(string slug)
        {
            return _context.Pages.Where(x => x.Slug == slug).AsNoTracking().FirstOrDefault();
        }

        public List<Page> GetPages()
        {
            return _context.Pages.AsNoTracking().ToList();
        }

        public List<Page> GetPagesWithSidebar()
        {
            return _context.Pages.Include(x => x.Sidebar).AsNoTracking().ToList();
        }

        public List<Page> GetVisiblePages()
        {
            return _context.Pages.Where(x => x.IsPageVisibleInMenu).AsNoTracking().ToList();
        }

        public bool SlugExists(string slug, int? pageIdExclude = null)
        {
            if(pageIdExclude !=null)
            {
                return _context.Pages.Where(x => x.Id != pageIdExclude).Any(x => x.Slug == slug);
            }

            return _context.Pages.Any(x => x.Slug == slug);
        }

        public void Update(Page page)
        {
            _context.Pages.Update(page);
        }
    }
}
