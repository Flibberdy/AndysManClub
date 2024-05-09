using AndysManClub.Domain.DTO;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AndysManClub.Data
{
    public class AMCContext : IdentityDbContext<IdentityUser>
    {
        public AMCContext(DbContextOptions<AMCContext> options)
            : base(options)
        {
        }
        
        public virtual DbSet<EventVolunteers> People { get; set; }
        
        public virtual DbSet<AmcEvent> Events { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Person>(entity =>
            {
            });

            builder.Entity<AmcEvent>(entity =>
            {
            });

            builder.Entity<PersonEvent>(entity =>
            {
                entity.HasOne(x => x.Event)
                    .WithMany(x => x.Volunteers)
                    .HasForeignKey(x => x.Event)
                    .HasConstraintName("FK_PersonEvent_AmcEvent_AmcEvent");

                entity.HasOne(x => x.Volunteer)
                    .WithMany(x => x.Volunteers)
                    .HasForeignKey(x => x.Volunteer)
                    .HasConstraintName("FK_PersonEvent_Person_Person");

            });

            base.OnModelCreating(builder);
            // Customize the ASP.NET Core Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Core Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
