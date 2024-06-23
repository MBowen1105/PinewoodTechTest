using Carter;

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

            return services;
        }
    }
}
