using CoreCMS.Data;
using CoreCMS.Model;
using CoreCMS.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CoreCMS.Services.Concrete
{
    public class SidebarService : ISidebarService
    {
        private readonly CoreCMSContext _context;

        public SidebarService(CoreCMSContext context)
        {
            _context = context;
        }
        public void Add(Sidebar sidebar)
        {
            _context.Sidebars.Add(sidebar);
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Delete(int id)
        {
            var sidebar = GetSidebarById(id);
            _context.Sidebars.Remove(sidebar);
        }

        public Sidebar GetSidebarById(int id)
        {
            return _context.Sidebars.AsNoTracking().Where(x => x.Id == id).FirstOrDefault();
        }

        public List<Sidebar> GetSidebars()
        {
            return _context.Sidebars.AsNoTracking().ToList();
        }

        public void Update(Sidebar sidebar)
        {
            _context.Sidebars.Update(sidebar);
        }
    }
}
