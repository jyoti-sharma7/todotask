using System.ComponentModel.DataAnnotations;

namespace TodotaskWeb.Models.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "First Name")]
        public string? FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string? LastName { get; set; }
        [EmailAddress]
        [Required]
        public string? Email { get; set; }
        public string? Address { get; set; }
        [Required]
        public string? Password { get; set; }
        [Required]
        [Display(Name = "Confirm Password")]
        [Compare("Password",ErrorMessage ="Password doesn't match")]
        public string? ConfirmPassword { get; set; }
    }
}
