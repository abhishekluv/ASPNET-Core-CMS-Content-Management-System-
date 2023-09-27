using CoreCMS.Model;

namespace CoreCMS.Services.Interfaces
{
    public interface ISidebarService
    {
        List<Sidebar> GetSidebars();
        Sidebar GetSidebarById(int id);
        void Add(Sidebar sidebar);
        void Update(Sidebar sidebar);
        void Delete(int id);
        Task CommitAsync();
    }
}
