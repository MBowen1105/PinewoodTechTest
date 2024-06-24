using Carter;
using Pinewood.App;
using Pinewood.Persistence;

namespace Pinewood.API
{
    public static class ApiInjectedServices
    {
        public static IServiceCollection AddApiServices(this IServiceCollection services)
        {
            var assemblyList = AppDomain.CurrentDomain.GetAssemblies();

            services.AddMediatR(cfg =>
                cfg.RegisterServicesFromAssemblies(assemblyList)
                );

            services.AddCarter();

            services.AddScoped<ICustomerRepository, MockCustomerRepository>();

            return services;
        }
    }
}
