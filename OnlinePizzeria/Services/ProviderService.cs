using Microsoft.EntityFrameworkCore;
using OnlinePizzeria.Data;
using OnlinePizzeria.Model;
using OnlinePizzeria.Services.Interfaces;
using OnlinePizzeria.Services.ViewModels;

namespace OnlinePizzeria.Services
{
    public class ProviderService : IProviderService
    {
        private readonly ApplicationDbContext context;
        public ProviderService(ApplicationDbContext post)
        {
            context = post;
        }
        public async Task<ICollection<ProviderViewModel>> GetAll()
        {
            return await context.Providers.Select(provider => new ProviderViewModel()
            {
                Name = provider.Name,
                PhoneNumber = provider.PhoneNumber,
                Veliche = provider.Veliche,
                IsAvailable = provider.IsAvailable,
                Rating = provider.Rating,
                DeliveredOrders = provider.DeliveredOrders
            }).ToListAsync();
        }
        public async Task CreateAsync(ProviderViewModel model)
        {
            Provider provider = new Provider();

            provider.ProviderId = model.ProviderId;
            provider.Name = model.Name;
            provider.PhoneNumber = model.PhoneNumber;   
            provider.Veliche = model.Veliche;
            provider.IsAvailable = model.IsAvailable;
            provider.Rating = model.Rating;
            provider.DeliveredOrders = model.DeliveredOrders;

            await context.Providers.AddAsync(provider);
            await context.SaveChangesAsync();
        }
        public async Task DeleteProvider(string providerId)
        {
            var providerDb = context.Providers.FirstOrDefault(x => x.ProviderId == providerId);
            context.Providers.Remove(providerDb);
            await context.SaveChangesAsync();
        }
        public ProviderViewModel GetDetailsById(string providerId)
        {
            ProviderViewModel provider = context.Providers
                .Select(provider => new ProviderViewModel()
                {
                    ProviderId = provider.ProviderId,
                    Name = provider.Name,
                    PhoneNumber = provider.PhoneNumber,
                    Veliche = provider.Veliche,
                    IsAvailable = provider.IsAvailable,
                    Rating = provider.Rating,
                    DeliveredOrders = provider.DeliveredOrders
                }).SingleOrDefault(provider => provider.ProviderId == providerId);
            return provider;
        }
        public async Task UpdateAsync(ProviderViewModel model)
        {
            Provider provider = context.Providers.Find(model.ProviderId);
            bool isProviderNull = provider == null;
            if(isProviderNull)
            {
                return;
            }
             provider.Name = model.Name;
             provider.PhoneNumber = model.PhoneNumber;
             provider.Veliche = model.Veliche;
             provider.IsAvailable = model.IsAvailable;
             provider.Rating = model.Rating;
             provider.DeliveredOrders = model.DeliveredOrders;

             context.Providers.Update(provider);
             await context.SaveChangesAsync();
        }
        public ProviderViewModel UpdateById(string  providerId)
        {
            ProviderViewModel provider = context.Providers
                .Select(provider => new ProviderViewModel()
                {
                    ProviderId = provider.ProviderId,
                    Name = provider.Name,
                    PhoneNumber = provider.PhoneNumber,
                    Veliche = provider.Veliche,
                    IsAvailable = provider.IsAvailable,
                    Rating = provider.Rating,
                    DeliveredOrders = provider.DeliveredOrders
                }).SingleOrDefault(provider => provider.ProviderId == providerId);
            return provider;
        }
    }
}
