using CoreCMS.Model;
using System.ComponentModel.DataAnnotations;

namespace CoreCMS.Web.ViewModels
{
    public class PageViewModel
    {
        public int Id { get; set; }

        [Required]
        public string? Title { get; set; }

        public string? Slug { get; set; }

        [Required]
        public string? Content { get; set; }

        public bool IsPageVisibleInMenu { get; set; }

        public bool IsSidebarVisible { get; set; }

        //SidebarId Fk
        public int SidebarId { get; set; }

        public Sidebar? Sidebar { get; set; }
    }
}
