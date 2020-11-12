using AzureFriday.Orders.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace AzureFriday.Orders.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddShipmentsIntegration(this IServiceCollection services)
        {
            services.AddScoped<IShipmentRepository, ShipmentRepository>();
            return services;
        }
        public static IServiceCollection AddOrdersProcessor(this IServiceCollection services)
        {
            services.AddHostedService<OrdersQueueProcessor>();
            return services;
        }
    }
}
