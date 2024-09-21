using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProofMark.EF.Data;
using ProofMark.EF.Models;
using static ProofMark.Core.Enums.Enums;

namespace ProofMark.Infrastructure.Services
{
	// Services/IFactoryService.cs
	public interface IFactoryService
	{
		Task<Factory?> GetFactoryByUserIdAsync(string userId);
		Task<IEnumerable<Factory>> GetAllFactoriesAsync();
		Task<Factory?> CreateFactoryAsync(Factory factory, string password);
		Task UpdateFactoryAsync(Factory factory);
		Task<bool> DeleteFactoryAsync(int factoryId);
	}

	// Services/FactoryService.cs
	public class FactoryService : IFactoryService
	{
		private readonly ApplicationDbContext _context;
		private readonly UserManager<User> _userManager;

		public FactoryService(ApplicationDbContext context, UserManager<User> userManager)
		{
			_context = context;
			_userManager = userManager;
		}

		public async Task<Factory?> GetFactoryByUserIdAsync(string userId)
		{
			return await _context.Factories
				.Include(f => f.User)
				.FirstOrDefaultAsync(f => f.UserId == userId);
		}

		public async Task<IEnumerable<Factory>> GetAllFactoriesAsync()
		{
			return await _context.Factories
				.Include(f => f.User)
				.ToListAsync();
		}

		public async Task<Factory?> CreateFactoryAsync(Factory factory, string password)
		{
			if (factory.User == null)
				throw new ApplicationException($"Couldn't create user ");
			var user = new User
			{
				UserName = factory.User.Email,
				Email = factory.User.Email,
				UserType = UserType.Factory,
				PhoneNumber = factory.User.PhoneNumber,
			};

			var result = await _userManager.CreateAsync(factory.User, password);

			if (!result.Succeeded)
			{
				return null;
			}

			await _userManager.AddToRoleAsync(factory.User, "Factory");

			factory.UserId = factory.User.Id;
			_context.Factories.Add(factory);
			await _context.SaveChangesAsync();
			var factoryAdded = await _context.Factories.FirstOrDefaultAsync(x => (x.UserId!).Equals(factory.UserId));
			return factoryAdded;
		}

		public async Task UpdateFactoryAsync(Factory factory)
		{
			_context.Entry(factory).State = EntityState.Modified;
			await _context.SaveChangesAsync();
		}

		public async Task<bool> DeleteFactoryAsync(int factoryId)
		{
			var factory = _context.Factories.Include(x => x.User).FirstOrDefault(b => b.Id == factoryId); 
			if (factory is not null && factory.User is not null && factory.User.IsActive)
			{
				var user = await _userManager.FindByIdAsync(factory.UserId ?? "");
				if (user != null)
				{
					user.IsActive = false;
					await _userManager.UpdateAsync(user);
					//await _userManager.DeleteAsync(user);
				}

				//_context.Factories.Remove(factory);
				await _context.SaveChangesAsync();
				return true;
			}
			return false;
		}
	}
}
