using System.ComponentModel.DataAnnotations;

namespace CoreCMS.Web.ViewModels
{
    public class LoginViewModel
    {
        public string? UserName { get; set; }

        [DataType(DataType.Password)]
        public string? Password { get; set; }
    }
}
