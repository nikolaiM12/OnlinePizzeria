using OnlinePizzeria.Services.ViewModels;

namespace OnlinePizzeria.Services.Interfaces
{
    public interface IProviderService
    {
		List<ProviderViewModel> GetAll();
		Task CreateAsync(ProviderViewModel model);
		Task DeleteProvider(string id);
		ProviderViewModel GetDetailsById(string id);
		Task UpdateAsync(ProviderViewModel model);
		Task<ProviderViewModel> UpdateById(string id);
		Task<bool> ProviderExists(string id);
	}
}
