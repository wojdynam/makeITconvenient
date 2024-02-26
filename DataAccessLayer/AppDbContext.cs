using ComponentModules.BaseModule;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<ContactDetails> Contacts { get; set; }
        public DbSet<Person> Persons { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Person>().HasKey(p => p.PersonId);

            builder.Entity<AppUser>()
            .HasOne(u => u.Person)
            .WithOne()
            .HasForeignKey<AppUser>(u => u.PersonId);


            builder.Entity<Person>().HasOne(p => p.ContactDetails)
                .WithOne(p => p.Person).HasForeignKey<ContactDetails>(p => p.PersonId);

            //builder.Entity<Person>().HasMany(p => p.AddressList).WithMany(p => p.PersonList);
            //builder.Entity<Address>().HasOne(p => p.Person).WithMany(p => p.AddressList).HasForeignKey(p=>p.PersonId);
            builder.Entity<Person>().HasMany(p => p.AddressList).WithOne(p => p.Person).HasForeignKey(p => p.PersonId);
        }
    }
}
