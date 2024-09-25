using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProofMark.Core.ViewModels;
using ProofMark.EF.Models;
using ProofMark.Infrastructure.Services;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Text.Json;

namespace ProofMark.Web.Controllers
{
	[Authorize(Roles = "Factory")]
	public class FactoryController : Controller
	{
		private readonly IProductService _productService;
		private readonly UserManager<User> _userManager;
		private readonly IFactoryService _factoryService;

		public FactoryController(IProductService productService, UserManager<User> userManager, IFactoryService factoryService)
		{
			_productService = productService;
			_userManager = userManager;
			_factoryService = factoryService;
		}
		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}

		[HttpGet]
		public async Task<IActionResult> GetFactoryProducts()
		{
			var user = await _userManager.GetUserAsync(User);
			if (user == null)
				throw new ApplicationException($"Couldn't Show Products");
			var factory = await _factoryService.GetFactoryByUserIdAsync(user.Id);
			if (factory == null)
				throw new ApplicationException($"Couldn't Show Products");
			var products = await _productService.GetProductsByFactoryIdAsync(factory.Id);
			var recordsTotal = products.Count();
			var jsonData = new { recordsFiltered = recordsTotal, recordsTotal, data = products };
            var options = new JsonSerializerOptions
            {
                ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve,
                WriteIndented = true
            };

            return Json(jsonData);
		}

		[HttpPost]
		public async Task<IActionResult> CreateProduct( ProductViewModel model)
		{
			var user = await _userManager.GetUserAsync(User);
			if (user == null)
				throw new ApplicationException($"Couldn't Create Product");
			var factory = await _factoryService.GetFactoryByUserIdAsync(user.Id);
			if (factory == null)
				throw new ApplicationException($"Couldn't Create Product");
			var product = new Product
			{
				Name = model.Name,
				Description = model.Description,
				FactoryId = factory.Id,
				CreatedAt = DateTime.UtcNow,
				IsDelete = false,
			};

			var createdProduct = await _productService.CreateProductAsync(product);
            return Json(new { success = (createdProduct is null) ? false : true, message = (createdProduct is not null) ? "Product has been successfully created!" : "Invalid data" });
        }

        [HttpPost]
		public async Task<IActionResult> CreateProductItem(int productId, int num)
		{
			var productItem = await _productService.CreateProductItemAsync(productId, num);
			var ListProductItemsId = new List<int>();
			foreach (var item in productItem)
			{
				ListProductItemsId.Add(item.Id);
			}
			return CreatedAtAction(nameof(GetFactoryProducts), new { ListProductItemsId = ListProductItemsId }, productItem);
		}

		[HttpDelete]
		public async Task<IActionResult> DeleteProduct(int Id)
		{

            var result = await _productService.DeleteProductAsync(Id);
            return Json(new { success = result, message = (result) ? "Product has been successfully deleted!" : "Product has been error deleted!" });
        }
	}

}
