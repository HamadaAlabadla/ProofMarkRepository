using Microsoft.AspNetCore.Mvc;
using ProofMark.EF.Models;
using ProofMark.Infrastructure.Services;

namespace ProofMark.web.Controllers
{
	public class ProductVerificationController : Controller
	{
		private readonly IProductService _productService;

		public ProductVerificationController(IProductService productService)
		{
			_productService = productService;
		}
		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> VerifyProduct( string QRCodeText)
		{
			var isAuthentic = await _productService.VerifyProductItemAsync(QRCodeText);
			return Json(new { success = isAuthentic, message = isAuthentic? "This product has been verified, this product is original" : "This product has been verified, this product is fake" });
		}
	}

}
