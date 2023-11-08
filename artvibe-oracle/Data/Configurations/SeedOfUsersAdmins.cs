using artvibe_oracle.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

public class SeedOfUsersAdmins : IEntityTypeConfiguration<UserData>
{
	private readonly UserManager<UserData> _userManager;
	private readonly RoleManager<IdentityRole> _roleManager;
	private readonly string[] _userNames = { "daniel", "alvaro" }; // Nombres de usuarios

	public SeedOfUsersAdmins(UserManager<UserData> userManager, RoleManager<IdentityRole> roleManager)
	{
		_userManager = userManager;
		_roleManager = roleManager;
	}

	public async void Configure(EntityTypeBuilder<UserData> builder)
	{
		foreach (var userName in _userNames)
		{
			var user = new UserData
			{
				UserName = userName,
				Email = $"{userName.ToLower()}@example.com" // Ejemplo de generación de correo
			};

			var password = "TuContrasenaSegura"; // Asegúrate de manejar las contraseñas de manera segura
			var hashedPassword = new PasswordHasher<UserData>().HashPassword(user, password);

			user.PasswordHash = hashedPassword;

			await _userManager.CreateAsync(user);

			// Verifica si el rol "Admin" existe y créalo si no existe
			if (!await _roleManager.RoleExistsAsync("Admin"))
			{
				await _roleManager.CreateAsync(new IdentityRole("Admin"));
			}

			// Asigna el rol "Admin" al usuario
			await _userManager.AddToRoleAsync(user, "Admin");
		}
	}
}
