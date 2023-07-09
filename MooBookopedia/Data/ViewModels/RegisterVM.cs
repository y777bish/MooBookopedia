using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace MooBookopedia.Data.ViewModels
{
    public class RegisterVM
    {
        [Display(Name = "Nazwa")]
        [Required(ErrorMessage = "Nazwa jest konieczna")]
        public string FullName { get; set; }

        [Display(Name = "Adres email")]
        [Required(ErrorMessage = "Email jest konieczny")]
        public string EmailAddress { get; set; }

        [Required]
        [Display(Name = "Hasło")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Potwierdź hasło")]
        [Required(ErrorMessage = "Trzeba potwierdzić hasło")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Hasła nie są takie same")]
        public string ConfirmPassword { get; set; }
    }
}
