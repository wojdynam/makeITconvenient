using System.ComponentModel.DataAnnotations;

namespace makeITconvenient.Models
{
    public class PersonDto
    {
        public int PersonId { get; set; }
        [Display(Name ="Imię")]
        public  string FirstName { get; set; }
        [Display(Name ="Nazwisko")]
        public  string LastName { get; set; }
        [Display(Name ="płeć")]
        public string Sex { get; set; }

        public ContactDetailsDto? ContactDetails { get; set; }
        public List<AddressDto>? AddressList { get; set; }
    }
}
