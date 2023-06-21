using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlinePizzeria.Services;
using OnlinePizzeria.Services.Interfaces;
using OnlinePizzeria.Services.ViewModels;

namespace OnlinePizzeria.Controllers
{
	public class ProviderController : Controller
	{
        public ProviderService providerService { get; set; }

        public ProviderController(ProviderService service)
        {
            providerService = service;
        }
        [Authorize(Roles = "User")]
        [HttpGet]
        public IActionResult Index()
        {
            List<ProviderViewModel> providers = providerService.GetAll();
            return View(providers);
        }

        [HttpGet]
        public IActionResult Details(string id)
        {
            ProviderViewModel provider = providerService.GetDetailsById(id);
            bool isCourseNull = provider == null;
            if (isCourseNull)
            {
                return NotFound();
            }

            return this.View(provider);
        }
        [HttpGet]
        public IActionResult AddProvider()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddProvider(ProviderViewModel provider)
        {
            if (provider == null)
            {
                return BadRequest("Invalid provider data");
            }

            TempData["success"] = "Provider added successfully";
            await providerService.CreateAsync(provider);
            return RedirectToAction(nameof(Index));
        }
	
        [HttpGet]
        public IActionResult DeleteProvider()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteProvider(string id)
        {
            ProviderViewModel provider = providerService.GetDetailsById(id);
            if (provider == null)
            {
                return NotFound();
            }
            TempData["success"] = "Provider deleted successfully";
            await providerService.DeleteProvider(id);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> UpdateProvider(string id)
        {
            ProviderViewModel provider = await providerService.UpdateById(id);

            if (provider == null)
            {
                return NotFound();
            }
            return View(provider);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> UpdateProvider(ProviderViewModel model)
        {
            bool providerExists = await ProviderExists(model.Id!);

            if (providerExists)
            {
                TempData["success"] = "Provider updated successfully";
                await providerService.UpdateAsync(model);
                return RedirectToAction(nameof(Index));
            }

            else
            {
                ModelState.AddModelError(string.Empty, "Provider not found");
            }

            return View(model);
        }
	
        private async Task<bool> ProviderExists(string id)
        {
            return await providerService.ProviderExists(id);
        }
    }
}
