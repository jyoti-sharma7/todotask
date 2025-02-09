using System.ComponentModel.DataAnnotations;

namespace TodotaskWeb.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="Email is Required")]
        public string? Username { get; set; }
        [Required(ErrorMessage = "Password is Required")]
        public string? Password { get; set; }
        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; }
    }
}
