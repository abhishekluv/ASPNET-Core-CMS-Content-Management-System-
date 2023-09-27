using CoreCMS.Model;

namespace CoreCMS.Services.Interfaces
{
    public interface IPageService
    {
        List<Page> GetPages(); // backend
        Page GetPageById(int id);
        void Add(Page page);
        void Update(Page page);
        void Delete(int id);
        Task CommitAsync();

        //custom logic method
        //EF loading related data
        //1. Lazy Loading
        //2. Eager Loading: Query-> Joins and SubQueries
        //3. Explicit Loading
        List<Page> GetPagesWithSidebar(); //eager loading Include() backend
        Page GetPageBySlug(string slug); //url about

        //SlugExists
        bool SlugExists(string slug, int? pageIdExclude = null);

        List<Page> GetVisiblePages(); // IsPageVisibleInMenu true false 5 
    }
}
