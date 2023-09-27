using System.ComponentModel.DataAnnotations;

namespace CoreCMS.Model
{
    public class Sidebar
    {
        public int Id { get; set; }

        [Required]
        public string? SidebarTitle { get; set; }

        [Required]
        public string? Content { get; set; }
    }
}
