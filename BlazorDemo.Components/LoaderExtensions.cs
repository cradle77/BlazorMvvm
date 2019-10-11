using Microsoft.Extensions.DependencyInjection;

namespace BlazorDemo.Components
{
    public static class LoaderExtensions
    {
        public static IServiceCollection AddLoader(this IServiceCollection services)
        {
            return services.AddScoped<ILoaderService, LoaderService>();
        }
    }
}
