using Microsoft.Extensions.DependencyInjection;

namespace Pinewood.App
{
    public static class AppInjectedServices
    {
        public static IServiceCollection AddAppServices(this IServiceCollection services)
        {
            return services;
        }
    }
}
