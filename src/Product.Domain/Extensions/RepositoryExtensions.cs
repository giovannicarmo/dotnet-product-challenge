using Microsoft.Extensions.DependencyInjection;
using Product.Domain.Repositories;

namespace Product.Domain.Extensions
{
    public static class RepositoryExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
            => services
                .AddScoped<IProductItemRepository, ProductItemRepository>();
    }
}