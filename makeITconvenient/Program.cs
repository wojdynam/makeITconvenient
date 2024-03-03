
using ComponentModules.Interfaces;
using DataAccessLayer;
using DataAccessLayer.Repositories;
using makeITconvenient.InitialConf;
using makeITconvenient.Services;
using makeITconvenient.Services.Interfaces;
using makeITconvenient.Services.Mappings;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IPersonRepository, PersonRepository>();
builder.Services.AddScoped<IPersonServices, PersonServices>();
builder.Services.AddSingleton(AutomapperConfig.Initialize());



var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddDefaultIdentity<AppUser>(
        options => { options.SignIn.RequireConfirmedAccount = false;
        options.Lockout.AllowedForNewUsers = true;
        })
 .AddRoles<IdentityRole>()
 .AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();

builder.Services.AddTransient<DefaultAdmin>();

builder.Services.AddControllersWithViews();
builder.Services.AddAuthorization(options =>
options.AddPolicy("RequiredSuperAdmin", policy => policy.RequireRole("Admin")));
builder.Services.AddScoped<RoleAuthorizationFilter>(provider =>
{
  
    return new RoleAuthorizationFilter("Admin");
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=AccessUser}/{action=Login}/{id?}");
app.MapRazorPages();
var defaultAdmin = app.Services.CreateScope().ServiceProvider.GetRequiredService<DefaultAdmin>();
defaultAdmin.Initialize();

app.Run();
