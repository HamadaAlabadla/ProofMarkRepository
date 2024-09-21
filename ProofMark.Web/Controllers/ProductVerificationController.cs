using Microsoft.AspNetCore.Mvc;
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
		public async Task<IActionResult> VerifyProduct([FromBody] string qrCode)
		{
			var isAuthentic = await _productService.VerifyProductItemAsync(qrCode);
			return Ok(new { isAuthentic });
		}
	}

}
