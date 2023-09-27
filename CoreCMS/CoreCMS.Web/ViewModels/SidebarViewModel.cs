using System.ComponentModel.DataAnnotations;

namespace CoreCMS.Web.ViewModels
{
    public class SidebarViewModel
    {
        public int Id { get; set; }

        [Required]
        public string? SidebarTitle { get; set; }

        [Required]
        public string? Content { get; set; }
    }
}
