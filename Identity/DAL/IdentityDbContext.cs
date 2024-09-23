using System;
using System.Reflection;
using Identity.DAL.Relationships;
using Identity.DAL.Roles;
using Identity.DAL.Users;
using Microsoft.EntityFrameworkCore;
using Shared.DAL;

namespace Identity.DAL
{
    public class IdentityDbContext(DbContextOptions<IdentityDbContext> options) : ModuleDbContext<IdentityDbContext>(options)
    {

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        /// <summary>
        /// relationships
        /// </summary>
        public DbSet<UserRole> UserRoles { get; set; }

        protected override string Schema => "Identity";

        // override protected void OnModelCreating(ModelBuilder modelBuilder)
        // {
        //     string schema = typeof(IdentityContext).Name;
        //     modelBuilder.HasDefaultSchema(schema.Substring(0, schema.IndexOf("Context")));
        //     modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        // }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserRole>().HasData(new UserRole {Id=1, RoleId = "3188a971-25cb-4d5e-b317-81251b78012b", UserId = "b77b129b-884f-49b4-bb5b-6237fe702246" });
            modelBuilder.Entity<UserRole>().HasData(new UserRole {Id=2, RoleId = "3188a971-25cb-4d5e-b317-81251b78012b", UserId = "6f01392c-45b1-4dbf-9457-74a107fe6ada" });
            base.OnModelCreating(modelBuilder);
        }
    }
}
