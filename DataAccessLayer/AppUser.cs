using ComponentModules.BaseModule;
using Microsoft.AspNetCore.Identity;

namespace DataAccessLayer
{
    public class AppUser : IdentityUser
    {
        public bool RequirePasswordChange { get; set; }

        public int? PersonId { get; set; }
        public virtual Person Person { get; set; }
    }
}
