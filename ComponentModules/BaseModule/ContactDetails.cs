

namespace ComponentModules.BaseModule
{
    public class ContactDetails
    {
        public int ContactDetailsId { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Website { get; set; }

        public int PersonId { get; set; }
        public  Person Person { get; set; }
        
    }
}
