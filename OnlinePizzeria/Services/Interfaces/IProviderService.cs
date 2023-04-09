using OnlinePizzeria.Services.ViewModels;

namespace OnlinePizzeria.Services.Interfaces
{
    public interface IProviderService
    {
        Task<ICollection<ProviderViewModel>> GetAll();
        Task CreateAsync(ProviderViewModel model);
        Task DeleteProvider(string providerId);
        ProviderViewModel GetDetailsById(string providerId);
        Task UpdateAsync(ProviderViewModel model);
        ProviderViewModel UpdateById(string providerId);
    }
}
