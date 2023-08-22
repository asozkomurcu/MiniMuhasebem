using MiniMuhasebem.UI.Services.Abstraction;
using MiniMuhasebem.UI.Services.Implementation;

namespace MiniMuhasebem.UI.Configurations
{
    public static class ServiceInjection
    {
        public static IServiceCollection AddDIServices(this IServiceCollection services)
        {
            services.AddScoped<IRestService, RestService>();
            
            return services;
        }
    }
}
