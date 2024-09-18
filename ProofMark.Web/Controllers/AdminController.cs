using Microsoft.AspNetCore.Identity;
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
        public async Task<IActionResult> GetAllFactories()
        {
            var factories = await _factoryService.GetAllFactoriesAsync();
            return Ok(factories);
        }

        [HttpPost]
        public async Task<IActionResult> CreateFactory([FromBody] FactoryViewModel model)
        {


            var user = new User
            {
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                UserType = UserType.Factory,
                UserName = model.Email,
            };
            PasswordHasher<User> hasher = new PasswordHasher<User>();
            user.PasswordHash = hasher.HashPassword(user, "Admin@123");
            var factory = new Factory
            {
                CompanyName = model.CompanyName,
                Address = model.Address,
                ContactPerson = model.ContactPerson,
                PhoneNumber = model.PhoneNumber,

                User = user
            };
            var createdFactory = await _factoryService.CreateFactoryAsync(factory, factory.User.PasswordHash);
            return CreatedAtAction(nameof(GetAllFactories), new { id = createdFactory.Id }, createdFactory);
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
        public async Task<IActionResult> DeleteFactory(int id)
        {
            await _factoryService.DeleteFactoryAsync(id);
            return NoContent();
        }
    }
}
