

namespace ComponentModules.BaseModule
{
    public class Address
    {
        public int AddressId { get; set; }
        public required string AddressName { get; set; }
        public required string Country { get; set; }
        public required string PostalCode { get; set; }
        public required string City { get; set; }
        public string? Street { get; set; }
        public required string HouseNumber { get; set; }
        public string? ApartmentNumber { get; set; }

        public int PersonId { get; set; }
        public Person Person { get; set; }
        // public ICollection<Person> PersonList{ get; set; }
    }
}
