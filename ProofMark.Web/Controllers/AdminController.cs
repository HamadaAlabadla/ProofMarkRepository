using Microsoft.AspNetCore.Mvc;
using ProofMark.Core.ViewModels;
using ProofMark.EF.Models;
using ProofMark.Infrastructure.Services;
using static ProofMark.Core.Enums.Enums;

namespace ProofMark.Web.Controllers
{
	//[Authorize(Roles = "Admin")]
	public class AdminController : Controller
	{
		private readonly IFactoryService _factoryService;

		public AdminController(IFactoryService factoryService)
		{
			_factoryService = factoryService;
		}
		[HttpGet]
		public async Task<IActionResult> Index()
		{
			return View();
		}
		[HttpGet]
		public async Task<IActionResult> GetAllFactories()
		{
			var factories = await _factoryService.GetAllFactoriesAsync();
			var recordsTotal = factories.Count();
			var jsonData = new { recordsFiltered = recordsTotal, recordsTotal, data = factories };
			return Json(jsonData);
		}

		[HttpPost]
		public async Task<IActionResult> CreateFactory(FactoryViewModel model)
		{

			if (ModelState.IsValid)
			{
				var user = new User
				{
					Email = model.Email,
					PhoneNumber = model.PhoneNumber,
					UserType = UserType.Factory,
					UserName = model.Email,
					IsActive = true
				};
				var factory = new Factory
				{
					CompanyName = model.CompanyName,
					Address = model.Address,
					ContactPerson = model.ContactPerson,
					PhoneNumber = model.PhoneNumber,

					User = user
				};
				var createdFactory = await _factoryService.CreateFactoryAsync(factory, model.Password!);
				return Json(new { success = (createdFactory is null) ? false : true, message = (createdFactory is not null) ? "Factory has been successfully created!" : "Invalid data" });
			}
			return Json(new { success = false, message = "Invalid data" });
		}

		[HttpPut]
		public async Task<IActionResult> UpdateFactory(int id, [FromBody] FactoryViewModel model)
		{
			var factory = await _factoryService.GetFactoryByUserIdAsync(model.UserId ?? "");
			if (factory == null || factory.Id != id)
				return NotFound();

			factory.CompanyName = model.CompanyName;
			factory.Address = model.Address;
			factory.ContactPerson = model.ContactPerson;
			factory.PhoneNumber = model.PhoneNumber;

			await _factoryService.UpdateFactoryAsync(factory);
			return NoContent();
		}

		[HttpDelete]
		public async Task<IActionResult> DeleteFactory(int Id)
		{
			var result = await _factoryService.DeleteFactoryAsync(Id);
            return Json(new { success = result, message = (result) ? "Factory has been successfully deleted!" : "Factory has been error deleted!" });
        }
    }
}
