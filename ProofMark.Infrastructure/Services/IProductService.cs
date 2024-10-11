using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProofMark.EF.Data;
using ProofMark.EF.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ProofMark.Infrastructure.Services
{
	public interface IProductService
	{
		Task<Product?> GetProductByIdAsync(int id);
		Task<IEnumerable<Product>> GetProductsByFactoryIdAsync(int factoryId);
		Task<Product> CreateProductAsync(Product product);
		Task UpdateProductAsync(Product product);
		Task<bool> DeleteProductAsync(int productId);
		Task<List<ProductItem>> CreateProductItemAsync( int productId, int num);
		Task<List<ProductItem>> GetProductItemsAsync(int productId , int factoryId);
		Task<bool> VerifyProductItemAsync(string qrCode);
	}

	// Services/ProductService.cs
	public class ProductService : IProductService
	{
		private readonly ApplicationDbContext _context;
		private readonly IQRCodeService _qrCodeService;
		private readonly UserManager<User> _userManager;

		public ProductService(ApplicationDbContext context, IQRCodeService qrCodeService , UserManager<User> userManager)
		{
			_context = context;
			_qrCodeService = qrCodeService;
			_userManager = userManager;
		}

		public async Task<Product?> GetProductByIdAsync(int id)
		{
			return await _context.Products.FindAsync(id);
		}

		public async Task<IEnumerable<Product>> GetProductsByFactoryIdAsync(int factoryId)
		{
			return await _context.Products
				.Where(p => p.FactoryId == factoryId)
				.ToListAsync();
		}

		public async Task<Product> CreateProductAsync(Product product)
		{
			_context.Products.Add(product);
			await _context.SaveChangesAsync();
			return product;
		}

		public async Task UpdateProductAsync(Product product)
		{
			_context.Entry(product).State = EntityState.Modified;
			await _context.SaveChangesAsync();
		}

		public async Task<bool> DeleteProductAsync(int productId)
		{
			var product = await _context.Products.FindAsync(productId);
			if (product != null)
			{
				product.IsDelete = true;
                _context.Entry(product).State = EntityState.Modified;
				await _context.SaveChangesAsync();
				return true;

            }
			return false;
        }

		public async Task<List<ProductItem>> CreateProductItemAsync( int productId, int num)
		{
			
			var product = await _context.Products.FindAsync(productId);
			if (product == null)
				throw new ArgumentException("Product not found");
			var ListProductItems = new List<ProductItem>();
			for (int i = 0; i < num; i++)
			{


				var productItem = new ProductItem
                {
					ProductId = productId,
					CreatedAt = DateTime.UtcNow
				};
                _context.ProductItems.Add(productItem);
                await _context.SaveChangesAsync();

                productItem.SerialNumber = productId.ToString().PadLeft(4, '0') + productItem.Id.ToString().PadLeft(4, '0');

				var qrCodeContent = $"ProductItemId:{productItem.Id},SerialNumber:{productItem.SerialNumber},Timestamp:{productItem.CreatedAt}";
				productItem.QRCodeText = qrCodeContent;
				productItem.QRCode = _qrCodeService.GenerateQRCode(qrCodeContent);

				_context.Entry(productItem).State = EntityState.Modified;
				await _context.SaveChangesAsync();
				ListProductItems.Add(productItem);
			}

			return ListProductItems;
		}

		public async Task<bool> VerifyProductItemAsync(string qrCode)
		{
			var productItem = await _context.ProductItems
				.FirstOrDefaultAsync(pi => pi.QRCodeText == qrCode);

			return productItem != null;
		}

		public async Task<List<ProductItem>> GetProductItemsAsync(int productId , int factoryId)
		{
			if ((await _context.Products.Where(x => x.FactoryId == factoryId).ToListAsync()).Select(x => x.Id).Contains(productId))
			{
				var items =await _context.ProductItems.Where(x => x.ProductId == productId).ToListAsync();
				return items;
			}
			return new List<ProductItem>();
		}
	}

}
