using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProofMark.EF.Models;
using static ProofMark.Core.Enums.Enums;

namespace ProofMark.EF.Data
{
	public class ApplicationDbContext : IdentityDbContext<User>
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
		}
		public DbSet<Factory> Factories { get; set; }
		public DbSet<Product> Products { get; set; }
		public DbSet<ProductItem> ProductItems { get; set; }


		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);

			builder.Entity<Factory>()
				.HasOne(f => f.User)
				.WithOne()
				.HasForeignKey<Factory>(f => f.UserId);

			builder.Entity<Product>()
				.HasOne(p => p.Factory)
				.WithMany(f => f.Products)
				.HasForeignKey(p => p.FactoryId);

			builder.Entity<ProductItem>()
				.HasOne(pi => pi.Product)
				.WithMany(p => p.Items)
				.HasForeignKey(pi => pi.ProductId);


			var AdminId = Guid.NewGuid().ToString();
			var FactoryId = Guid.NewGuid().ToString();
			var UserId = Guid.NewGuid().ToString();

			builder.Entity<IdentityRole>()
				.HasData(new IdentityRole()
				{
					Id = AdminId,
					Name = "Admin",
					NormalizedName = "ADMIN"
				});
			builder.Entity<IdentityRole>()
				.HasData(new IdentityRole()
				{
					Id = FactoryId,
					Name = "Factory",
					NormalizedName = "FACTORY"
				});
			builder.Entity<User>()
				.HasData();
			var user = new User()
			{
				Id = UserId,
				CreateAt = DateTime.Now,
				Email = "Admin@gmail.com",
				PhoneNumber = "1234567890",
				UserName = "Admin@gmail.com",
				UserType = UserType.Admin,
				EmailConfirmed = true,
				NormalizedUserName = "ADMIN@GMAIL.COM",
				NormalizedEmail = "ADMIN@GMAIL.COM",
			};
			PasswordHasher<User> hasher = new PasswordHasher<User>();
			user.PasswordHash = hasher.HashPassword(user, "ADMIN_123_admin");
			builder.Entity<User>().HasData(user);

			builder.Entity<IdentityUserRole<string>>()
				.HasData(new IdentityUserRole<string>()
				{
					RoleId = AdminId,
					UserId = UserId,
				});
		}


	}
}
