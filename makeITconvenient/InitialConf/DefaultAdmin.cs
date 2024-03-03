using DataAccessLayer;
using Microsoft.AspNetCore.Identity;
using System.Linq.Expressions;

namespace makeITconvenient.InitialConf
{
    public  class DefaultAdmin
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;
        public DefaultAdmin(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManger,
            IConfiguration configuration)
        {
            _userManager = userManager;
            _roleManager = roleManger;
            _configuration = configuration;

        }

        public  void Initialize()
        {
            
            if (!_roleManager.RoleExistsAsync("Admin").Result)
            {
                IdentityRole role = new()
                {
                    Name = "Admin"
                };
                IdentityResult roleResult = _roleManager.CreateAsync(role).Result;
            }
            string adminEmail = _configuration["DefaultAdminCredential:AdminEmail"];
            string password = _configuration["DefaultAdminCredential:Password"];
            if(_userManager.FindByEmailAsync(adminEmail).Result == null)
            {
                AppUser admin = Activator.CreateInstance<AppUser>();
                admin.Email = adminEmail;
                admin.UserName = adminEmail;
                admin.RequirePasswordChange = true;
               
                IdentityResult result = _userManager.CreateAsync(admin, password).Result;
                if (result.Succeeded)
                {
                    _userManager.AddToRoleAsync(admin, "Admin").Wait();
                }
            }
        }
    }
}
