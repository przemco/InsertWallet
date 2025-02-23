using Microsoft.Extensions.DependencyInjection;

namespace Modules.Cantor.Presentation
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPresentation(this IServiceCollection services)
        {
            return services;
        }
    }
}
