using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace MooBookopedia.Data.ViewModels
{
    public class LoginVM
    {
        [Display(Name = "Adres email")]
        [Required(ErrorMessage = "Email jest konieczny")]
        public string EmailAddress { get; set; }

        [Required]
        [Display(Name = "Hasło")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
