using ComponentModules.BaseModule;
using Microsoft.AspNetCore.Identity;

namespace DataAccessLayer
{
    public class AppUser : IdentityUser
    {
        // do rozszerzenia aby można było dodać id osoby do tabeli user
        public int? PersonId { get; set; }

        public virtual Person Person { get; set; }
    }
}
