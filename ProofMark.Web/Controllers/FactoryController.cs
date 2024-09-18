using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProofMark.Core.ViewModels;
using ProofMark.EF.Models;
using ProofMark.Infrastructure.Services;

namespace ProofMark.Web.Controllers
{
    // [Authorize(Roles = "Factory")]
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
        public async Task<IActionResult> GetFactoryProducts()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
                throw new ApplicationException($"Couldn't Show Products");
            var factory = await _factoryService.GetFactoryByUserIdAsync(user.Id);
            if (factory == null)
                throw new ApplicationException($"Couldn't Show Products");
            var products = await _productService.GetProductsByFactoryIdAsync(factory.Id);
            return Ok(products);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] ProductViewModel model)
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
                FactoryId = factory.Id
            };

            var createdProduct = await _productService.CreateProductAsync(product);
            return CreatedAtAction(nameof(GetFactoryProducts), new { id = createdProduct.Id }, createdProduct);
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
    }

}
