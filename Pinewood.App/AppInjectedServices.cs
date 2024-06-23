using Microsoft.Extensions.DependencyInjection;
using Pinewood.App.Customers;
using Pinewood.Domain.Customers;

namespace Pinewood.App
{
    public static class AppInjectedServices
    {
        public static IServiceCollection AddAppServices(this IServiceCollection services)
        {
            services.AddScoped<ICustomerService, CustomerService>();
            return services;
        }
    }
}
