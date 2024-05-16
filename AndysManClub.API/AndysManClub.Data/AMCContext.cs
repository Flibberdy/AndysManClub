using AndysManClub.Data.Models;
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

        public virtual DbSet<Person> People { get; set; }

        public virtual DbSet<AmcEvent> Events { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Person>(entity =>
            {
                entity.HasMany<AmcEvent>(x => x.Events)
                    .WithMany(x => x.Volunteers);
            });

            builder.Entity<AmcEvent>(entity =>
            {
                entity.HasMany<Person>(x => x.Volunteers)
                    .WithMany(x => x.Events);
            });

            //modelBuilder.Entity<Student>()
            //        .HasMany<Course>(s => s.Courses)
            //        .WithMany(c => c.Students)
            //        .Map(cs =>
            //        {
            //            cs.MapLeftKey("StudentRefId");
            //            cs.MapRightKey("CourseRefId");
            //            cs.ToTable("StudentCourse");
            //        });


            base.OnModelCreating(builder);
            // Customize the ASP.NET Core Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Core Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
