using System.ComponentModel.DataAnnotations;

namespace HeroesAndDragons.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Имя не указано.")]
        [StringLength (20, MinimumLength = 4, ErrorMessage = "Длина имени должна быть от 4 до 20 символов.")]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords must match")]
        [Display(Name = "Confirm password")]
        public string PasswordConfirm { get; set; }
    }
}
