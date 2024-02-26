using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComponentModules.BaseModule
{
    public class Person
    {
        public int PersonId { get; set; }//string IdentityNumber
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public string? Sex { get; set; }
        public ContactDetails ContactDetails { get; set; }
        //public Address Address { get; set; }
        public ICollection<Address> AddressList { get; set; }
    }
}
