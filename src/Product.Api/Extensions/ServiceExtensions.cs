using Microsoft.Extensions.DependencyInjection;
using Product.Api.Services;

namespace Product.Api.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
            => services
                .AddScoped<IProductItemService, ProductItemService>();
    }
}