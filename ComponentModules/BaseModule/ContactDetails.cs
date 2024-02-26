using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComponentModules.BaseModule
{
    public class ContactDetails
    {
        public int ContactDetailsId { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Website { get; set; }

        public int PersonId { get; set; }//foreign key of the person class
        public  Person Person { get; set; }//navigaton
        
    }
}
