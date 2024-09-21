using Microsoft.EntityFrameworkCore;
using ProofMark.EF.Data;
using ProofMark.EF.Models;

namespace ProofMark.Infrastructure.Services
{
	public interface IProductService
	{
		Task<Product?> GetProductByIdAsync(int id);
		Task<IEnumerable<Product>> GetProductsByFactoryIdAsync(int factoryId);
		Task<Product> CreateProductAsync(Product product);
		Task UpdateProductAsync(Product product);
		Task DeleteProductAsync(int productId);
		Task<List<ProductItem>> CreateProductItemAsync(int productId, int num);
		Task<bool> VerifyProductItemAsync(string qrCode);
	}

	// Services/ProductService.cs
	public class ProductService : IProductService
	{
		private readonly ApplicationDbContext _context;
		private readonly IQRCodeService _qrCodeService;

		public ProductService(ApplicationDbContext context, IQRCodeService qrCodeService)
		{
			_context = context;
			_qrCodeService = qrCodeService;
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

		public async Task DeleteProductAsync(int productId)
		{
			var product = await _context.Products.FindAsync(productId);
			if (product != null)
			{
				_context.Products.Remove(product);
				await _context.SaveChangesAsync();
			}
		}

		public async Task<List<ProductItem>> CreateProductItemAsync(int productId, int num)
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
					SerialNumber = Guid.NewGuid().ToString(),
					CreatedAt = DateTime.UtcNow
				};

				var qrCodeContent = $"ProductItemId:{productItem.Id},SerialNumber:{productItem.SerialNumber},Timestamp:{DateTime.UtcNow.Ticks}";
				productItem.QRCode = _qrCodeService.GenerateQRCode(qrCodeContent);

				_context.ProductItems.Add(productItem);
				await _context.SaveChangesAsync();
				ListProductItems.Add(productItem);
			}

			return ListProductItems;
		}

		public async Task<bool> VerifyProductItemAsync(string qrCode)
		{
			var productItem = await _context.ProductItems
				.FirstOrDefaultAsync(pi => pi.QRCode == qrCode);

			return productItem != null;
		}
	}

}
