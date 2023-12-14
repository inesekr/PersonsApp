using PersonsApp.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace PersonsApp.Data
{
    public class PersonDbContext : DbContext
    {
        public PersonDbContext(DbContextOptions<PersonDbContext> options):base(options)
        {
        }
        public DbSet<Person>? Persons {  get; set; }
        public DbSet<PhoneNumber>? PhoneNumbers { get; set; }
        public DbSet<Address>? Addresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Person>()
                .HasMany(p => p.PhoneNumbers)
                .WithOne(pn => pn.Person)
                .HasForeignKey(pn => pn.PersonId);

            modelBuilder.Entity<Person>()
                .HasMany(p => p.Addresses)
                .WithOne(a => a.Person)
                .HasForeignKey(a => a.PersonId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}