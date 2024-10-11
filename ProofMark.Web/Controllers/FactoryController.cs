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

        [HttpGet]
        public IActionResult IndexItems(int Id)
        {
			ViewData["Id"] = Id;
            return View();
        }

		[HttpGet]
		public async Task<IActionResult> GetProductItems(int Id)
		{
			var user = await _userManager.GetUserAsync(User);
			if (user == null)
				throw new ApplicationException($"Couldn't Show Products");
			var factory = await _factoryService.GetFactoryByUserIdAsync(user.Id);
			if (factory == null)
				throw new ApplicationException($"Couldn't Show Products");
			var Items = await _productService.GetProductItemsAsync(Id, factory.Id);
			var recordsTotal = Items.Count();
			var jsonData = new { recordsFiltered = recordsTotal, recordsTotal, data = Items };

			return Json(jsonData);
		}

		[HttpPost]
		public async Task<IActionResult> CreateProductItem(int productId, int num)
		{
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
                throw new ApplicationException($"Couldn't Show Products");
            var factory = await _factoryService.GetFactoryByUserIdAsync(user.Id);
            if (factory == null)
                throw new ApplicationException($"Couldn't Show Products");
			var products = (await _productService.GetProductsByFactoryIdAsync(factory.Id)).ToList().Select(x => x.Id) ;
			if(!products.Contains(productId))
                throw new ApplicationException($"Couldn't Show Products");
            var productItems = await _productService.CreateProductItemAsync(productId, num);
			return Json(new { success = (productItems.Count() == 0) ? false : true, message = (productItems.Count() != 0) ? "Product items has been successfully created!" : "Invalid data" });

		}

		[HttpDelete]
		public async Task<IActionResult> DeleteProduct(int Id)
		{

            var result = await _productService.DeleteProductAsync(Id);
            return Json(new { success = result, message = (result) ? "Product has been successfully deleted!" : "Product has been error deleted!" });
        }
	}

}
