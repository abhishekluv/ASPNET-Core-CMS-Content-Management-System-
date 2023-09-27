using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreCMS.Model
{
    public class Page
    {
        public int Id { get; set; }

        [Required]
        public string? Title { get; set; }

        [Required]
        public string? Slug { get; set; }

        [Required]
        public string? Content { get; set; }

        public bool IsPageVisibleInMenu { get; set; }

        public bool IsSidebarVisible { get; set; }

        //SidebarId Fk
        public int SidebarId { get; set; }

        //navigation properties

        [ForeignKey("SidebarId")]
        public Sidebar Sidebar { get; set; }
    }
}
