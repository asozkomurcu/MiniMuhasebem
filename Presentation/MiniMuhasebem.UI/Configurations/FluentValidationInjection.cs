using FluentValidation;
using FluentValidation.AspNetCore;
using MiniMuhasebem.UI.Validators.AccountsValidators;

namespace MiniMuhasebem.UI.Configurations
{
    public static class FluentValidationInjection
    {
        public static IServiceCollection AddFluentValidationService(this IServiceCollection services)
        {
            services.AddFluentValidationAutoValidation()
    .AddFluentValidationClientsideAdapters();

            services.AddValidatorsFromAssemblyContaining(typeof(LoginValidator));

            return services;
        }
    }
}
