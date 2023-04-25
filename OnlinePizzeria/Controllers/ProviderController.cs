using Microsoft.AspNetCore.Mvc;
using OnlinePizzeria.Services;

namespace OnlinePizzeria.Controllers
{
	public class ProviderController : Controller
	{
		public ProviderService providerService { get; set; }

		public ProviderController(ProviderService service)
		{
			providerService = service;
		}
		public IActionResult Index()
		{
			return View();
		}
	}
}
