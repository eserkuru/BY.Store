using BY.Store.Application.Interfaces;
using BY.Store.Application.Services;
using BY.Store.Infrastructure.DataAccess.Interfaces;
using BY.Store.Infrastructure.DataAccess.Internal.EntityFrameworkCore.Repositories;
using BY.Store.Shared.Params;
using Microsoft.Extensions.DependencyInjection;

namespace BY.Store.Application.Injections.Microsoft
{
    public class Injector
    {
        private readonly IServiceCollection _services;

        public Injector(IServiceCollection services)
        {
            _services = services;
        }

        public Injector InjectRepositories()
        {
            _services.AddScoped<IProductRepository, ProductRepository>();
            _services.AddScoped<IStockRepository, StockRepository>();
            _services.AddScoped<IBasketRepository, BasketRepository>();
            _services.AddScoped<IBasketItemRepository, BasketItemRepository>();
            return this;
        }

        public Injector InjectServices()
        {
            _services.AddScoped<IBasketService, BasketService>();
            _services.AddScoped<IBasketItemService, BasketItemService>();

            return this;
        }

        public Injector InjectShared()
        {
            _services.AddSingleton<IApplicationParams, ApplicationParams>();

            return this;
        }
    }
}
