using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace artvibe_oracle.Data.Configurations
{
	public class SeedOfRoles : IEntityTypeConfiguration<RoleData>
	{
		public void Configure(EntityTypeBuilder<RoleData> builder)
		{
			builder.HasData(
				new RoleData
				{
				
					Name = "Admin",
					NormalizedName = "ADMIN"
					
				},
				new RoleData
				{
					
					Name = "Manager",
					NormalizedName = "MANAGER"
				},
				new RoleData
				{

					Name = "normalUser",
					NormalizedName = "NORMALUSER"

				}
				,
				new RoleData
				{

					Name = "premiumUser",
					NormalizedName = "PREMIUMUSER"

				}
			);
		}
	}
}
