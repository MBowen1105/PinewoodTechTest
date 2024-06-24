using Microsoft.Extensions.DependencyInjection;

namespace Pinewood.Persistence
{
    public static class PersistenceInjectedServices
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services)
        {
            services.AddTransient<ICustomerRepository, MockCustomerRepository>();
            return services;
        }
    }
}
