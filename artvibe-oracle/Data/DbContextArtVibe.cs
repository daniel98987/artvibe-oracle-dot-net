using artvibe_oracle.Data.Configurations;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace artvibe_oracle.Data
{
    public class DbContextartvibe_oracle : IdentityDbContext
    {

		public DbContextartvibe_oracle(DbContextOptions options) : base(options)
        {
		
		}
        public DbSet<UserData> UserData { get; set; }
        public DbSet<RoleData> RoleData { get; set; }
        public DbSet<ProductDate> ProductDate { get; set; }
        public DbSet<ProductTypeDate> ProductTypeDate { get; set; }
        public DbSet<DateFruit> Fruits { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<UserData>(entity =>
            {
                entity.Property(e => e.UserName).IsRequired();
			});
			builder.ApplyConfiguration(new SeedOfRoles());
			
		}
    }
}
