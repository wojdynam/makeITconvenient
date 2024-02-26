using System.ComponentModel.DataAnnotations;

namespace makeITconvenient.Models
{
    public class AddressDto
    {
        public int AddressId { get; set; }
        [Display(Name ="Typ Adresu:")]
        public string? AddressName { get; set; }
        [Display(Name="Państwo")]
        public string? Country { get; set; }
        [Display(Name ="Kod Pocztowy")]
        public string? PostalCode { get; set; }
        [Display(Name ="Miasto")]
        public string? City { get; set; }
        [Display(Name ="Ulica")]
        public string? Street { get; set; }
        [Display(Name ="Numer Domu")]
        public string? HouseNumber { get; set; }
        [Display(Name ="Numer Mieszkania")]
        public string? ApartmentNumber { get; set; }
    }
}
