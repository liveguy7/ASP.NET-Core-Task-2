using System.ComponentModel.DataAnnotations;

namespace WebApplication1.ViewModels
{
    public class CreateRoleViewModel
    {
        [Required]
        public string RoleName { get; set; }

    }
}
