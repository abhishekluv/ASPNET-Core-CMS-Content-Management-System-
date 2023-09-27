using Microsoft.AspNetCore.Identity;

namespace CoreCMS.Model
{
    public class CustomUser : IdentityUser<int>
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }
}
