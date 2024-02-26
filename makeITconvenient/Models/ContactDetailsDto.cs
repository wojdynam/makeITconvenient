using ComponentModules.BaseModule;
using System.ComponentModel.DataAnnotations;

namespace makeITconvenient.Models
{
    public class ContactDetailsDto
    {
        public int ContactDetailsId { get; set; }
        public string? Email { get; set; }
        [Display(Name ="Telefon")]
        public string? PhoneNumber { get; set; }
        [Display(Name ="Strona WWW")]
        public string? Website { get; set; }
       

    }
}
