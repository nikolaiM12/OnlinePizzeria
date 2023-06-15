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

        public List<ProviderViewModel> GetAll()
        {
            return context.Providers
                .Include(o => o.Order)
                .Select(provider => new ProviderViewModel()
                {
                    Id = provider.Id,
                    Name = provider.Name,
                    PhoneNumber = provider.PhoneNumber,
                    Veliche = provider.Veliche,
                    IsAvailable = provider.IsAvailable,
                    Rating = provider.Rating,
                    Order = provider.Order
                }).ToList();
        }

        public async Task CreateAsync(ProviderViewModel model)
        {
            Provider provider = new Provider();

            provider.Id = Guid.NewGuid().ToString();
            provider.Name = model.Name;
            provider.PhoneNumber = model.PhoneNumber;
            provider.Veliche = model.Veliche;
            provider.IsAvailable = model.IsAvailable;
            provider.Rating = model.Rating;
            provider.CreatedAt = DateTime.Now;

            await context.Providers.AddAsync(provider);
            await context.SaveChangesAsync();
        }

        public async Task DeleteProvider(string id)
        {
            if (string.IsNullOrEmpty(id) || string.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentException("Invalid ID");
            }

            var provider = await context.Providers
            .Include(o => o.Order)
            .FirstOrDefaultAsync(o => o.Id == id);

            if (provider != null)
            {
                context.Providers.Remove(provider);
                await context.SaveChangesAsync();
            }
        }

        public ProviderViewModel GetDetailsById(string id)
        {
            ProviderViewModel provider = context.Providers
                .Include(p => p.Order)
                .Select(provider => new ProviderViewModel()
                {
                    Id = provider.Id,
                    Name = provider.Name,
                    PhoneNumber = provider.PhoneNumber,
                    Veliche = provider.Veliche,
                    IsAvailable = provider.IsAvailable,
                    Rating = provider.Rating,
                    Order = provider.Order
                }).SingleOrDefault(provider => provider.Id == id);
            return provider;
        }

        public async Task UpdateAsync(ProviderViewModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model), "Invalid provider model");
            }

            var providerExists = await ProviderExists(model.Id!);
            if (!providerExists)
            {
                throw new ArgumentNullException(nameof(providerExists), "Provider not found");
            }

            var provider = new Provider
            {
                Id = model.Id,
                Name = model.Name,
                PhoneNumber = model.PhoneNumber,
                Veliche = model.Veliche,
                IsAvailable = model.IsAvailable,
                Rating = model.Rating,
                ModifiedAt = DateTime.Now
            };


            context.Providers.Update(provider);
            await context.SaveChangesAsync();
        }

        public async Task<ProviderViewModel> UpdateById(string id)
        {
            if (!await ProviderExists(id))
            {
                throw new ArgumentNullException(nameof(id), "Provider not found");
            }
            ProviderViewModel provider = await context.Providers
            .Include(p => p.Order)
            .Where(p => p.Id == id)
            .Select(p => new ProviderViewModel
            {
                Id = p.Id,
                Name = p.Name,
                PhoneNumber = p.PhoneNumber,
                Veliche = p.Veliche,
                IsAvailable = p.IsAvailable,
                Rating = p.Rating,
            }).SingleOrDefaultAsync();

            return provider;
        }
        public async Task<bool> ProviderExists(string id)
        {
            return await context.Providers.AnyAsync(p => p.Id == id);
        }
    }
}
