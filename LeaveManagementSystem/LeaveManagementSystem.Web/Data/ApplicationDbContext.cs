using LeaveManagementSystem.Web.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagementSystem.Web.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Id = "2c06326f-2c96-4b57-9efe-e2ec3affcdc0",
                    Name = "Employee",
                    NormalizedName = "EMPLOYEE"
                },
                new IdentityRole
                {
                    Id = "d1f3b5c2-4e6a-4c8b-9f0d-7e8f1c2b3a4b",
                    Name = "Supervisor",
                    NormalizedName = "SUPERVISOR",
                },
                new IdentityRole
                {
                    Id = "a1b2c3d4-e5f6-7g8h-9i0j-k1l2m3n4o5p6",
                    Name = "Administrator",
                    NormalizedName = "ADMINISTRATOR"
                }

            );
            var hasher = new PasswordHasher<IdentityUser>();
            builder.Entity<IdentityUser>().HasData(
                new IdentityUser
                {
                    Id = "1a2b3c4d-5e6f-7g8h-9i0j-k1l2m3n4o5p6",
                    UserName = "admin",
                    NormalizedUserName = "ADMIN",
                    Email = "admin@example.com",
                    NormalizedEmail = "ADMIN@EXAMPLE.COM",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "Admin@123"),
                }
            );
            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    UserId = "1a2b3c4d-5e6f-7g8h-9i0j-k1l2m3n4o5p6",
                    RoleId = "a1b2c3d4-e5f6-7g8h-9i0j-k1l2m3n4o5p6"
                }
            );
        }
        public DbSet<LeaveType> LeaveTypes { get; set; } = null!;
    }
}
