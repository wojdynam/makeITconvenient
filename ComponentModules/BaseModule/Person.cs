

namespace ComponentModules.BaseModule
{
    public class Person
    {
        public int PersonId { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public string? Sex { get; set; }
        public ContactDetails ContactDetails { get; set; }
        //public Address Address { get; set; }
        public ICollection<Address> AddressList { get; set; }
    }
}
