using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace WebApplication1.ViewModels

{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name ="Confirm Password")]
        [Compare("Password", ErrorMessage="Passwords Do Not Match")]
        public string ConfirmPassword { get; set; }

    }
}
